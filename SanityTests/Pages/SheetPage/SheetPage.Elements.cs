using Core;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SanityTests
{
    public partial class SheetPage : MainMenuPage
    {
      

        public WebElement Sheet1 => Driver.FindElement(By.CssSelector(".sheet.page1"));

        public WebElement ParametersArea => Driver.FindElement(By.CssSelector("[data-id = 'trv-parameters-area']"));

        public List<WebElement> SingleSelectOptions => ParametersArea.FindElements(By.CssSelector("#trv-parameter-editor-singleselect-list > div.trv-listviewitem"));

        public WebElement TextBoxCategories => Driver.FindElement(By.ClassName("textBoxCategories"));

        public WebElement Trial => Driver.FindElement(By.ClassName("trial"));

        public WebElement ActivePageWrapper => Driver.FindElement(By.CssSelector("div.trv-page-wrapper.active"));

        public WebElement ReportPage => Driver.FindElement(By.CssSelector("div.trv-report-page"));
      
    }
}
