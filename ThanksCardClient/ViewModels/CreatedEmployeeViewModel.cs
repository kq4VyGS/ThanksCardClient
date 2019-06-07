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

namespace ThanksCardClient.ViewModels
{
    public class CreatedEmployeeViewModel : ViewModel
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

        #region DepartmentProperty
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

        #region DepartmentsProperty

        private List<Department> _Departments;

        public List<Department> Departments
        {
            get
            { return _Departments; }
            set
            {
                if (_Departments == value)
                    return;
                _Departments = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region SectionProperty
        private Section _Section;

        public Section Section
        {
            get
            { return _Section; }
            set
            {
                if (_Section == value)
                    return;
                _Section = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region SectionsProperty
        private List<Section> _Sections;

        public List<Section> Sections
        {
            get
            { return _Sections; }
            set
            {
                if (_Sections == value)
                    return;
                _Sections = value;
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

        #region Submit2Command
        private ViewModelCommand _Submit2Command;

        public ViewModelCommand Submit2Command
        {
            get
            {
                if (_Submit2Command == null)
                {
                    _Submit2Command = new ViewModelCommand(Submit2);
                }
                return _Submit2Command;
            }
        }

        public async void Submit2()
        {

            Employee createdEmployee = await Employee.PostEmployeeAsync(this.Employee);
            //TODO: Error handling
            Messenger.Raise(new WindowActionMessage(WindowAction.Close, "Created"));
        }
        #endregion

        #region CancelCommand


        private ViewModelCommand _CancelCommand;

        public ViewModelCommand CancelCommand

        {
            get
            {
                if (_CancelCommand == null)
                {
                    _CancelCommand = new ViewModelCommand(Cancel);
                }
                return _CancelCommand;
            }
        }

        public void Cancel()
        {

            var window = Application.Current.Windows.OfType<Window>().SingleOrDefault((w) => w.IsActive);
            window.Close();

        }
        #endregion

        public async void Initialize()
        {
            //ComboBox(課)のやつ
            Section sections = new Section();
            this.Sections = await sections.GetSectionsAsync();

            //初期化してテーブルおく
            this.Employee = new Employee();
        }
    }
}
