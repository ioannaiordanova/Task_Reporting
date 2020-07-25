using Core;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace SanityTests
{
    public partial class SheetPage : MainMenuPage
    {
        static List<string> ScaleValuesList = new List<string>() { "0.1", "0.25", "0.5", "0.75", "1", "1.5", "2", "4", "8" };
        public Match PageScaling {
            get
            {
                return GetPageScaleMatch();
            } 
        }

       public WebElement Sheet1 => Driver.FindElement(By.CssSelector(".sheet.page1"));
    }
}
