
namespace Punch.Bindings
{
    // todo: IFluentInterface
    public abstract class KnockoutSortableBindingBase : KnockoutBindingComplexItem
    {
        public KnockoutSortableBindingBase AfterMove(string afterMove)
        {
            base.Add(new KnockoutBindingStringItem("afterMove", afterMove, false));
            return this;
        }

        public KnockoutSortableBindingBase BeforeMove(string beforeMove)
        {
            base.Add(new KnockoutBindingStringItem("beforeMove", beforeMove, false));
            return this;
        }

        public KnockoutSortableBindingBase IsEnabled(string isEnabled)
        {
            base.Add(new KnockoutBindingStringItem("isEnabled", isEnabled, false));
            return this;
        }

        public KnockoutSortableBindingBase IsEnabled(bool isEnabled)
        {
            base.Add(new KnockoutBindingStringItem("isEnabled", isEnabled.ToString().ToLower(), false));
            return this;
        }

        public KnockoutSortableBindingBase AllowDrop(string allowDrop)
        {
            base.Add(new KnockoutBindingStringItem("allowDrop", allowDrop, false));
            return this;
        }

        public KnockoutSortableBindingBase AllowDrop(bool allowDrop)
        {
            base.Add(new KnockoutBindingStringItem("allowDrop", allowDrop.ToString().ToLower(), false));
            return this;
        }

        public KnockoutSortableBindingBase ConnectClass(string connectClass)
        {
            base.Add(new KnockoutBindingStringItem("connectClass", connectClass, false));
            return this;
        }
    }
}
