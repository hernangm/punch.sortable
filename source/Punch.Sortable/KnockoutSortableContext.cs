using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using Punch.Bindings;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Context
{
    public class KnockoutSortableContext<TChild, TParent> : KnockoutForEachContext<TChild, TParent>
    {
        public KnockoutSortableContext(IList<IKnockoutContext> contextStack, ViewContext viewContext, Expression<Func<TParent, IList<TChild>>> expression, string tag)
            : base(viewContext, expression, tag)
        {
            this.ContextStack = contextStack;
        }

        public KnockoutSortableContext(IList<IKnockoutContext> contextStack, ViewContext viewContext, Expression<Func<TParent, IList<TChild>>> expression)
            : this(contextStack, viewContext, expression, null) { }

        protected override IKnockoutBindingItem GetBinding()
        {
            return new KnockoutSortableBinding<TParent, TChild>(this.Expression);
        }

    }

    public static class KnockoutSortableExtensions
    {
        public static KnockoutSortableContext<TItem, TModel> Sortable<TModel, TItem>(this IKnockoutContext<TModel> context, Expression<Func<TModel, IList<TItem>>> binding)
        {
            return context.Sortable<TModel, TItem>(null, binding, null);
        }

        public static KnockoutSortableContext<TItem, TModel> Sortable<TModel, TItem>(this IKnockoutContext<TModel> context, string tag, Expression<Func<TModel, IList<TItem>>> binding)
        {
            return context.Sortable<TModel, TItem>(tag, binding, null);
        }

        public static KnockoutSortableContext<TItem, TModel> Sortable<TModel, TItem>(this IKnockoutContext<TModel> context, string tag, Expression<Func<TModel, IList<TItem>>> binding, object attributes)
        {
            var regionContext = new KnockoutSortableContext<TItem, TModel>(context.ContextStack, context.ViewContext, binding, tag);
            if (attributes != null)
            {
                regionContext.AddAttributes(attributes);
            }
            regionContext.WriteStart(context.ViewContext.Writer);
            context.AddToContextStack(regionContext);
            return regionContext;
        }
    }
}
