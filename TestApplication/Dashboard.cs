using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace TestApplication
{
    class Dashboard
    {
        public Dashboard()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = "quickjump")]
        public static IWebElement drdAccount { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#tcNewPages>div>main>div>div>div>div:nth-child(1)>div.ant-col-16>div")]
        public IWebElement lblAccountName { get; set; }

        //public SelectElement select = new SelectElement(PropertiesCollection.driver.FindElement(By.Id("quickjump")));

        public void NavigateToAccount(string strAccountName)
        {
            //IWebElement drpDown = PropertiesCollection.driver.FindElement(By.Id("quickjump"));
            //select = new SelectElement(PropertiesCollection.driver.FindElement(By.Id("quickjump")));
            SelectElement select = new SelectElement(PropertiesCollection.driver.FindElement(By.Id("quickjump")));            
            //select.SelectByText(strAccountName);

            select = new SelectElement(PropertiesCollection.driver.FindElement(By.Id("quickjump")));
            IJavaScriptExecutor js = (IJavaScriptExecutor)PropertiesCollection.driver;
            js.ExecuteScript("if($(this).val()){changeUrlLocation($(this).val())}", "");

            select.SelectByText(strAccountName);

            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1500);
            //drdAccount.SendKeys(strAccountName);
            bool bMessage = lblAccountName.Text.Contains(strAccountName);
            //Assert the result page
            //Assert.True(bMessage, "Account still not switched");
        }
    }
}
