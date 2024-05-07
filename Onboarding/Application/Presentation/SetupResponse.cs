using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Presentation
{
    public class SetupResponse
    {
        public string BusinessName { get; set; }
        public string BusinessId { get; set; } //Tenant Id
        public string BusinessLogo { get; set; }
        public string BusinessLogoUrl { get; set; }
        public string BusinessColorCode { get; set; }
    }
}
