using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TestAutomationProject.TaxPage;
using TestAutomationProject.TaxPages;

namespace TAXLT
{
    public class Atlyginimai
    {
        public class AtlyginimuTestas : Method
        {
            driverController controller;


            [SetUp]
            public void SetUp()
            {
                controller = new driverController();
                controller.driver.Manage().Window.Maximize();
                controller.driver.Url = "https://www.tax.lt/skaiciuokles/atlyginimo_ir_mokesciu_skaiciuokle";
            }

            [Test]
            public void SkaiciuIvedimas()
            {


                ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
                SendKeysByXpath(controller.driver, "//input[@id='atlyginimas']", "606");
                CheckIfElementIsPresentByXpath(controller.driver, "//td[@id='ant_pop']");


            }

            [Test]
            public void MygtukuPatikra()
            {


                ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
                ClickButtonByXpath(controller.driver, "//label[@class='radio'][1]");
                CheckIfElementIsPresentByXpath(controller.driver, "//*[@id=\"paskaiciuoti_npd_2\"]");


            }
            [Test]
            public void PaieskosPatikra()
            {
                ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
                //Tikrina ar yra laukelis "Ismokamas atlyginimas i rankas"
                CheckIfElementIsPresentByXpath(controller.driver, "//*[@id='calculator_table']");



            }




            [TearDown]
            public void TearDown()
            {
                tear(controller.driver);
            }
        }
    }
}