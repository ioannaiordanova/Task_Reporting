using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Extentions
{
    public static class ElementExtentions
    {
        public static bool isVisibleInViewport(this WebElement element)
        {

            return (bool)((IJavaScriptExecutor)element.WrappedDriver).ExecuteScript(
                "var elem = arguments[0],                 " +
                "  box = elem.getBoundingClientRect(),    " +
                "  cx = box.left + box.width / 2,         " +
                "  cy = box.top + box.height / 2,         " +
                "  e = document.elementFromPoint(cx, cy); " +
                "for (; e; e = e.parentElement) {         " +
                "  if (e === elem)                        " +
                "    return true;                         " +
                "}                                        " +
                "return false;                            "
                , element.WrappedElement);
        }
    }
}

