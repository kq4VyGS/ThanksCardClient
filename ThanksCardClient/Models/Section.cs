using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

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

        #region Department

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

    }
}
