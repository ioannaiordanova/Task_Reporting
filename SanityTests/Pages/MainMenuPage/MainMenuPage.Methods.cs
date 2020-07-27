using Core;
using Microsoft.Extensions.Configuration;

namespace SanityTests
{
    public partial class MainMenuPage : BasePage
    {
        public static ConfigurationRoot Config { get; set; }
        protected override string Url => Config["Uri"];
        public MainMenuPage(WebDriver driver): base(driver) 
        {
        }
    }
}
