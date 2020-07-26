using Core.Utilities.Extentions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace SanityTests
{
    public partial class SheetPage : MainMenuPage
    {
        public void AssertPageScale(string expectedSaclingIndex)
        {
            Assert.AreEqual(expectedSaclingIndex, ScaleValue);
            Assert.AreEqual(expectedSaclingIndex, ScaleValue);
        }

        public void AssertHeaderContains(string Option)
        {
            Assert.IsTrue(TextBoxCategories.Text.Contains(Option));
        }

        public void AssertSelectedCategoryIs(string option)
        {
            Assert.AreEqual(option, GetSelectedSingleOptionWebElelent().Text);
        }

        public void AssertTrialOnScreen()
        {
            Assert.IsTrue(Trial.isVisibleInViewport());
        }

        public void AssertReportIsToggledWidth()
        {
            Assert.AreEqual((double)ActivePageWrapper.Width,(double)ReportPage.Width,10);
        }


    }
}
