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
        Task<Employee> PostEmployeeAsync(Employee employee);
        Task<Employee> PutEmployeeAsync(Employee employee);
        Task<Employee> DeleteEmployeeAsync(int Id);
       

        // Department REST API Client
        Task<List<Department>> GetDepartmentsAsync();
        Task<Department> PostDepartmentAsync(Department department);
        Task<Department> PutDepartmentAsync(Department department);
        Task<Department> DeleteDepartmentAsync(int Id);

        // Section REST API Client
        Task<List<Section>> GetSectionsAsync();
        Task<Section> PostSectionAsync(Section section);
        Task<Section> PutSectionAsync(Section section);
        Task<Section> DeleteSectiontAsync(int Id);


        // TanksCard REST API Client
        Task<List<Card>> GetCardsAsync();
        Task<Card> PostCardAsync(Card Card);

    }
}