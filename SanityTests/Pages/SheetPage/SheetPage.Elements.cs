using Core;
using OpenQA.Selenium;

namespace SanityTests
{
    public partial class SheetPage : MainMenuPage
    {
       public WebElement Sheet1 => Driver.FindElement(By.CssSelector(".sheet.page1"));
    }
}
