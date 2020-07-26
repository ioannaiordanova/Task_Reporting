using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;

namespace SanityTests.Tests
{
    class SheetTest : BaseTest
    {
        protected SheetPage _sheetPage;
        protected Scale _scale;

        [SetUp]
        public void SetUp()
        {
            Initialize();
            _sheetPage = new SheetPage(Driver);
            _sheetPage.NavigateTo();
            _scale = new Scale();

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
        [Obsolete]
        public void ZoomIn()
        {
            string NextScaling = _scale.GetNext(_sheetPage.ScaleValue);

            _sheetPage.ZoomIn.Click();

            _sheetPage.AssertPageScale(NextScaling);

        }

        [Test]
        [Obsolete]
        public void ZoomOut()
        {
            string PreviousScaling = _scale.GetPrevious(_sheetPage.ScaleValue);

            _sheetPage.ZoomOut.Click();

            _sheetPage.AssertPageScale(PreviousScaling);

        }

        [Test]
        [Obsolete]
        public void ParametersAreaExists()
        {
            _sheetPage.AssertWebElementVisisble(_sheetPage.ParametersArea.By);
        }

        [Test]
        [Obsolete]
        public void ParametersAreaNotExists_WhenToggleButtonCliked()
        {
            _sheetPage.ToggleParameterButton.Click();

            _sheetPage.AssertWebElementDoesNotExists(_sheetPage.ParametersArea.By);
        }

        [Test]
        [Obsolete]
        public void TrialOnScreen_WhenToggle_FullPage_Cliked()
        {
            _sheetPage.WaitUntilDocumentIsLoaded();
            _sheetPage.ToggleFullPageOrWidth.Click();

            _sheetPage.AssertTrialOnScreen();
        }

        [Test]
        [Obsolete]
        public void TrialOnScreen_WhenToggle_PageWidth_Cliked()
        {
            _sheetPage.WaitUntilDocumentIsLoaded();
            _sheetPage.ToggleFullPageOrWidth.Click();
            _sheetPage.ToggleFullPageOrWidth.Click();

            _sheetPage.AssertReportIsToggledWidth();
        }

        [Test]
        [TestCase("Accessories")]
        [TestCase("Clothing")]
        [TestCase("Bikes")]
        [TestCase("Components")]
        [Obsolete]
        public void SelectSingleOptionTest(string Option)
        {
            _sheetPage.ClickSingleOptionAndWaitReload(Option);

            _sheetPage.AssertHeaderContains(Option);
            _sheetPage.AssertSelectedCategoryIs(Option);
        }


        [Test]
        [TestCase("Accessories", "Clothing")]
        [Obsolete]
        public void BackButtonTest(string FirstCategory, string NextCategory)
        {

            _sheetPage.ClickSingleOptionAndWaitReload(FirstCategory);
            _sheetPage.ClickSingleOptionAndWaitReload(NextCategory);
           
            _sheetPage.BackButton.Click();

            _sheetPage.AssertHeaderContains(FirstCategory);
            _sheetPage.AssertSelectedCategoryIs(FirstCategory);

        }


        [TestCase("Components", "Bikes")]
        [Obsolete]
        public void NextButtonTest(string FirstCategory, string NextCategory)
        {
            _sheetPage.ClickSingleOptionAndWaitReload(FirstCategory);
            _sheetPage.ClickSingleOptionAndWaitReload(NextCategory);
           
            _sheetPage.BackButton.Click();      
            _sheetPage.NextButton.Click();

            _sheetPage.AssertHeaderContains(NextCategory);
            _sheetPage.AssertSelectedCategoryIs(NextCategory);

        }


        [Test]
        [Obsolete]
        [TestCase("Bikes",true, 2)]
        public void SearchInReportContentTest(string SearchWord,bool MatchCase, int Occurencies)
        {
            _sheetPage.ClickSingleOptionAndWaitReload(SearchWord);
            _sheetPage.InitiateSearch();
            
            _sheetPage.SearchForm.FindTextBox.SetText(SearchWord + Keys.Enter);

            if (MatchCase) _sheetPage.SearchForm.MatchCaseButton.Click();
            _sheetPage.SearchForm.AssertSearchResult(Occurencies);
        }

    }
}
