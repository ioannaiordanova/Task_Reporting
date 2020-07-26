using NUnit.Framework;

namespace SanityTests
{
    public partial class SearchForm : BasePage
    {
        public void AssertSearchResult(int _occurencies)
        {
            Assert.AreEqual(ResultMessage + $"{_occurencies}", SearchResultLabel.Text);
        }
    }
}
