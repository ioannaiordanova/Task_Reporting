using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace Core
{
    public class WebElement
    {
        private readonly IWebDriver _webDriver;
        private readonly IWebElement _webElement;
        private readonly By _by;
        private Actions _builder;

        public WebElement(IWebDriver webDriver, IWebElement webElement, By by)
        {
            _webDriver = webDriver;
            _webElement = webElement;
            _by = by;
            _builder = new Actions(_webDriver);
        }

        public IWebElement WrappedElement => _webElement;

        public Actions Builder => _builder;
       

        public void SetText(string text)
        {
            Debug.WriteLine($"Text {text} is weritten in element with locator {By}");
            _webElement.Clear();
            _webElement.SendKeys(text);
        }

        public IWebDriver WrappedDriver => _webDriver;
   

        public By By => _by;

        public string Text => _webElement?.Text;

        public bool? Enabled => _webElement?.Enabled;

        public bool? Displayed => _webElement?.Displayed;

        public List<WebElement> FindElements(By by)
        {

            var wait = new WebDriverWait(WrappedDriver, TimeSpan.FromSeconds(20));
            ReadOnlyCollection<IWebElement> nativeWebElements =
             wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(new ByChained(_by, by)));
             
            var elements = new List<WebElement>();
            foreach (var nativeWebElement in nativeWebElements)
            {
                WebElement element = new WebElement(_webDriver, nativeWebElement, new ByChained(_by,by));
                elements.Add(element);
            }

            return elements;
        }

        public Size Size => _webElement.Size;

        public Point Location => _webElement.Location;

        public int X =>  this.Location.X;

        public int Y => this.Location.Y;

        public int Width => this.Size.Width;

        public int Height => this.Size.Height;

       
       
        public WebElement Click()
        {
            ScrollTo();
            WaitToBeClickable(By);
            _webElement?.Click();
            return this;
        }

        public WebElement MoveByOffset(int x, int y) 
        {
            _builder.ClickAndHold(_webElement) 
                    .MoveByOffset(x, y)
                    .Release();
            return this;
        }

        public WebElement MoveToElement() 
        {
            _builder.MoveToElement(_webElement);
            return this;
        }

        public WebElement ClickAndHold() 
        {
            _builder.ClickAndHold(_webElement);
            return this;
        }

        public Actions DragAndDrop(WebElement element) 
        {
            _builder.DragAndDrop(_webElement, element.WrappedElement)
                      .Perform();
            return _builder;
        }

        public void DragAndDropToOffset(int x, int y) 
        {
            _builder.
                     DragAndDropToOffset(_webElement, x, y)
                     .Release(_webElement)
                     .Perform();
        }

        public Actions MoveListElementOneBelow() 
        {
            _builder
              .DragAndDropToOffset(_webElement, 0, this.Height + 10)
              .Release(_webElement)
              .Perform();
               return _builder;
        }

        public void MoveToElement(WebElement element) 
        {
            _builder
                   .ClickAndHold(_webElement)
                   .MoveToElement(element.WrappedElement)
                   .Click()
                   .Perform();

        }

        public void Perform() {
            _builder.Perform();     
        }

        public WebElement FindElement(By by)
        {
            IWebElement nativeElement = _webElement.FindElement(by);
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
