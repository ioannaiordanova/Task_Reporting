using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium.Support.UI;
using System;

namespace SanityTests.Tests
{
    class SheetPage : BaseTest
    {
        protected SanityTests.SheetPage _sheetPage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _sheetPage = new SanityTests.SheetPage(Driver);
            _sheetPage.NavigateTo();
            
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                Driver.SaveScreenShot();
            }
            Driver.Quit();
        }

        [Test]
        public void ZoomIn()
        {
            string NextScaling = _sheetPage.GetNextScaling();
            
            _sheetPage.ZoomIn.Click();

            _sheetPage.AssertPageScale(NextScaling);

        }

        [Test]
        public void ZoomOut()
        {
            string PreviousScaling = _sheetPage.GetPreviousScaling();

            _sheetPage.ZoomOut.Click();

            _sheetPage.AssertPageScale(PreviousScaling);

        }

        [Test]
        [Obsolete]
        public void ToggleParametersArea()
        {
            _sheetPage.ToggleParameterButton.Click();

            _sheetPage.AssertWebElementDoesNotExists(_sheetPage.ParametersArea.By);
        }   
    }
}
