using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1
{
    public class BaseClass
    {

        public static IWebDriver driver=null;
        private BaseClass() { }
        public static void DriverSetUp()
        {
            if (driver == null)
            {
                driver = new ChromeDriver();
               
            }
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(5);
        }

        

    }
}
