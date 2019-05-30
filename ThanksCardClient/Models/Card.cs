using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;

namespace ThanksCardClient.Models
{
    public class Card : NotificationObject
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

        #region Text

        private string _Text;

        public string Text
        {
            get
            { return _Text; }
            set
            { 
                if (_Text == value)
                    return;
                _Text = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Date

        private DateTime _Date;

        public DateTime Date
        {
            get
            { return _Date; }
            set
            { 
                if (_Date == value)
                    return;
                _Date = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region From_FK

        private Employee _From;

        public Employee From
        {
            get
            { return _From; }
            set
            { 
                if (_From == value)
                    return;
                _From = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region To

        private Employee _To;

        public Employee To
        {
            get
            { return _To; }
            set
            { 
                if (_To == value)
                    return;
                _To = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Title

        private string _Title;

        public string Title
        {
            get
            { return _Title; }
            set
            {
                if (_Title == value)
                    return;
                _Title = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Reply

        private int _Reply;

        public int Reply
        {
            get
            { return _Reply; }
            set
            { 
                if (_Reply == value)
                    return;
                _Reply = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Favorite

        private int _Favorite;

        public int Favorite
        {
            get
            { return _Favorite; }
            set
            { 
                if (_Favorite == value)
                    return;
                _Favorite = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region PickUp

        private int _PickUp;

        public int PickUp
        {
            get
            { return _PickUp; }
            set
            { 
                if (_PickUp == value)
                    return;
                _PickUp = value;
                RaisePropertyChanged();
            }
        }

        #endregion

    }
}
