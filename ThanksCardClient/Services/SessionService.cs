using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;

namespace ThanksCardClient.Services
{
    public sealed class SessionService
    {
        private static SessionService instance = new SessionService { IsAuthorized = false };

        public Boolean IsAuthorized { set; get; }
        public Employee AuthorizedEmployee { set; get; }

        public static SessionService Instance
        {
            get
            {
                return SessionService.instance;
            }
        }

        private SessionService()
        {
        }
    }
}
