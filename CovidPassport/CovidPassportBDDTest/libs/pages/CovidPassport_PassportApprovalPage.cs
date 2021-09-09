using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CovidPassportBDDTest.libs.pages
{
    public class CovidPassport_PassportApprovalPage
    {
        public CovidPassport_PassportApprovalPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }
        //Avoid using XPath as the path is relative and may break
        #region Properties
        private string _url => AppConfigReader.ApprovalUrl;
        private IWebElement _approvalLink => Driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr/td[5]/a[1]"));
        private IWebElement _numberOfVaccinesText => Driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr/td[4]"));
        private IWebElement _passportApprovalList => Driver.FindElement(By.XPath("/html/body/div/main/table/tbody"));
        private IWebElement _confirmPassportApprovalButton => Driver.FindElement(By.XPath("/html/body/div/main/div[1]/div/form/div[2]/input"));
        #endregion

        #region Methods
        public void VisitPassportApprovalPage() => Driver.Navigate().GoToUrl(_url);
        public void ClickApprovalLink() => _approvalLink.Click();
        public string GetNumberOfVaccinesText() => _numberOfVaccinesText.Text;
        public int ResultsCount() => _passportApprovalList.ToString().ToList().Count();
        public void ClickConfirmationPassportApprovalLink() => _confirmPassportApprovalButton.Click();
        #endregion
    }
}
