using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Appium.Service;
//using OpenQA.Selenium.Remote;

namespace Test.Calculator
{
    public class CalculatorNunitTest
    {
        AppiumDriver<IWebElement> _driver;
        AppiumOptions options = new AppiumOptions();
        System.Uri url = new System.Uri("http://127.0.0.1:4723/wd/hub");

        [SetUp]
        public void Setup()
        {

          //Settings to Access Physical Device
            options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "ALE-L21");
            options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "6.0");

         // Settings to Access Emulator
            //options.AddAdditionalCapability(MobileCapabilityType.PlatformName, "Android");
            //options.AddAdditionalCapability(MobileCapabilityType.DeviceName, "Pixel XL (Edited) API 22");
            //options.AddAdditionalCapability(MobileCapabilityType.PlatformVersion, "5.1");

         // Settings to Access Calculator 

            //options.AddAdditionalCapability(MobileCapabilityType.AutomationName, "UiAutomator2");
            //options.AddAdditionalCapability("appPackage", "com.android.calculator2");
            //options.AddAdditionalCapability("appActivity", "com.android.calculator2.Calculator");
        
         //Settings to Access Chrome
            //options.AddAdditionalCapability("appPackage", "com.android.chrome");
            options.AddAdditionalCapability(MobileCapabilityType.BrowserName, "Chrome");
            //options.AddAdditionalCapability(MobileCapabilityType.App, "Browser");
            //options.AddAdditionalCapability("appActivity", "com.android.browser");



        }

        [Test]
        public void LaunchCalculator()
        {
            _driver = new AndroidDriver<IWebElement>(url, options);
           // _driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(60);
            Assert.IsNotNull(_driver.Context);
        }
        [Test]
        public void MultiplicationTest()
        {
            LaunchCalculator();
            
            IWebElement Key9 = _driver.FindElementById("digit9");
            IWebElement Multiply = _driver.FindElementById("mul");
            IWebElement Key7 = _driver.FindElementById("digit7");
            IWebElement Equals = _driver.FindElementById("equal");

            Key9.Click();
            Multiply.Click();
            Key7.Click();
            Equals.Click();
            Assert.AreEqual("63", _driver.FindElementByClassName("android.widget.EditText").Text, " 9 x 7 is not equal 63");
        }

        [Test]
        public void WebTest()
        {
            _driver = new AndroidDriver<IWebElement>(url, options);
            _driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(60);
            Assert.IsNotNull(_driver.Context);
            System.Uri webURL = new System.Uri("http://www.google.com");
            _driver.Navigate().GoToUrl(webURL);
            _driver.FindElementByName("q").SendKeys("try try Again");
            _driver.FindElementByName("btnG").Click();

        }

        [TearDown]
        public void CloseAll()
        {
            _driver.Dispose();
        }
    }
}