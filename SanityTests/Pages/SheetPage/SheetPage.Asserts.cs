using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SanityTests
{
    public partial class SheetPage : MainMenuPage
    {
        public void AssertPageScale(string expectedSaclingIndex)
        {
            Assert.AreEqual(expectedSaclingIndex, GetPageScaleValue());
            Assert.AreEqual(expectedSaclingIndex, GetPageScaleValue());
        }

        [Obsolete]
        public void AssertWebElementDoesNotExists(By _by)
        {
            Driver.WrappedWait.Until(ExpectedConditions.InvisibilityOfElementLocated(_by));
        }
    }
}
