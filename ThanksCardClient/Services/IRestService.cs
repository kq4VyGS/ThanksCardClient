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
        //Logon Rest API Client
        Task<Employee> LogonAsync(Employee employee);
        //管理画面
        Task<Employee> Logon2Async(Employee employee);


        // Employee REST API Client
        Task<List<Employee>> GetEmployeesAsync();
        //Task<Employee> PostEmployeesAsync(Employee employee);
        //Task<Employee> PutEmployeesAsync(Employee employee);
        //Task<Employee> DeleteEmployeesAsync(int Id);
    }
}