using Punch.Base.Tests;
using Punch.Bindings;
using NUnit.Framework;

namespace Punch.Sortable.Tests
{
    public class SortableTests : BaseTest
    {
        [Test]
        public void sortable_binding()
        {
            var context = CreateKnockoutContext<Model>();
            var binding = context.Bind.Sortable(m => m.SubModels);
            Assert.AreEqual(@"sortable : {data : SubModels}", binding.GetKnockoutExpression(context.CreateData()));
        }
    }
}
