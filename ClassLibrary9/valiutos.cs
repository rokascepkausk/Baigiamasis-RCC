using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationProject.TaxPage;
using TestAutomationProject.TaxPages;


namespace TAXLT
{
    public class Valiutos : Method
    {

        driverController controller;


        [SetUp]
        public void SetUp()
        {
            controller = new driverController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.tax.lt/valiutu_kursai";
        }

        [Test]

        public void ValiutosKursoTikrinimasAteitiesDatomis()
        {
            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            ClickButtonByXpath(controller.driver, "//input[@id='rate_date']");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='datepicker dropdown-menu']");
            //valiutu kursu tikrinimas ateities datomis
            ClickButtonByXpath(controller.driver, "//th[@class='next']//i[@class='icon-arrow-right'][1]");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@class='datepicker-days']");

        }

        [Test]

        public void KursuIrasymoLentelesPatikrinimas()

        {
            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");

            CheckIfElementIsPresentByXpath(controller.driver, "//input[@id='currency_text']");
            //Valiutu kursu irasymo lenteles patikrinimas
            SendKeysByXpath(controller.driver, "//input[@id='currency_text']", "PLN");
            CheckIfElementIsPresentByXpath(controller.driver, "//div[@id='currencies_list']//*[contains(text(),'PLN')]");



        }

        [Test]

        public void DatosPatikrinimasMenesiuiAtgal()
        {


            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            //Tikrinamas menesio atgal pasirinkimas
            ClickButtonByXpath(controller.driver, "//input[@id='rate_date']");
            ClickButtonByXpath(controller.driver, "//div[@class='datepicker-days']//i[@class='icon-arrow-left']");
            CheckIfElementIsPresentByXpath(controller.driver,
            "//div[@class='datepicker dropdown-menu']//th[@class='switch' and contains(text(),'Gruodis 2022')]");





        }


        [TearDown]
        public void TearDown()
        {
            tear(controller.driver);
        }
    }
}
