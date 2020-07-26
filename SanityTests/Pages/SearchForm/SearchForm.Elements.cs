using Core;
using OpenQA.Selenium;

namespace SanityTests
{
    public partial class SearchForm : BasePage
    {
        public WebElement SearchDraggable => Driver.FindElement(By.CssSelector(".k-widget.k-window.trv-search"));

        public WebElement FindTextBox => SearchDraggable.FindElement(By.TagName("input"));

        public WebElement SearchResultLabel => SearchDraggable.FindElement(By.ClassName("trv-search-dialog-results-label"));
    }
}
