using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace CovidPassportBDDTest
{
    public static class AppConfigReader
    {
        public static readonly string BaseUrl = ConfigurationManager.AppSettings["base_url"];
        public static readonly string LocationUrl = ConfigurationManager.AppSettings["location_url"];
        public static readonly string PassportUrl = ConfigurationManager.AppSettings["passport_url"];
        public static readonly string ApprovalUrl = ConfigurationManager.AppSettings["approval_url"];
        public static readonly string PersonUrl = ConfigurationManager.AppSettings["person_url"];
        public static readonly string AddressUrl = ConfigurationManager.AppSettings["address_url"];
        public static readonly string PrivacyUrl = ConfigurationManager.AppSettings["privacy_url"];
    }
}
