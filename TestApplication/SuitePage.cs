using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace TestApplication
{
    class SuitePage
    {
        public SuitePage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "SuiteTitle")]
        public IWebElement txtSuiteTitle { get; set; }

        [FindsBy(How = How.Id, Using = "SuiteDescription")]
        public IWebElement txtSuiteDesc { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#model_form_Suite>div.button_set.suite_form_buttons>div>input[type='submit']")]
        public IWebElement btnSave { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#flashMessage")]
        public IWebElement lblMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select2-drop-mask")]
        public IWebElement drpBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#select2-drop>div>input")]
        public IWebElement txtParentSuite { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#s2id_SuiteParentId>a>span")]
        public IWebElement spanName { get; set; }


        public void AddParentSuiteData(string strTitle, string strDesc)
        {
            txtSuiteTitle.SendKeys(strTitle);
            txtSuiteDesc.SendKeys(strDesc);
            btnSave.Click();
            bool bMessage = lblMessage.Text.Contains("Test Suite saved");
            //Assert the result page
            Assert.True(bMessage, "Test suite not created");
        }

        public void AddChildSuiteData(string strTitle, string strDesc, string strParentSuiteName)
        {
            txtSuiteTitle.SendKeys(strTitle);
            txtSuiteDesc.SendKeys(strDesc);
            spanName.Click();
            //drpBox.SendKeys(strParentSuiteName);
            txtParentSuite.SendKeys(strParentSuiteName);
            txtParentSuite.SendKeys(Keys.Enter);
            btnSave.Click();
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            bool bMessage = lblMessage.Text.Contains("Test Suite saved");
            //Assert the result page
            Assert.True(bMessage, "Test suite not created");
        }

    }
}
