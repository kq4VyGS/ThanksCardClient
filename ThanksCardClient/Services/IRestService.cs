using ThanksCardClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanksCardClient.Services
{
    interface IRestService
    {
        Task<Employee> LogonAsync(Employee employee);
    }
}