using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.MvcWebUI.Services
{
    public class EmailMessage
    {
        public EmailMessage()
        {
            ToAdresses = new List<EmailAdress>();
            FromAdresses = new List<EmailAdress>();
        }

        public List<EmailAdress> ToAdresses { get; set; }
        public List<EmailAdress> FromAdresses { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
    }
}
