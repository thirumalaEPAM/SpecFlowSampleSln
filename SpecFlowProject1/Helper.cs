using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1
{
   
    public class Helper
    {
        ObjectRepository ob;

        IWebDriver webdriver;

        public void Login(String uname,String pwd) {
            ob = new ObjectRepository(webdriver);
            ob.SendText(ob.eltUsename,uname);
            ob.SendText(ob.eltPassword,pwd);         
        
        }

        public void LoginButtonClick() {
            ob = new ObjectRepository(webdriver);
            ob.ClickElement(ob.eltLogin);
        }

        public void AddCartButtonClick() {
            ob = new ObjectRepository(webdriver);
            ob.ClickElement(ob.eltAddCart);
        }

        public void ButtonClick(String buttonName)
        {
            ob = new ObjectRepository(webdriver);
            if (buttonName == "Login")
                ob.ClickElement(ob.eltLogin);
            else if (buttonName == "AddCart") { ob.ClickElement(ob.eltAddCart); }
            else if (buttonName == "Shipping") { ob.ClickElement(ob.eltShippingCart); }
            else if (buttonName == "CheckOut") { ob.ClickElement(ob.eltCheckOut); }
            else if (buttonName == "Continue") { ob.ClickElement(ob.eltContinueBtn); }
            else if (buttonName == "finish") {
                ob.pageScroll(ob.eltFinish);
                ob.ClickElement(ob.eltFinish); }
            else { Console.WriteLine("button not existed"); }

        }
        public Boolean Procutsavalability()
        {
            ob = new ObjectRepository(webdriver);
            int PCount = ob.getNumProdcts(ob.eltItemName);
            if (PCount != 0) return true;
            else return false;
        }

        public void userDetailsEntry() {
            ob = new ObjectRepository(webdriver);
            ob.SendText(ob.eltFirstName, "Thirumala");
            ob.SendText(ob.eltLastName, "Rajolu");
            ob.SendText(ob.eltZipCode, "500090");
        }
        public String getText(string text)
        {
            ob = new ObjectRepository(webdriver);

            if(text == "Remove")
                return ob.getElementText(ob.eltRemoveCart);
            else if(text == "Remove") { return ob.getElementText(ob.eltRemoveCart); }
            else if (text == "ItemPrice") { return ob.getElementText(ob.eltItemPrice); }
            else if (text == "ItemName") { return ob.getElementText(ob.eltItemName); }
            else { return ob.getElementText(ob.eltCompleteOrder); }
        }
            public Helper(IWebDriver driver) { 
        this.webdriver = driver;
        }
    }
}
