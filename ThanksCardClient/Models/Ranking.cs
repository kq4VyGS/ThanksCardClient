using Livet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThanksCardClient.Services;

namespace ThanksCardClient.Models
{
    public class Ranking : NotificationObject
    {
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

        #region Rank


        private int _Rank;

        public int Rank
        {
            get
            { return _Rank; }
            set
            { 
                if (_Rank == value)
                    return;
                _Rank = value;
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

        #region Count
        private int _Count;

        public int Count
        {
            get
            { return _Count; }
            set
            { 
                if (_Count == value)
                    return;
                _Count = value;
                RaisePropertyChanged();
            }
        }
        #endregion


    }
}
