using System;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.StepDefinitions
{
    [Binding]
    public class LoginFeatureValidationStepDefinitions
    {

        Helper hp;
        String ItemPrice;
        String Itemname;
        [BeforeScenario]
        public void setUp()
        { 
        BaseClass.DriverSetUp();
        }

        [Given(@"Enter the Demo user name ""([^""]*)"" and Password ""([^""]*)""")]
        public void GivenEnterTheDemoUserNameAndPassword(string p0, string p1)
        {
            hp = new Helper(BaseClass.driver);
           hp.Login(p0, p1);
        }

        [When(@"user click on Login button")]
        public void WhenUserClickOnLoginButton()
        {
            hp = new Helper(BaseClass.driver);
            hp.ButtonClick("Login");
        }

        [Then(@"User can view List of Products ""([^""]*)""")]
        public void ThenUserCanViewListOfProducts(string pRODUCTS)
        {
            hp = new Helper(BaseClass.driver);
            Boolean flag = hp.Procutsavalability();
            Assert.IsTrue(flag);
        }

        [Then(@"Add First product to Cart")]
        public void ThenAddFirstProductToCart()
        {
            hp = new Helper(BaseClass.driver);
            hp.ButtonClick("AddCart");
            Itemname = hp.getText("ItemName");
            ItemPrice = hp.getText("ItemPrice");
            Assert.AreEqual("REMOVE", hp.getText("Remove"));

        }

        [Then(@"Validate the Item  and Price of product in Cart page")]
        public void ThenValidateTheItemAndPriceOfProductInCartPage()
        {
            hp = new Helper(BaseClass.driver);
            hp.ButtonClick("Shipping");
            String productPrice= hp.getText("ItemPrice");
            String productName= hp.getText("ItemName");
            Assert.AreEqual(Itemname, productName);
            Assert.AreEqual(ItemPrice, productPrice);
        }

        [Then(@"Click on checkout and enter the sample details and click continue")]
        public void ThenClickOnCheckoutAndEnterTheSampleDetailsAndClickContinue()
        {
            hp = new Helper(BaseClass.driver);
            hp.ButtonClick("CheckOut");
            hp.userDetailsEntry();
            hp.ButtonClick("Continue");

        }

        [Then(@"Verify the Item and Price on chekout page and click finish")]
        public void ThenVerifyTheItemAndPriceOnChekoutPageAndClickFinish()
        {
            hp = new Helper(BaseClass.driver);
            hp.ButtonClick("finish");
            String expectedMessage = "THANK YOU FOR YOUR ORDER";
            String successOrder = hp.getText("success");
            Assert.AreEqual(expectedMessage, successOrder);

                
        }

        [AfterScenario]
        public void CleanUp() { 
        BaseClass.driver.Quit();
        }
    }
}
