using Core;
using OpenQA.Selenium;

namespace SanityTests
{
    public partial class MainMenuPage : BasePage
    {
        public WebElement MainMenu => Driver.FindElement(By.CssSelector("[data-role = 'telerik_ReportViewer_MainMenu']"));

        public WebElement ZoomIn => MainMenu.FindElement(By.CssSelector("li[role='menuitem'][aria-label='Zoom in']"));

        public WebElement ZoomOut => MainMenu.FindElement(By.CssSelector("li[role='menuitem'][aria-label='Zoom out']"));

        public WebElement ToggleParameterButton => MainMenu.FindElement(By.CssSelector("li[role='menuitem'][aria-label='Toggle parameters area']"));

        public WebElement BackButton => MainMenu.FindElement(By.CssSelector("li[role='menuitem'][aria-label$='backward']"));

        public WebElement NextButton => MainMenu.FindElement(By.CssSelector("li[role='menuitem'][aria-label$='forward']"));

        public WebElement SearchButton => MainMenu.FindElement(By.CssSelector("li[role='menuitem'][aria-label^='Search'"));

        public WebElement MessageBox => Driver.FindElement(By.ClassName("trv-error-pane"));
    }
}
