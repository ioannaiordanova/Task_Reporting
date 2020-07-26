using Core;

namespace SanityTests
{
    public partial class MainMenuPage : BasePage
    {
        protected override string Url => "http://localhost:44666/";
        public MainMenuPage(WebDriver driver): base(driver) 
        { 
        
        }
    }
}
