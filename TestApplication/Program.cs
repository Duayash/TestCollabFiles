using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestApplication
{
    class Program
    {
        IWebDriver driver = new ChromeDriver();

        static void Main(string[] args)
        {
        }

        [SetUp]
        public void Initialize()
        {
            
        }

        [Test]
        public void AddTestSuite()
        {
            Console.WriteLine("In Add Test Suite");
        }

        [Test]
        public void AddTestCase()
        {

        }
                
        [Test]
        public void ApplyFilter()
        {

        }

        [TearDown]
        public void CleanUp()
        {
            driver.Close();
        }
    }
}
