using Core;
using NUnit.Framework;
using OpenQA.Selenium;

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
