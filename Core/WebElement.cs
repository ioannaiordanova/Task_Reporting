using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;

namespace Core
{
    public class WebElement
    {
        private readonly IWebDriver _webDriver;
        private readonly IWebElement _webElement;
        private readonly By _by;


        public WebElement(IWebDriver webDriver, IWebElement webElement, By by)
        {
            _webDriver = webDriver;
            _webElement = webElement;
            _by = by;
        }

        public IWebElement WrappedElement => _webElement;

        public void SetText(string text)
        {
            Debug.WriteLine($"Text {text} is written in element with locator {By}");
            _webElement.Clear();
            _webElement.SendKeys(text);
        }

        public IWebDriver WrappedDriver => _webDriver;

        public By By => _by;

        public string Text => _webElement?.Text;

        public bool? Enabled => _webElement?.Enabled;

        public bool? Displayed => _webElement?.Displayed;

        public Size Size => _webElement.Size;
        public int Width => this.Size.Width;

        public List<WebElement> FindElements(By by)
        {

            var wait = new WebDriverWait(WrappedDriver, TimeSpan.FromSeconds(20));
            ReadOnlyCollection<IWebElement> nativeWebElements =
             wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(new ByChained(_by, by)));

            var elements = new List<WebElement>();
            foreach (var nativeWebElement in nativeWebElements)
            {
                WebElement element = new WebElement(_webDriver, nativeWebElement, new ByChained(_by, by));
                elements.Add(element);
            }

            return elements;
        }


        public WebElement Click()
        {
            ScrollTo();
            WaitToBeClickable(By);
            _webElement?.Click();
            return this;
        }

        
        public WebElement FindElement(By by)
        {
          
            var _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            IWebElement nativeElement =
             _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(new ByChained(_by, by)));

            WebElement element = new WebElement(_webDriver, nativeElement, new ByChained(_by, by));
            return element;
        }

        public string GetAttribute(string attributeName)
        {
            return _webElement?.GetAttribute(attributeName);
        }

        public string GetCssValue(string propertyName)
        {
            return _webElement?.GetCssValue(propertyName);
        }

        private void WaitToBeClickable(By by)
        {
            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));

        }
  
        public void Submit()
        {
            _webElement.Submit();
        }

        public void ScrollTo()
        {
            ((IJavaScriptExecutor)this.WrappedDriver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", _webElement);
        }
    }
}
