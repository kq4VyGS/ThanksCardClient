using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;


using ThanksCardClient.Models;
using System.Windows;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class MypageViewModel : ViewModel
    {

        #region 説明書
        /* コマンド、プロパティの定義にはそれぞれ 
         * 
         *  lvcom   : ViewModelCommand
         *  lvcomn  : ViewModelCommand(CanExecute無)
         *  llcom   : ListenerCommand(パラメータ有のコマンド)
         *  llcomn  : ListenerCommand(パラメータ有のコマンド・CanExecute無)
         *  lprop   : 変更通知プロパティ(.NET4.5ではlpropn)
         *  
         * を使用してください。
         * 
         * Modelが十分にリッチであるならコマンドにこだわる必要はありません。
         * View側のコードビハインドを使用しないMVVMパターンの実装を行う場合でも、ViewModelにメソッドを定義し、
         * LivetCallMethodActionなどから直接メソッドを呼び出してください。
         * 
         * ViewModelのコマンドを呼び出せるLivetのすべてのビヘイビア・トリガー・アクションは
         * 同様に直接ViewModelのメソッドを呼び出し可能です。
         */

        /* ViewModelからViewを操作したい場合は、View側のコードビハインド無で処理を行いたい場合は
         * Messengerプロパティからメッセージ(各種InteractionMessage)を発信する事を検討してください。
         */

        /* Modelからの変更通知などの各種イベントを受け取る場合は、PropertyChangedEventListenerや
         * CollectionChangedEventListenerを使うと便利です。各種ListenerはViewModelに定義されている
         * CompositeDisposableプロパティ(LivetCompositeDisposable型)に格納しておく事でイベント解放を容易に行えます。
         * 
         * ReactiveExtensionsなどを併用する場合は、ReactiveExtensionsのCompositeDisposableを
         * ViewModelのCompositeDisposableプロパティに格納しておくのを推奨します。
         * 
         * LivetのWindowテンプレートではViewのウィンドウが閉じる際にDataContextDisposeActionが動作するようになっており、
         * ViewModelのDisposeが呼ばれCompositeDisposableプロパティに格納されたすべてのIDisposable型のインスタンスが解放されます。
         * 
         * ViewModelを使いまわしたい時などは、ViewからDataContextDisposeActionを取り除くか、発動のタイミングをずらす事で対応可能です。
         */

        /* UIDispatcherを操作する場合は、DispatcherHelperのメソッドを操作してください。
         * UIDispatcher自体はApp.xaml.csでインスタンスを確保してあります。
         * 
         * LivetのViewModelではプロパティ変更通知(RaisePropertyChanged)やDispatcherCollectionを使ったコレクション変更通知は
         * 自動的にUIDispatcher上での通知に変換されます。変更通知に際してUIDispatcherを操作する必要はありません。
         */
        #endregion

        //プロパ
        #region LogonEmployeeProperty
        private Employee _AuthorizedEmployee;
        public Employee AuthorizedEmployee
        {
            get
            { return _AuthorizedEmployee; }
            set
            {
                if (_AuthorizedEmployee == value)
                    return;
                _AuthorizedEmployee = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region EmployeesProperty
        private List<Employee> _Employees;
        public List<Employee> Employees
        {
            get
            { return _Employees; }
            set
            {
                if (_Employees == value)
                    return;
                _Employees = value;
                RaisePropertyChanged();
            }
        }

        private List<Department> Departments;
        #endregion
        #region Cards
        private List<Card> _Cards;

        public List<Card> Cards
        {
            get
            { return _Cards; }
            set
            {
                if (_Cards == value)
                    return;
                _Cards = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region SendCards
        private List<Card> _SendCards;

        public List<Card> SendCards
        {
            get
            { return _SendCards; }
            set
            { 
                if (_SendCards == value)
                    return;
                _SendCards = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region  ReceiveCards
        private List<Card> _ReceiveCards;

        public List<Card> ReceiveCards
        {
            get
            { return _ReceiveCards; }
            set
            { 
                if (_ReceiveCards == value)
                    return;
                _ReceiveCards = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region UpdateCard
        private Card _UpdateCard;

        public Card UpdateCard
        {
            get
            { return _UpdateCard; }
            set
            {
                if (_UpdateCard == value)
                    return;
                _UpdateCard = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region DateProperty
        private Card _Date;

        public Card Date
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
        #region AllCards
        private List<Card> _AllCards;

        public List<Card> AllCards
        {
            get
            { return _AllCards; }
            set
            {
                if (_AllCards == value)
                    return;
                _AllCards = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region FavoritesProperty
        private List<Favorite> _Favorites;

        public List<Favorite> Favorites
        {
            get
            { return _Favorites; }
            set
            {
                if (_Favorites == value)
                    return;
                _Favorites = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region FavoriteProperty
        private Favorite _Favorite;

        public Favorite Favorite
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
        #region FavoriteCards
        private List<Favorite> _FavoriteCards;

        public List<Favorite> FavoriteCards
        {
            get
            { return _FavoriteCards; }
            set
            { 
                if (_FavoriteCards == value)
                    return;
                _FavoriteCards = value;
                RaisePropertyChanged();
            }
        }
        #endregion
        #region DeleteFavoriteProperty

        private Favorite _DeleteFavorite;

        public Favorite DeleteFavorite
        {
            get
            { return _DeleteFavorite; }
            set
            {
                if (_DeleteFavorite == value)
                    return;
                _DeleteFavorite = value;
                RaisePropertyChanged();
            }
        }

        #endregion

       

        //コマンド

        #region MainWindowCommand


        private ViewModelCommand _ShowMainWindowCommand;

        public ViewModelCommand ShowMainWindowCommand

        {
            get
            {
                if (_ShowMainWindowCommand == null)
                {
                    _ShowMainWindowCommand = new ViewModelCommand(ShowMainWindow);
                }
                return _ShowMainWindowCommand;
            }
        }

        public void ShowMainWindow()
        {

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
            window.Hide();

            var showmainwindow = new TransitionMessage(typeof(Views.MainWindow), new MainWindowViewModel(), TransitionMode.Modal, "ShowMainWindow");
            Messenger.Raise(showmainwindow);

        }
        #endregion

        #region MypageCommand


        private ViewModelCommand _ShowMypageCommand;

        public ViewModelCommand ShowMypageCommand

        {
            get
            {
                if (_ShowMypageCommand == null)
                {
                    _ShowMypageCommand = new ViewModelCommand(ShowMypage);
                }
                return _ShowMypageCommand;
            }
        }

        public void ShowMypage()
        {

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
            window.Hide();

            var showmypage = new TransitionMessage(typeof(Views.Mypage), new MypageViewModel(), TransitionMode.Modal, "ShowMypage");
            Messenger.Raise(showmypage);

        }
        #endregion

        #region KeizibanCommand


        private ViewModelCommand _ShowKeizibanCommand;

        public ViewModelCommand ShowKeizibanCommand

        {
            get
            {
                if (_ShowKeizibanCommand == null)
                {
                    _ShowKeizibanCommand = new ViewModelCommand(ShowKeiziban);
                }
                return _ShowKeizibanCommand;
            }
        }

        public void ShowKeiziban()
        {

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
            window.Hide();

            var showkeiziban = new TransitionMessage(typeof(Views.Keiziban), new KeizibanViewModel(), TransitionMode.Modal, "ShowKeiziban");
            Messenger.Raise(showkeiziban);

        }
        #endregion

        #region PickupCommand


        private ViewModelCommand _ShowPickupCommand;

        public ViewModelCommand ShowPickupCommand

        {
            get
            {
                if (_ShowPickupCommand == null)
                {
                    _ShowPickupCommand = new ViewModelCommand(ShowPickup);
                }
                return _ShowPickupCommand;
            }
        }

        public void ShowPickup()
        {

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
            window.Hide();

            var showpickup = new TransitionMessage(typeof(Views.Pickup), new PickupViewModel(), TransitionMode.Modal, "ShowPickup");
            Messenger.Raise(showpickup);

        }
        #endregion

        #region ShowBusyoCommand


        private ViewModelCommand _ShowBusyoCommand;

        public ViewModelCommand ShowBusyoCommand

        {
            get
            {
                if (_ShowBusyoCommand == null)
                {
                    _ShowBusyoCommand = new ViewModelCommand(ShowBusyo);
                }
                return _ShowBusyoCommand;
            }
        }

        public void ShowBusyo()
        {

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
            window.Hide();

            var showbusyo = new TransitionMessage(typeof(Views.Busyo), new BusyoViewModel(), TransitionMode.Modal, "ShowBusyo");
            Messenger.Raise(showbusyo);

        }
        #endregion

        #region ShowRankiingCommand


        private ViewModelCommand _ShowRankingCommand;

        public ViewModelCommand ShowRankingCommand

        {
            get
            {
                if (_ShowRankingCommand == null)
                {
                    _ShowRankingCommand = new ViewModelCommand(ShowRanking);
                }
                return _ShowRankingCommand;
            }
        }

        public void ShowRanking()
        {

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
            window.Hide();

            var showranking = new TransitionMessage(typeof(Views.Ranking), new RankingViewModel(), TransitionMode.Modal, "ShowRanking");
            Messenger.Raise(showranking);

        }
        #endregion

        #region ShowKanshaCardCommand


        private ViewModelCommand _ShowKanshaCardCommand;

        public ViewModelCommand ShowKanshaCardCommand

        {
            get
            {
                if (_ShowKanshaCardCommand == null)
                {
                    _ShowKanshaCardCommand = new ViewModelCommand(ShowKanshaCard);
                }
                return _ShowKanshaCardCommand;
            }
        }

        public void ShowKanshaCard()
        {
            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
            //window.Hide();

            var showkanshacard = new TransitionMessage(typeof(Views.KanshaCard), new KanshaCardViewModel(), TransitionMode.Modal, "ShowKanshaCard");
            Messenger.Raise(showkanshacard);


            //var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
            //window.Close();
            //KanshaCardViewModel ViewModel = new KanshaCardViewModel();
            //var message = new TransitionMessage(typeof(Views.KanshaCard), ViewModel, TransitionMode.Modal, "ShowKanshaCard");
            //   var showkanshacard = new TransitionMessage(typeof(Views.KanshaCard), new MainWindowViewModel(), TransitionMode.Modal, "ShowKanshaCard");
            //Messenger.Raise(message);

        }
        #endregion

        #region FavoriteCheck
        private ListenerCommand<int> _FavoriteCheckCommand;

        public ListenerCommand<int> FavoriteCheckCommand
        {
            get
            {
                if (_FavoriteCheckCommand == null)
                {
                    _FavoriteCheckCommand = new ListenerCommand<int>(FavoriteCheck);
                }
                return _FavoriteCheckCommand;
            }
        }

        public async void FavoriteCheck(int cardId)
        {
            this.Favorite = new Favorite();

            this.Favorite.EmployeeId = AuthorizedEmployee.Id;
            this.Favorite.CardId = cardId;
          
            Favorite createfavorite = await Favorite.PostFavoriteAsync(Favorite);
            this.Favorites = await Favorite.GetFavoritesAsync();
        }
        #endregion
        #region FavoriteUnChecked
        private ListenerCommand<int> _FavoriteUnCheckedCommand;

        public ListenerCommand<int> FavoriteUnCheckedCommand
        {
            get
            {
                if (_FavoriteUnCheckedCommand == null)
                {
                    _FavoriteUnCheckedCommand = new ListenerCommand<int>(FavoriteUnChecked);
                }
                return _FavoriteUnCheckedCommand;
            }
        }

        public async void FavoriteUnChecked(int cardId)
        {
            if (Favorites.Any(f => f.CardId == cardId && f.EmployeeId == this.AuthorizedEmployee.Id))
            {
                Favorite Favorite = new Favorite();

                Favorite deletefavorite = await Favorite.DeleteFavoriteAsync(cardId);
                this.Favorites = await Favorite.GetFavoritesAsync();
            }
        }
        #endregion        
        #region MypageFavoriteUnCheckedCommand
        private ListenerCommand<int> _MypageFavoriteUnCheckedCommand;

        public ListenerCommand<int> MypageFavoriteUnCheckedCommand
        {
            get
            {
                if (_MypageFavoriteUnCheckedCommand == null)
                {
                    _MypageFavoriteUnCheckedCommand = new ListenerCommand<int>(MypageFavoriteUnChecked);
                }
                return _MypageFavoriteUnCheckedCommand;
            }
        }

        public async void MypageFavoriteUnChecked(int cardId)
        {
            if (Favorites.Any(f => f.CardId == cardId && f.EmployeeId == this.AuthorizedEmployee.Id))
            {
                this.Favorite = new Favorite();
                this.Favorites = await Favorite.GetFavoritesAsync();

                this.DeleteFavorite = new Favorite();
                this.Favorite.EmployeeId = AuthorizedEmployee.Id;
                this.Favorite.CardId = cardId;

                this.DeleteFavorite = Favorites.Find(f => Favorite.EmployeeId == f.EmployeeId && Favorite.CardId == f.CardId);

                Favorite deletefavorite = await Favorite.DeleteFavoriteAsync(DeleteFavorite.Id);
            }
        }
        #endregion


        //




        public async void Initialize()
        {
            Employee employees = new Employee();
            Department departments = new Department();
            Card card = new Card();
            Favorite favorite = new Favorite();

            //下のやつは、ログイン者のEmployee情報をAuthorizedEMployeeに入れてます。
            this.AuthorizedEmployee = SessionService.Instance.AuthorizedEmployee;
            if (SessionService.Instance.AuthorizedEmployee != null)
            {
                this.Employees = await employees.GetEmployeesAsync();
                this.Departments = await departments.GetDepartmentsAsync();
                this.AllCards = await card.GetCardsAsync();
                this.Favorites = await favorite.GetFavoritesAsync();
            }


            #region FavoriteCards
            this.FavoriteCards = Favorites.Where(f => f.EmployeeId == this.AuthorizedEmployee.Id).ToList() ;
            for (var i = 0; i < FavoriteCards.Count; i++)
            {
                favorite = FavoriteCards.ElementAt(i);
                favorite.Card.Favorite = true;

                FavoriteCards.RemoveAt(i);
                FavoriteCards.Insert(i,favorite);
            }
            #endregion

            #region SendCards
            this.SendCards = AllCards.Where(al => al.From.Id == this.AuthorizedEmployee.Id).ToList();
            for (var i = 0; i < SendCards.Count; i++)
            {
                if (Favorites.Any(f => f.CardId == card.Id && f.EmployeeId == this.AuthorizedEmployee.Id))
                {
                    card = SendCards.ElementAt(i);
                    card.Favorite = true;

                    SendCards.RemoveAt(i);
                    SendCards.Insert(i, card);
                }                
            }
            #endregion

            #region ReceiveCards
            this.ReceiveCards = AllCards.Where(al => al.To.Id == this.AuthorizedEmployee.Id).ToList();
            for (var i = 0; i < ReceiveCards.Count; i++)
            {
                if (Favorites.Any(f => f.CardId == card.Id && f.EmployeeId == this.AuthorizedEmployee.Id))
                {
                    card = ReceiveCards.ElementAt(i);
                    card.Favorite = true;

                    ReceiveCards.RemoveAt(i);
                    ReceiveCards.Insert(i, card);
                }
            }
            #endregion

            var FavoriteCheckCards = new List<Card>();

            for (var i = 0; i < AllCards.Count; i++)
            {
                card = AllCards.ElementAt(i);

                if (Favorites.Any(f => f.CardId == card.Id && f.EmployeeId == this.AuthorizedEmployee.Id))
                {
                    card = AllCards.ElementAt(i);
                    card.Favorite = true;

                    FavoriteCheckCards.Add(card);          
                }
                

            }
            this.Cards = FavoriteCheckCards;
            this.Cards = Cards.OrderBy(ac => ac.Date).ToList();


        }
    }
}
