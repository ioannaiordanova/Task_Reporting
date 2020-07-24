using Core;
using OpenQA.Selenium;

namespace SanityTests
{
    public partial class MainMenuPage : BasePage
    {
        public WebElement MainMenu => Driver.FindElement(By.CssSelector("[data-role = 'telerik_ReportViewer_MainMenu']"));

        public WebElement ZoomIn => MainMenu.FindElement(By.CssSelector("li[role='menuitem'][aria-label='Zoom in']"));

        public WebElement ZoomOut => MainMenu.FindElement(By.CssSelector("li[role='menuitem'][aria-label='Zoom out']"));
    }
}
