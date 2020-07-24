using Core.Utilities.Extentions;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System.Text.RegularExpressions;

namespace SanityTests.Tests
{
    class MainMenuPageTests : BaseTest
    {
        protected SheetPage _sheetPage;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _sheetPage = new SheetPage(Driver);
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
        public void Google_First_Found_Result()
        {
            _sheetPage.ZoomIn.Click();

            var style = _sheetPage.Sheet1.GetAttribute("style");

            Match rex = DriverExtentions.ExtractPartOfString(style);

        }

    }
}
