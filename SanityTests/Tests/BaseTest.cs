using Core;
using NUnit.Framework;

namespace SanityTests
{
    [TestFixture]
    public class BaseTest
    {
        public WebDriver Driver { get; set; }

        public void Initialize()
        {
            Driver = new WebDriver();
            Driver.Start(Browser.Chrome);
        }
    }
}
