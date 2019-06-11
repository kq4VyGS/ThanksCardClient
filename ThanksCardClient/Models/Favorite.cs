using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livet;
using ThanksCardClient.Services;

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

        #region FavoriteCheck
        private bool _FavoriteCheck;

        public bool FavoriteCheck
        {
            get
            { return _FavoriteCheck; }
            set
            { 
                if (_FavoriteCheck == value)
                    return;
                _FavoriteCheck = value;
                RaisePropertyChanged();
            }
        }
        #endregion



        public async Task<List<Favorite>> GetFavoritesAsync()
        {
            IRestService rest = new RestService();
            List<Favorite> favorites = await rest.GetFavoritesAsync();
            return favorites;
        }

        public async Task<Favorite> PostFavoriteAsync(Favorite favorite)
        {
            IRestService rest = new RestService();
            Favorite createdFavorite = await rest.PostFavoriteAsync(favorite);
            return createdFavorite;
        }

        public async Task<Favorite> PutFavoriteAsync(Favorite favorite)
        {
            IRestService rest = new RestService();
            Favorite updatedFavorite = await rest.PutFavoriteAsync(favorite);
            return updatedFavorite;
        }

        public async Task<Favorite> DeleteFavoriteAsync(int Id)
        {
            IRestService rest = new RestService();
            Favorite deletedFavorite = await rest.DeleteFavoriteAsync(Id);
            return deletedFavorite;
        }

    }
}
