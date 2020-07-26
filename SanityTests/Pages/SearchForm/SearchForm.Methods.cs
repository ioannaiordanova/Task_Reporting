using Core;
using OpenQA.Selenium.Support.UI;
using System;

namespace SanityTests
{
    public partial class SearchForm : BasePage
    {
        const string ResultMessage = "Result 1 of ";
        public SearchForm(WebDriver driver) : base(driver)
        {
           
        }

        [Obsolete]
        public void WaitUntilCountOccurencies()
        {
            Driver.WrappedWait.Until(ExpectedConditions.TextToBePresentInElement(SearchResultLabel.WrappedElement, "Result"));
        }

    }
}
