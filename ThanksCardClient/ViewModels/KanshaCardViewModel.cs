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
using ThanksCardClient.Services;
using System.Windows;

namespace ThanksCardClient.ViewModels
{
    public class KanshaCardViewModel : ViewModel
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
        #endregion

        #region ThanksCardProperty
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


        //コマンド
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

        //
        public async void Initialize()
        {
            
            Employee employee = new Employee();
            this.Employees = await employee.GetEmployeesAsync();

            this.AuthorizedEmployee = SessionService.Instance.AuthorizedEmployee;
            /*
            if (SessionService.Instance.AuthorizedEmployee != null)
            {
                this.Employees = await SessionService.Instance.AuthorizedEmployee.GetEmployeesAsync();
            }
            */
        }

        #region SubmitCommand
        private ViewModelCommand _SubmitCommand;
        
        public ViewModelCommand SubmitCommand
        {
            get
            {
                if (_SubmitCommand == null)
                {
                    _SubmitCommand = new ViewModelCommand(Submit);
                }
                return _SubmitCommand;
            }
        }

        public async void Submit()
        {
            Card createdThanksCard = await Card.PostCardAsync(this.Card);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Created"));
        }
        #endregion
    }
}
