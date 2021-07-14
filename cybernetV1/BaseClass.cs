using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cybernetV1
{
    class BaseClass
    {
        public static IWebDriver dr;



        public void SelniumDriver()
        {
            var driver = new ChromeDriver();
            dr = driver;
            dr.Manage().Window.Maximize();
            // _ = dr.Manage().Timeouts().ImplicitWait;
        }

        public void Close()
        {
            dr.Close();
            dr.Quit();
            dr.Dispose();
        }
    }
}
