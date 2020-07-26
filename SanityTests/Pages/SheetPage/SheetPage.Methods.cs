using Core;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace SanityTests
{
    public partial class SheetPage : MainMenuPage
    {
        public SheetPage(WebDriver driver) : base(driver)
        {

        }

        SearchForm _searchForm;
        public SearchForm SearchForm 
        {
            get 
            {
                return _searchForm;

            }
        }

        public string ScaleValue
        {
            get
            {
                return GetPageScaleMatch().Groups[1].Value;
            }
        }

        private Match GetPageScaleMatch()
        {
            return Regex.Match(Sheet1.GetAttribute("style"), @"\w*\s*scale\((.*),\s(.*)\).*");
        }

        private WebElement GetSingleOptionWebElelentByName(string option)
        {
            return SingleSelectOptions.First(s => s.Text == option);
        }

        private WebElement GetSelectedSingleOptionWebElelent()
        {
            return SingleSelectOptions.First(s => s.GetAttribute("class").Contains("selected"));
        }

        [Obsolete]
        public void ClickSingleOptionAndWaitReload(string SingleOptionName)
        {
            GetSingleOptionWebElelentByName(SingleOptionName).Click();
            WaitUntilDocumentIsLoaded();
        }

        [Obsolete]
        public void InitiateSearch()
        {
            SearchButton.Click();
            _searchForm = new SearchForm(Driver);
            Driver.WrappedWait.Until(ExpectedConditions.ElementIsVisible(_searchForm.SearchDraggable.By));
        }

        [Obsolete]
        public void WaitUntilDocumentIsLoaded()
        {
            Driver.WrappedWait.Until(ExpectedConditions.TextToBePresentInElement(MessageBox.WrappedElement, "so far"));
            Driver.WrappedWait.Until(ExpectedConditions.TextToBePresentInElement(MessageBox.WrappedElement, "Done"));
        }   
    }
}
