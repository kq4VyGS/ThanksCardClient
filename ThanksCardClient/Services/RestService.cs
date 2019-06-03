using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Models;
using Newtonsoft.Json;

namespace ThanksCardClient.Services
{
    class RestService : IRestService
    {
        private HttpClient Client;
        private string BaseUrl;

        public RestService()
        {
            this.Client = new HttpClient();
            this.BaseUrl = "https://localhost:5001";
        }

        #region Logon
        public async Task<Employee> LogonAsync(Employee employee)
        {
            var jObject = JsonConvert.SerializeObject(employee);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Employee responseEmployee = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Logon", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseEmployee = JsonConvert.DeserializeObject<Employee>(responseContent);
                }
            }
            catch (Exception e)
            {
                // TODO
                System.Diagnostics.Debug.WriteLine("Exception in RestService.LogonAsync: " + e);
            }
            return responseEmployee;
        }
        #endregion

        #region Logon2
        public async Task<Employee> Logon2Async(Employee employee)
        {
            var jObject = JsonConvert.SerializeObject(employee);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Employee responseEmployee = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/LogonAdmin", content);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseEmployee = JsonConvert.DeserializeObject<Employee>(responseContent);
                }
            }
            catch (Exception e)
            {
                // TODO
                System.Diagnostics.Debug.WriteLine("Exception in RestService.Logon2Async: " + e);
            }
            return responseEmployee;
        }
        #endregion

        #region Employee

        #region GetEmployeesAsync()
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            List<Employee> responseEmployees = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Employees");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseEmployees = JsonConvert.DeserializeObject<List<Employee>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetEmployeesAsync: " + e);
            }
            return responseEmployees;
        }
        #endregion

        /*
        #region PostEmployeeAsync(Employee employee)
        public async Task<Employee> PostEmployeeAsync(Employee employee)
        {
            var jObject = JsonConvert.SerializeObject(employee);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Employee responseEmployee = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Employees", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseEmployee = JsonConvert.DeserializeObject<Employee>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostEmployeeAsync: " + e);
            }
            return responseEmployee;
        }

        #endregion

        #region PutEmployeeAsync(Employee employee)
        public async Task<Employee> PutUserAsync(Employee employee)
        {
            var jObject = JsonConvert.SerializeObject(employee);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Employee responseEmployee = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Employees/" + employee.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseEmployee = JsonConvert.DeserializeObject<Employee>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutEmployeeAsync: " + e);
            }
            return responseEmployee;
        }
        #endregion

        #region DeleteEmployeeAsync(int Id)
        public async Task<Employee> DeleteEmployeeAsync(int Id)
        {
            Employee responseEmployee = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Employees/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseEmployee = JsonConvert.DeserializeObject<Employee>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteEmployeeAsync: " + e);
            }
            return responseEmployee;
        }
        #endregion
    */
        #endregion

    }
}