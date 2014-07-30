using System;
using Punch.Bindings;
using Eqip.Metadata;
using Eqip.Metadata.Contracts;


namespace Punch.Metadata
{
    public class SortableMetadata : MetadataBindingBase<KnockoutSortableBinding>, IFluentInterface
    {
        public SortableMetadata(KnockoutSortableBinding binding)
            : base(binding)
        {
            this.ShouldReplace = true;
        }

        public SortableMetadata AfterMove(string afterMove)
        {
            this.Binding.AfterMove(afterMove);
            return this;
        }

        public SortableMetadata BeforeMove(string beforeMove)
        {
            this.Binding.BeforeMove(beforeMove);
            return this;
        }

        public SortableMetadata IsEnabled(string isEnabled)
        {
            this.Binding.IsEnabled(isEnabled);
            return this;
        }

        public SortableMetadata AllowDrop(bool allowDrop)
        {
            this.Binding.AllowDrop(allowDrop);
            return this;
        }
    }

    public static class MetadataCollectorExtensions
    {
        public static SortableMetadata Sortable<TModel, TProperty>(this IMetadataCollector<TModel, TProperty> metadataCollection)
        {
            var config = new SortableMetadata(new KnockoutSortableBinding(metadataCollection.PropertyName));
            metadataCollection.Add(config);
            return config;
        }
    }
}
