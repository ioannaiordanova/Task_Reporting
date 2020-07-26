using NUnit.Framework;

namespace SanityTests
{
    public partial class SheetPage : MainMenuPage
    {
        public void AssertPageScale(string expectedSaclingIndex)
        {
            Assert.AreEqual(expectedSaclingIndex, GetPageScaleValue());
            Assert.AreEqual(expectedSaclingIndex, GetPageScaleValue());
        }

        public void AssertHeaderContains(string Option)
        {
            Assert.IsTrue(TextBoxCategories.Text.Contains(Option));
        }

        public void AssertSelectedCategoryIs(string option)
        {
            Assert.AreEqual(option, GetSelectedSingleOptionWebElelent().Text);
        }

       
    }
}
