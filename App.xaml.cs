using BillManagerWPF.Services.Implementations;
using BillManagerWPF.Services.Interfaces;
using System.Windows;
using Unity;
using Unity.Injection;

namespace BillManagerWPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IBillsService, BillsService>();
            unityContainer.RegisterType<IInfoService, InfoService>();
            unityContainer.RegisterType<MainWindow, MainWindow>();
            unityContainer.RegisterType<Login, Login>();
            unityContainer.RegisterType<IUsersService, UsersService>();

            unityContainer.RegisterType<Login>(new InjectionConstructor(unityContainer.Resolve<MainWindow>(),
                unityContainer.Resolve<UsersService>()));
            var startWindow = unityContainer.Resolve<Login>();
            startWindow.Show();
        }
    }
}
