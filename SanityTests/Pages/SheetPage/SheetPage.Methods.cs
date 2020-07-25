using Core;
using System.Text.RegularExpressions;

namespace SanityTests
{
    public partial class SheetPage : MainMenuPage 
    {
        public SheetPage(WebDriver driver) : base(driver)
        {
           
        }

        public string GetNextScaling()
        {
           return ScaleValuesList[GetNextScalingIndex()];
        }


        public int GetNextScalingIndex()
        {
            return (ScaleValuesList.Count == (ScaleValuesList.IndexOf(GetPageScaleValue()) + 1)) ?
                ScaleValuesList.IndexOf(GetPageScaleValue())
            :
                ScaleValuesList.IndexOf(GetPageScaleValue()) + 1;
        }

        public int GetScalingIndex()
        {
            return ScaleValuesList.IndexOf(GetPageScaleValue());
        }

        public Match GetPageScaleMatch()
        {
            return  Regex.Match(Sheet1.GetAttribute("style"), @"\w*\s*scale\((.*),\s(.*)\).*");
        }

        public string GetPageScaleValue()
        {
            return GetPageScaleMatch().Groups[1].Value;
        }
    }
}
