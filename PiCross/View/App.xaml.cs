using DataStructures;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ViewModel;
using View.Services;

namespace View
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var container = new UnityContainer();
            container.RegisterInstance<IUnityContainer>(container);
            container.RegisterType <ITimerService, TimerService>();
            UnityServiceLocator locator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => locator);

            var mainWindow = new MainWindow();

            MainWindowViewModel vm = new MainWindowViewModel();

            vm.ClosingAction += MainViewModel_ApplicationExit;

            mainWindow.DataContext = vm;
            mainWindow.Show();
        }

        private void MainViewModel_ApplicationExit()
        {
            Application.Current.Shutdown();
        }
    }
}
