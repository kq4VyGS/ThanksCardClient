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
    public class MainWindowViewModel : ViewModel
    {
        #region EmployeeProperty
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

        #region LogonCommand
        private ViewModelCommand _LogonCommand;

        public ViewModelCommand LogonCommand
        {
            get
            {
                if (_LogonCommand == null)
                {
                    _LogonCommand = new ViewModelCommand(Logon);
                }
                return _LogonCommand;
            }
        }

        public async void Logon()
        {
            Employee authorizedUser = await this.Employee.LogonAsync();

            if (authorizedUser != null) // Logon 成功daze
            {
                SessionService.Instance.IsAuthorized = true;
                SessionService.Instance.AuthorizedEmployee = authorizedUser;

                var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
               // window.Hide();

                var showmypage = new TransitionMessage(typeof(Views.Mypage), new MypageViewModel(), TransitionMode.Modal, "ShowMypage");
                Messenger.Raise(showmypage);
            
            }
            else // Logon 失敗
            {
                System.Diagnostics.Debug.WriteLine("ログオンに失敗しました。");
            }

        }
        #endregion

        #region Logon2Command
        private ViewModelCommand _Logon2Command;

        public ViewModelCommand Logon2Command
        {
            get
            {
                if (_Logon2Command == null)
                {
                    _Logon2Command = new ViewModelCommand(Logon2);
                }
                return _Logon2Command;
            }
        }
        
        public async void Logon2()
        {
            Employee authorizedUser = await this.Employee.Logon2Async();

            if (authorizedUser != null) // Logon 成功
            {

                var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
                // window.Hide();

                var showkanri = new TransitionMessage(typeof(Views.Kanri), new KanriViewModel(), TransitionMode.Modal, "ShowKanri");
                Messenger.Raise(showkanri);

            }
            else // Logon 失敗
            {
                System.Diagnostics.Debug.WriteLine("ログオン2に失敗しました。");
            }

        }
        #endregion

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
            window.Close();
            KanshaCardViewModel ViewModel = new KanshaCardViewModel();
            var message = new TransitionMessage(typeof(Views.KanshaCard), ViewModel, TransitionMode.Modal, "ShowKanshaCard");
            //   var showkanshacard = new TransitionMessage(typeof(Views.KanshaCard), new MainWindowViewModel(), TransitionMode.Modal, "ShowKanshaCard");
            Messenger.Raise(message);

        }
        #endregion

        #region 説明書
        /* コマンド、プロパティの定義にはそれぞれ 
         * 
         *  lvcom    : ViewModelCommand
         *  lvcomn   : ViewModelCommand(CanExecute無)
         *  llcom    : ListenerCommand(パラメータ有のコマンド)
         *  llcomn   : ListenerCommand(パラメータ有のコマンド・CanExecute無)
         *  lprop    : 変更通知プロパティ
         *  lsprop   : 変更通知プロパティ(ショートバージョン)
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

        public void Initialize()
        {
            this.Employee = new Employee();
        }

        //List<Employee> authorizedEmployees = await this.Employee.GetEmployeesAsync();
    }
}
