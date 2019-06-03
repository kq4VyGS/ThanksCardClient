using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class Section : NotificationObject
    {
        /*
         * NotificationObjectはプロパティ変更通知の仕組みを実装したオブジェクトです。
         */

        #region Id

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

        #region CD

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

        #region Department_FK
        private int _DepartmentId;

        public int DepartmentId
        {
            get
            { return _DepartmentId; }
            set
            { 
                if (_DepartmentId == value)
                    return;
                _DepartmentId = value;
                RaisePropertyChanged();
            }
        }

        private Department _Department;

        public Department Department
        {
            get
            { return _Department; }
            set
            { 
                if (_Department == value)
                    return;
                _Department = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        public async Task<List<Section>> GetSectionsAsync()
        {
            IRestService rest = new RestService();
            List<Section> Sections = await rest.GetSectionsAsync();
            return Sections;
        }

        public async Task<Section> PostSectionAsync(Section section)
        {
            IRestService rest = new RestService();
            Section createdSection = await rest.PostSectionAsync(section);
            return createdSection;
        }

        public async Task<Section> PutSectionAsync(Section section)
        {
            IRestService rest = new RestService();
            Section updatedSection = await rest.PutSectionAsync(section);
            return updatedSection;
        }

        public async Task<Section> DeleteSectionAsync(int Id)
        {
            IRestService rest = new RestService();
            Section deletedSection = await rest.DeleteSectiontAsync(Id);
            return deletedSection;
        }

    }
}
