using NUnit.Framework;
using NUnit.Framework.Interfaces;

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

    }
}
