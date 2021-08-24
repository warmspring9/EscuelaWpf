using EscuelaWPF.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EscuelaWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            ApplicationSetup();



            //Show the main window
            Current.MainWindow = new MainWindow();
            Current.MainWindow.Show();
        }

        private void ApplicationSetup()
        {
            //Sets up dependency Injection
            IoC.Setup();

            // Bind a UI Manager
            IoC.Kernel.Bind<IUIManager>().ToConstant(new UIManager());


        }
    }
}
