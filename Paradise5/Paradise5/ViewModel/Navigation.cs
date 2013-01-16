using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Paradise5.ViewModel
{
    public class Navigation
    {
        #region Navigation
        public class BaseClass : INotifyPropertyChanged
        {

            public event PropertyChangedEventHandler PropertyChanged;
            #region OnPropertyChanged
            /// <summary>
            /// Triggers the PropertyChanged event.
            /// </summary>
            public virtual void OnPropertyChanged(string propertyName)
            {
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
        public static class AppNavigator
        {
            public static AppNavigatorHelper CurrentHelper { get; set; }
            // Fields...
            private static object _CurrentViewModel;

            public static object CurrentViewModel
            {
                get { return _CurrentViewModel; }
                set
                {
                    _CurrentViewModel = value;
                    if (CurrentHelper != null)
                        CurrentHelper.OnPropertyChanged("CurrentViewModel");
                }
            }
        }
        public class AppNavigatorHelper : BaseClass
        {

            public AppNavigatorHelper()
            {
                AppNavigator.CurrentHelper = this;
            }

            public object CurrentViewModel
            {
                get { return AppNavigator.CurrentViewModel; }
                set
                {
                    AppNavigator.CurrentViewModel = value;
                }
            }
        }
        #endregion

        #region Command
        public class NavigateCommand : ICommand
        {
            private readonly object _Owner;


            public NavigateCommand(object owner)
            {
                _Owner = owner;
            }
            bool ICommand.CanExecute(object parameter)
            {
                return true;
            }

            public event EventHandler CanExecuteChanged;


            void ICommand.Execute(object parameter)
            {
                OnExecute(_Owner);
            }
            public virtual void OnExecute(object owner)
            {

            }
        }

        public class ClickCommand : NavigateCommand
        {
            public ClickCommand(object owner)
                : base(owner)
            {

            }

            public override void OnExecute(object owner)
            {
                AppNavigator.CurrentViewModel = owner;
            }
        }

        public class BackCommand : NavigateCommand
        {
            public BackCommand(object owner)
                : base(owner)
            {

            }

            public override void OnExecute(object Parent)
            {
                AppNavigator.CurrentViewModel = Parent;
            }

        }
        #endregion
    }
}
