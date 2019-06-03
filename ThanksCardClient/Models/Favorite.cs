using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace ThanksCardClient.Models
{
    public class Favorite : NotificationObject
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

        #region Employee_FK
        private int _EmployeeId;

        public int EmployeeId
        {
            get
            { return _EmployeeId; }
            set
            { 
                if (_EmployeeId == value)
                    return;
                _EmployeeId = value;
                RaisePropertyChanged();
            }
        }

        private Employee _Employee;

        public Employee Employee
        {
            get
            { return _Employee; }
            set
            { 
                if (_Employee == value)
                    return;
                _Employee = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Card_Fk
        private int _CardId;

        public int CardId
        {
            get
            { return _CardId; }
            set
            { 
                if (_CardId == value)
                    return;
                _CardId = value;
                RaisePropertyChanged();
            }
        }

        private Card _Card;

        public Card Card
        {
            get
            { return _Card; }
            set
            { 
                if (_Card == value)
                    return;
                _Card = value;
                RaisePropertyChanged();
            }
        }

        #endregion

    }
}
