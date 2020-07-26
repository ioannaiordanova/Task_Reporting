### Automation tests for HTML5 Report Viewer

#### WebApplicationTelerikReporting is the  ASP.NET Web Application (.NET Framework) with the HTML5 Report Viewer Page. As a template I have used Product Line Sales.trdp


#### Core project has classes that wrap IWebDriver and IWebElement classes. It's an implementation of Decorator pattern.  

#### SanityTests Project is the project with the AU tests.

**The Project Structure:**

![ProjectStructure](https://user-images.githubusercontent.com/35447819/88487932-3afc2780-cf92-11ea-9970-150818a31903.png)

**Tests included:**
* ZoomIn - Clicks on the ZoomIn Button on the main menu and checks style: scale values based on the previous values.
* ZoomOut -  Clicks on the ZoomOut Button on the main menu and checks style: scale values based on the previous values.
* ParametersAreaExists - Asserts that initially the Parameters Area exsists
* ParametersAreaNotExists_WhenToggleButtonCliked - After asserting that initally the Parameters Area exists then click on the Toggle button and then assert that Parameter Area does not exists
* TrialOnScreen_WhenToggle_FullPage_Cliked - Asserts that Trial part of the report which is its footer is on the viewpoint when click on ToggleFullPage button.One click on the button and it works in FullPage mode.
* TrialOnScreen_WhenToggle_PageWidth_Cliked - The prevoius test checked the FullPage Mode of the Toggle Button. Now in this test we clicked on the button twice so to work in PageWidth Mode. Then we assert the width of the report against the width of its container.
* SelectSingleOptionTest - Selects one of the main options and assert two things: 
  * Assert the Selected Category in the Parameter Area 
  * Assert the header of the report contains the selected option
* BackButtonTest - here we select consecutively two of the main option so that the button Back to became enabled.Then click on the Back button and assert that we are on the firstly selected option.
* NextButtonTest - this is like the prevois test but somewhat modified. Again we select consecutively two main options and select the back button so the Next button became enabled. Then we click on the Next button and assert if the currenly selected option is the second we have choosen.
* SearchInReportContentTest - this test the Find functionality and assert that we have found a predefined number of occurencies of predefined word with predefined settings.

