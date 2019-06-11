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
    public class KeizibanViewModel : ViewModel
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

        //プロパティ
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
        #region Favorite
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

        //ページ遷移コマンド
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
            window.Hide();

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
            this.UpdateCard = AllCards.Find(al => cardId == al.Id);
           // this.UpdateCard.Favorite = true;
            Card card = await UpdateCard.PutCardAsync(this.UpdateCard);
            this.AllCards = await UpdateCard.GetCardsAsync();
            

            this.Favorite.EmployeeId = AuthorizedEmployee.Id;
            this.Favorite.CardId = cardId;           

            Favorite createfavorite = await Favorite.PostFavoriteAsync(Favorite);
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
            this.UpdateCard = AllCards.Find(al => cardId == al.Id);
            //this.UpdateCard.Favorite = false;
            Card card = await UpdateCard.PutCardAsync(this.UpdateCard);
          

            Favorite favorite = new Favorite();
            this.Favorites = await favorite.GetFavoritesAsync();

            this.DeleteFavorite = new Favorite();
            this.Favorite.EmployeeId = AuthorizedEmployee.Id;
            this.Favorite.CardId = cardId;

            this.DeleteFavorite = Favorites.Find(f => Favorite.EmployeeId == f.EmployeeId && Favorite.CardId == f.CardId);

            Favorite deletefavorite = await Favorite.DeleteFavoriteAsync(DeleteFavorite.Id);
        }
        #endregion
        #region PickUpCheckCommand
        private ListenerCommand<int> _PickUpCheckCommand;

        public ListenerCommand<int> PickUpCheckCommand
        {
            get
            {
                if (_PickUpCheckCommand == null)
                {
                    _PickUpCheckCommand = new ListenerCommand<int>(PickUpCheck);
                }
                return _PickUpCheckCommand;
            }
        }

        public async void PickUpCheck(int cardId)
        {
            this.UpdateCard = AllCards.Find(al => cardId == al.Id);
            this.UpdateCard.PickUp = true;
            Card card = await UpdateCard.PutCardAsync(this.UpdateCard);
            //this.AllCards = await UpdateCard.GetCardsAsync();
        }
        #endregion
        #region PickUpUnCheckedCommand
        private ListenerCommand<int> _PickUpUnCheckedCommand;

        public ListenerCommand<int> PickUpUnCheckedCommand
        {
            get
            {
                if (_PickUpUnCheckedCommand == null)
                {
                    _PickUpUnCheckedCommand = new ListenerCommand<int>(PickUpUnChecked);
                }
                return _PickUpUnCheckedCommand;
            }
        }

        public async void PickUpUnChecked(int cardId)
        {
            this.UpdateCard = AllCards.Find(al => cardId == al.Id);
            this.UpdateCard.PickUp = false;
            Card card = await UpdateCard.PutCardAsync(this.UpdateCard);         
        }
        #endregion
        #region ShowRefineCardsCommand
        private ViewModelCommand _ShowRefineCardsCommand;

        public ViewModelCommand ShowRefineCardsCommand
        {
            get
            {
                if (_ShowRefineCardsCommand == null)
                {
                    _ShowRefineCardsCommand = new ViewModelCommand(ShowRefineCards);
                }
                return _ShowRefineCardsCommand;
            }
        }

        public void ShowRefineCards()
        {
            this.Cards = AllCards.Where(ac => ac.Date.Date == this.Date.Date).ToList();
        }
        #endregion

        public async void Initialize()
        {
            this.Date= new Card();
            this.Date.Date = this.Date.Date.Date;
            this.Favorite = new Favorite();

            Card card = new Card();
            this.AllCards = await card.GetCardsAsync();
            this.AllCards = AllCards.OrderBy(ac => ac.Date).ToList();
           


            this.Cards = AllCards;
            this.AuthorizedEmployee = SessionService.Instance.AuthorizedEmployee;
        }
    }
}
