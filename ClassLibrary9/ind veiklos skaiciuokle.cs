using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAutomationProject.TaxPage;
using TestAutomationProject.TaxPages;

namespace TAX
{
    public class IndVeiklosSkaiciuokle : Method
    {
        driverController controller;

        [SetUp]
        public void SetUp()
        {
            controller = new driverController();
            controller.driver.Manage().Window.Maximize();
            controller.driver.Url = "https://www.tax.lt/skaiciuokles/individualios_veiklos_mokesciu_skaiciuokle";
        }

        [Test]

        public void GrynoPelnoApskaiciavimas()

        {
            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            //Tikrinama ar suvedus gautas pajamas gaunamas teisingas grynasis pelnas
            CheckIfElementIsPresentByXpath(controller.driver, "//input[@id='pajamos']");
            ClickButtonByXpath(controller.driver, "//input[@id='pajamos']");
            SendKeysByXpath(controller.driver, "//input[@id='pajamos']", "3456");
            CheckIfElementIsPresentByXpath(controller.driver, "//td[@id='grynasis_pelnas_div'][contains(text(),'2 707,00')]");
        }

        [Test]

        public void TikrinamasMygtukuPaspaudimas()

        {
            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            //Tikrinama ar paspaudziamas reikiamas mygtukas "Kaupiu pensijai papildomai"
            ClickButtonByXpath(controller.driver, "//input[@id='papildomas_pensijos_kaupimas']");


        }

        [Test]

        public void TikrinamasMygtukas()

        {
            ClickButtonByXpath(controller.driver, "//button[@aria-label='Sutinku']");
            //Tikrinama ar Sanaudu skaiciavimo skiltyje spaudzia "Faktiskai patirtos" mygtukas
            ClickButtonByXpath(controller.driver, "//input[@id='kaip_skaiciuojamos_sanaudos_1']");


        }



        [TearDown]
        public void TearDown()
        {
            tear(controller.driver);
        }
    }
}
