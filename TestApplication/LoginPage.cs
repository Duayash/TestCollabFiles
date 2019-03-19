using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.PageObjects;

namespace TestApplication
{
    class LoginPage
    {
        
        public LoginPage()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How=How.Id, Using = "UserEmail")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "UserPassword")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#main_login_form>div.submit>input[type='submit']")]
        public IWebElement btnLogin { get; set; }

        public Dashboard Login(string strEmail, string strPass)
        {
            txtEmail.SendKeys(strEmail);
            txtPassword.SendKeys(strPass);

            btnLogin.Click();
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);

            return new Dashboard();
        }

    }
}
