using NUnit.Framework;
using System.Text.RegularExpressions;

namespace SanityTests
{
    public partial class SheetPage : MainMenuPage
    {
        public void AssertPageScale(string expectedSaclingIndex)
        {
            Assert.AreEqual(expectedSaclingIndex, GetPageScaleValue());
            Assert.AreEqual(expectedSaclingIndex, GetPageScaleValue());
        }
    }
}
