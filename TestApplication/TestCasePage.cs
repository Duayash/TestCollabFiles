using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestApplication
{
    class TestCasePage
    {
        public TestCasePage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "#test_suite_cases_tab")]
        public IWebElement tabTestCases { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main-nav>li:nth-child(2)>ul>li:nth-child(2)>a")]
        public IWebElement tabSuite { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#testCaseManage>div>div.ant-layout>div>div>div>div.ant-table-wrapper>div>div>div>div>div.ant-table-footer>div>button")]
        public IWebElement btnTestCase { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#title")]
        public IWebElement txtTitle { get; set; }

        //[FindsBy(How = How.CssSelector, Using = "#testCaseManage > div > div.ant-layout > div > div > div > div.ant-table-wrapper > div > div > div > div > div.ant-table-footer > div > div > form > div > div.ant-col-6.gutter-row > div > div > div > div > span > span > span.ant-select-selection__rendered > span")]
        //public IWebElement drpTestSuite { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='testCaseManage']/div/div[2]/div/div/div/div[2]/div/div/div/div/div[2]/div/div/form/div/div[2]/div/div/div/div/span/span/span[1]/span")]
        public IWebElement drpTestSuite { get; set; }

        [FindsBy(How = How.CssSelector, Using = "body > div:nth-child(15) > div > div > div > ul")]
        public IWebElement drpList { get; set; }

        

        [FindsBy(How = How.XPath, Using = "//*[@id='testCaseManage']/div/div[2]/div/div/div/div[2]/div/div/div/div/div[2]/div/div/form/div/div[4]/div/div/div/button[1]")]
        public IWebElement btnSaveTestCase { get; set; }

        public SelectElement select { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='testCaseManage']/div/div[2]/div/div/div/div[1]/div[1]/div/div/a")]
        public IWebElement btnAddFilter { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[10]/div/div/div/div[2]/div/div/div/div/div/span/input")]
        public IWebElement txtSearchTitle { get; set; }

        [FindsBy(How = How.XPath, Using = "/html/body/div[10]/div/div/div/div[2]/div/div/div/div/div/center/button")]
        public IWebElement btnDone { get; set; }

        [FindsBy(How = How.XPath, Using = "body > div > div > div > div > div.ant-popover-inner > div > div > div > div > div > div > div > div > div")]
        public IWebElement txtPriority { get; set; }

        




        public void ClickTestCases()
        {
            tabTestCases.Click();
        }

        public SuitePage AddSuite()
        {
            tabSuite.Click();

            return new SuitePage();
        }

        public void AddTestCase(string strTitle, string strTestSuite)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)PropertiesCollection.driver;
            js.ExecuteScript("window.scrollBy(250,0)", "");

            btnTestCase.Click();
            txtTitle.SendKeys(strTitle);

            //drpTestSuite.Click();
            drpTestSuite.Click();

            IList<IWebElement> elements = PropertiesCollection.driver.FindElements(By.CssSelector("body > div > div > div > div > ul > li"));
            foreach (IWebElement elem in elements)
            {
                String temp = elem.Text;
                if (temp.Equals(strTestSuite))
                {
                    elem.Click();
                    break;
                }
            }

            btnSaveTestCase.Click();
        }

        public void SearchTestCases(string title, string priority)
        {
            ClickTestCases();

            btnAddFilter.Click();
            const string strTitle = "Test Case Title";
            const string strPriority = "Priority";

            IList<IWebElement> elements = PropertiesCollection.driver.FindElements(By.CssSelector("body > div > div > div > div > div.ant-popover-inner > div > div > div"));
            foreach (IWebElement elem in elements)
            {
                String temp = elem.Text;

                if (temp.Equals(strTitle))
                {
                    elem.Click();
                    txtSearchTitle.Click();
                    txtSearchTitle.SendKeys(title);
                    btnDone.Click();
                    break;
                }
            }

            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);

            foreach (IWebElement elem in elements)
            {
                String temp = elem.Text;

                if (temp.Equals(strPriority))
                {
                    elem.Click();

                    txtPriority.Click();
                    txtPriority.SendKeys(priority);
                    txtPriority.SendKeys(Keys.Enter);
                    txtPriority.SendKeys(Keys.Tab);
                    btnDone.Click();

                    //IList<IWebElement> priorityItems = PropertiesCollection.driver.FindElements(By.CssSelector("body > div > div > div > div > ul > li"));
                    break;
                }
            }

            //Check the results table if it contains the title text and having priority as per the test data
            //Function to check the data in the table

        }
    }
}
