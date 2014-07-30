using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Punch.Contracts;
using Punch.Core;

namespace Punch.Bindings
{
    public class KnockoutSortableBinding : KnockoutSortableBindingBase
    {
        public KnockoutSortableBinding(string data)
            : base()
        {
            base.Add(new KnockoutBindingStringItem("data", data, false));
        }
    }

    public class KnockoutSortableBinding<TModel, TProperty> : KnockoutSortableBindingBase
    {
        public KnockoutSortableBinding(Expression<Func<TModel, IList<TProperty>>> expression)
        {
            base.Add(new KnockoutBindingItem<TModel, IList<TProperty>>("data", expression));
        }
    }

    public static class KnockoutSortableBindingExtensions
    {
        public static KnockoutSortableBinding Sortable<TReturn>(this IKnockoutBindingCollection<TReturn> bindings, string property)
            where TReturn : IKnockoutBindingCollection
        {
            var binding = new KnockoutSortableBinding(property);
            bindings.Add(binding);
            return binding;
        }

        public static KnockoutSortableBinding<TModel, TProperty> Sortable<TReturn, TModel, TProperty>(this IKnockoutBindingCollection<TReturn, TModel> bindings, Expression<Func<TModel, IList<TProperty>>> expression)
            where TReturn : IKnockoutBindingCollection
        {
            var binding = new KnockoutSortableBinding<TModel, TProperty>(expression);
            bindings.Add(binding);
            return binding;
        }
    }
}
