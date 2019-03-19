using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SpecFlow.Assist.Dynamic;
using TechTalk.SpecFlow.Assist;


namespace TestApplication
{
    [Binding]
    public sealed class TestUIStepDefinition
    {
        Dashboard objDashboard;
        SuitePage objSuitePage;

        [Given(@"User logs in with crediantials")]
        public void GivenUserLogsInWithCrediantials(Table table)
        {
            string LoginId = String.Empty, password = String.Empty;
            
            var tblService = table.CreateDynamicSet();
            foreach (var data in tblService)
            {
                LoginId = data.LoginId;
                password = Convert.ToString(data.Password);
            }

            LoginPage objLogin = new LoginPage();
            objDashboard = objLogin.Login(LoginId, password);
           
        }

        [Given(@"Switches to Account")]
        public void GivenSwitchesToAccount(Table table)
        {
            string strAccountName = String.Empty;

            var tblService = table.CreateDynamicSet();
            foreach (var data in tblService)
            {
                strAccountName = data.Account;
            }

            objDashboard.NavigateToAccount(strAccountName);
            
            //Assert
        }


        [Given(@"User Clicks on Test Cases and then on Add Suite")]
        public void GivenUserClicksOnTestCasesAndAddSuite()
        {
            TestCasePage objTestCasePage = new TestCasePage();
            objTestCasePage.ClickTestCases();
            PropertiesCollection.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(1000);
            objSuitePage = objTestCasePage.AddSuite();
            //Assert
        }

       
        [Then(@"User adds the Suite with (.*) and (.*)")]
        public void ThenUserAddsTheSuite(string title, string desc)
        {
            objSuitePage.AddParentSuiteData(title, desc);
        }

        [Then(@"User adds child Suite with (.*), (.*) and (.*)")]
        public void ThenUserAddsChildSuite(string strTitle, string strDesc, string strParentName)
        {
            objSuitePage.AddChildSuiteData(strTitle, strDesc, strParentName);
        }

        [Given(@"User Clicks on Test Cases blue button and add details with (.*) and (.*)")]
        public void GivenUserClicksOnTestCasesBlueButton(string strTitle, string strSuiteName)
        {
            TestCasePage objTestCasePage = new TestCasePage();
            objTestCasePage.ClickTestCases();
            objTestCasePage.AddTestCase(strTitle, strSuiteName);
        }

        [Given(@"Using Tag Filter search the Test Case List using title (.*) and priority (.*)")]
        public void TagFilterUsingTitleAndPriority(string title, string priority)
        {
            TestCasePage objTestCasePage = new TestCasePage();
            objTestCasePage.SearchTestCases(title, priority);
        }




    }
}
