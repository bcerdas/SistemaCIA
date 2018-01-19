using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaCIA.Models.Services
{
    interface IEmailSender
    {
         string SendEmail(string email, string subject, string message);

    }


}
