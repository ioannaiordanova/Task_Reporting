using NUnit.Framework;
using System;

namespace SanityTests
{
  public partial class SearchForm : BasePage
    {
        [Obsolete]
        public void AssertSearchResult(int _occurencies)
        {
            WaitUntilCountOccurencies();
            Assert.AreEqual(ResultMessage + $"{_occurencies}", SearchResultLabel.Text);
        }
    }
}
