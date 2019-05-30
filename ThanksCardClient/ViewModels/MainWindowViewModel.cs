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

namespace ThanksCardClient.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
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


        #region UserProperty
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

        public void Initialize()
        {
            this.Employee = new Employee();
        }

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

            if (authorizedUser != null) // Logon 成功
            {
                var showmypage = new TransitionMessage(typeof(Views.Mypage), new MainWindowViewModel(), TransitionMode.Modal, "ShowMypage");
                Messenger.Raise(showmypage);
            
            }
            else // Logon 失敗
            {
                System.Diagnostics.Debug.WriteLine("ログオンに失敗しました。");
            }

        }
        #endregion

        #region Keiziban


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
            var showkeiziban = new TransitionMessage(typeof(Views.Keiziban), new MainWindowViewModel(), TransitionMode.Modal, "ShowKeiziban");
            Messenger.Raise(showkeiziban);

        }
        #endregion

        #region Pickup


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
            var showpickup = new TransitionMessage(typeof(Views.Pickup), new MainWindowViewModel(), TransitionMode.Modal, "ShowPickup");
            Messenger.Raise(showpickup);

        }
        #endregion

        #region ShowBusyo


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
            var showbusyo = new TransitionMessage(typeof(Views.Busyo), new MainWindowViewModel(), TransitionMode.Modal, "ShowBusyo");
            Messenger.Raise(showbusyo);

        }
        #endregion

        #region ShowRankiing


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
            var showranking = new TransitionMessage(typeof(Views.Ranking), new MainWindowViewModel(), TransitionMode.Modal, "ShowRanking");
            Messenger.Raise(showranking);

        }
        #endregion



        //aa
    }
}
