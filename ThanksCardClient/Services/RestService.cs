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


        //ログイン関係
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

        
        //社員テーブル編集
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
        public async Task<Employee> PutEmployeeAsync(Employee employee)
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

       
        //部署テーブル編集
        #region GetDepartmentsAsync()
        public async Task<List<Department>> GetDepartmentsAsync()
        {
            List<Department> responseDepartments = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Departments");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartments = JsonConvert.DeserializeObject<List<Department>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetDepartmentsAsync: " + e);
            }
            return responseDepartments;
        }

        #endregion

        #region PostDepartmentAsync(Department department)

        public async Task<Department> PostDepartmentAsync(Department department)
        {
            var jObject = JsonConvert.SerializeObject(department);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Department responseDepartment = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Departments", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartment = JsonConvert.DeserializeObject<Department>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        #endregion

        #region PutDepartmentAsync(Department department)
        public async Task<Department> PutDepartmentAsync(Department department)
        {
            var jObject = JsonConvert.SerializeObject(department);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Department responseDepartment = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Departments/" + department.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartment = JsonConvert.DeserializeObject<Department>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutDepartmentAsync: " + e);
            }
            return responseDepartment;
        }

        #endregion

        #region DeleteDepartmentAsync(int Id)
        public async Task<Department> DeleteDepartmentAsync(int Id)
        {
            Department responseDepartment = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Departments/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseDepartment = JsonConvert.DeserializeObject<Department>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteDepartmentAsync: " + e);
            }
            return responseDepartment;
        }
        #endregion


        //課テーブル編集
        #region SectionsAsync()
        public async Task<List<Section>> GetSectionsAsync()
        {
            List<Section> responseSections = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Sections");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseSections = JsonConvert.DeserializeObject<List<Section>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetSectionsAsync: " + e);
            }
            return responseSections;
        }

        #endregion

        #region PostSectionAsync(Section section)

        public async Task<Section> PostSectionAsync(Section section)
        {
            var jObject = JsonConvert.SerializeObject(section);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Section responseSection = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Sections", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseSection = JsonConvert.DeserializeObject<Section>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostSectionAsync: " + e);
            }
            return responseSection;
        }

        #endregion

        #region PutSectionAsync(Section section)
        public async Task<Section> PutSectionAsync(Section section)
        {
            var jObject = JsonConvert.SerializeObject(section);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Section responseSection = null;
            try
            {
                var response = await Client.PutAsync(this.BaseUrl + "/api/Sections/" + section.Id, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseSection = JsonConvert.DeserializeObject<Section>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PutDepartmentAsync: " + e);
            }
            return responseSection;
        }

        #endregion

        #region DeleteSectionAsync(int Id)
        public async Task<Section> DeleteSectiontAsync(int Id)
        {
            Section responseSection = null;
            try
            {
                var response = await Client.DeleteAsync(this.BaseUrl + "/api/Sections/" + Id);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseSection = JsonConvert.DeserializeObject<Section>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.DeleteSectionAsync: " + e);
            }
            return responseSection;
        }
        #endregion


        //感謝カード作成・読み込み
        #region GetCardsAsync()
        public async Task<List<Card>> GetCardsAsync()
        {
            List<Card> responseCards = null;
            try
            {
                var response = await Client.GetAsync(this.BaseUrl + "/api/Cards");
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseCards = JsonConvert.DeserializeObject<List<Card>>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.GetCardsAsync: " + e);
            }
            return responseCards;
        }
        #endregion

        #region PostCardAsync(Card Card)
        public async Task<Card> PostCardAsync(Card Card)
        {
            var jObject = JsonConvert.SerializeObject(Card);

            //Make Json object into content type
            var content = new StringContent(jObject);
            //Adding header of the contenttype
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            Card responseCard = null;
            try
            {
                var response = await Client.PostAsync(this.BaseUrl + "/api/Cards", content);
                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    responseCard = JsonConvert.DeserializeObject<Card>(responseContent);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("Exception in RestService.PostCardAsync: " + e);
            }
            return responseCard;
        }
        #endregion


    }
}