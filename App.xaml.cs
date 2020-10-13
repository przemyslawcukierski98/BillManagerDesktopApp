using BillManagerWPF.Services.Implementations;
using BillManagerWPF.Services.Interfaces;
using System.Windows;
using Unity;

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
            unityContainer.RegisterType<IUsersService, UsersService>();
        }
    }
}
