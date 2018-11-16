
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace InfoCollecte
{
    [TestFixture]
    [Parallelizable]
    public class InfoCollecte
    {
        private IWebDriver webDriver;

        [SetUp]
        public void Init()
        {
            webDriver = new ChromeDriver();
        }

        [Test]
        public void Test_Acces_InfoCollecte()
        {
            webDriver.Url = "https://www.ville.quebec.qc.ca/";
            IWebElement lnkCitoyen = webDriver.FindElement(By.XPath("//*[@id='menu-principal']/li/a"));
            lnkCitoyen.Click();
            IWebElement lnkMR = webDriver.FindElement(By.ClassName("matieres-residuelles"));
            lnkMR.Click();
            IWebElement lnkIC = webDriver.FindElement(By.XPath("//*[@id='list_menugauche']/li[9]/ul/li[9]/a"));
            lnkIC.Click();
            IWebElement txtAdresse = webDriver.FindElement(By.Id("ctl00_ctl00_contenu_texte_page_ucInfoCollecteRechercheAdresse_RechercheAdresse_txtNomRue"));
            txtAdresse.SendKeys("1130 route de l'église");
            IWebElement btnRecherche = webDriver.FindElement(By.Id("ctl00_ctl00_contenu_texte_page_ucInfoCollecteRechercheAdresse_RechercheAdresse_BtnRue"));
            btnRecherche.Click();
            IWebElement lnkPDF = webDriver.FindElement(By.Id("ctl00_ctl00_contenu_texte_page_ucInfoCollecteAfficherResultats_lnkPDF"));
        }

        [TearDown]
        public void Dispose()
        {
            webDriver.Quit();
        }
    }
}