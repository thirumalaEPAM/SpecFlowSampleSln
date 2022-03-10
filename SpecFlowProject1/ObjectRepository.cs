using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1
{
    public class ObjectRepository
    {
        public IWebDriver _driver;

        public By eltUsename = By.Id("user-name");
        public By eltPassword = By.Id("password");
        public By eltLogin = By.Id("login-button");
        public By eltItemPrice = By.XPath("//div[@class='inventory_item_price']");
        public By eltItemName = By.XPath("//div[@class='inventory_item_name']");
        public By eltAddCart = By.XPath("//div[@class='inventory_item_price']//following-sibling::button");
        public By eltRemoveCart = By.XPath("//button[text()='Remove']");
        public By eltShippingCart = By.XPath("//a[@class='shopping_cart_link']");
        public By eltContinueShipping = By.Id("continue-shopping");

        /** Checkout data**/
        public By eltCheckOut = By.Id("checkout");
        public By eltFirstName = By.Id("first-name");
        public By eltLastName = By.Name("lastName");
        public By eltZipCode= By.Name("postalCode");
        public By eltContinueBtn = By.Id("continue");
        public By eltFinish = By.Id("finish");
        public By eltCompleteOrder = By.XPath("//h2[@class='complete-header']");
        //THANK YOU FOR YOUR ORDER

        public IWebElement WaitForElement(By elt) { 
        
            WebDriverWait wait =new WebDriverWait(_driver,TimeSpan.FromSeconds(5));
           return  wait.Until(X=>X.FindElement(elt));
        }

        public String getElementText(By elt) {

            return WaitForElement(elt).Text.ToString();
        }

        public void  SendText(By elt,String text) { 
            
            WaitForElement(elt).SendKeys(text);       
            
        }

        public int getNumProdcts(By elt)
        {
            ReadOnlyCollection<IWebElement> prodcts = _driver.FindElements(elt);

            int Count=prodcts.Count();
            return Count;
        }
       
        public void ClickElement(By elt) { 
        WaitForElement(elt).Click();
        }

        public void pageScroll(By elt) {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollBy(0, 250)", "");


        }
        public ObjectRepository(IWebDriver driver) { 
            this._driver=driver;
        
        }
    }
}
