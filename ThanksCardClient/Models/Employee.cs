using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using Newtonsoft.Json;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class Employee : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */

        #region IdProperty

        private int _Id;

        public int Id
        {
            get
            { return _Id; }
            set
            { 
                if (_Id == value)
                    return;
                _Id = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CDProperty

        private int _CD;

        public int CD
        {
            get
            { return _CD; }
            set
            { 
                if (_CD == value)
                    return;
                _CD = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Name

        private string _Name;
        [JsonProperty("Name")]
        public string Name
        {
            get
            { return _Name; }
            set
            { 
                if (_Name == value)
                    return;
                _Name = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Password

        private string _Password;
        [JsonProperty("Password")]
        public string Password
        {
            get
            { return _Password; }
            set
            { 
                if (_Password == value)
                    return;
                _Password = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Mailaddress

        private string _MailAddress;
        [JsonProperty("MailAddress")]
        public string MailAddress
        {
            get
            { return _MailAddress; }
            set
            { 
                if (_MailAddress == value)
                    return;
                _MailAddress = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region SectionId_FK
        private int _SectionId;

        public int SectionId
        {
            get
            { return _SectionId; }
            set
            { 
                if (_SectionId == value)
                    return;
                _SectionId = value;
                RaisePropertyChanged();
            }
        }

        private Section _Section;

        public Section Section
        {
            get
            { return _Section; }
            set
            { 
                if (_Section == value)
                    return;
                _Section = value;
                RaisePropertyChanged();
            }
        }


        #endregion


        public async Task<Employee> LogonAsync()
        {
            IRestService rest = new RestService();
            Employee authorizedUser = await rest.LogonAsync(this);
            return authorizedUser;
        }

        public async Task<Employee> Logon2Async()
        {
            IRestService rest = new RestService();
            Employee authorizedUser = await rest.Logon2Async(this);
            return authorizedUser;
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            IRestService rest = new RestService();
            List<Employee> employees = await rest.GetEmployeesAsync();
            return employees;
        }

        public async Task<Employee> PostEmployeeAsync(Employee employee)
        {
            IRestService rest = new RestService();
            Employee createdEmployee = await rest.PostEmployeeAsync(employee);
            return createdEmployee;
        }

        public async Task<Employee> PutEmployeeAsync(Employee employee)
        {
            IRestService rest = new RestService();
            Employee updatedEmployee = await rest.PutEmployeeAsync(employee);
            return updatedEmployee;
        }

        public async Task<Employee> DeleteEmployeeAsync(int Id)
        {
            IRestService rest = new RestService();
            Employee deletedEmployee = await rest.DeleteEmployeeAsync(Id);
            return deletedEmployee;
        }

    }
}
