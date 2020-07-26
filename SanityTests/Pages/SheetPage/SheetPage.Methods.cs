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

        public string GetNextScaling()
        {
            return ScaleValuesList[GetNextScalingIndex()];
        }

        public string GetPreviousScaling()
        {
            return ScaleValuesList[GetPreviousScalingIndex()];
        }

        public int GetPreviousScalingIndex()
        {
            return (0 == ScaleValuesList.IndexOf(GetPageScaleValue())) ?
                ScaleValuesList.IndexOf(GetPageScaleValue())
            :
                ScaleValuesList.IndexOf(GetPageScaleValue()) - 1;
        }

        private int GetNextScalingIndex()
        {
            return (ScaleValuesList.Count == (ScaleValuesList.IndexOf(GetPageScaleValue()) + 1)) ?
                ScaleValuesList.IndexOf(GetPageScaleValue())
            :
                ScaleValuesList.IndexOf(GetPageScaleValue()) + 1;
        }


        private Match GetPageScaleMatch()
        {
            return Regex.Match(Sheet1.GetAttribute("style"), @"\w*\s*scale\((.*),\s(.*)\).*");
        }

        private string GetPageScaleValue()
        {
            return GetPageScaleMatch().Groups[1].Value;
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
            WebElement OptionElement = GetSingleOptionWebElelentByName(SingleOptionName);
            OptionElement.Click();
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
        private void WaitUntilDocumentIsLoaded()
        {
            Driver.WrappedWait.Until(ExpectedConditions.TextToBePresentInElement(MessageBox.WrappedElement, "Done"));
        }
    }
}
