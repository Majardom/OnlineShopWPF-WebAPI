using BLL.AutoMapperConfiguration;
using BLL.DependencyConfiguration;
using Client.DependencyConfiguration;
using Ninject;
using System.Windows;

namespace Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IKernel Container;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AutoMapperConfiguration.Initialize();

            ConfigureContainer();
            ComposeObjects();
            Current.MainWindow.Show();
        }

        private void ConfigureContainer()
        {
            Container = new StandardKernel(
               new DalModule("OnlineShopDb"),
               new BllModule()
            );
        }

        private void ComposeObjects()
        {
            Current.MainWindow = Container.Get<MainWindow>();
        }
    }
}
