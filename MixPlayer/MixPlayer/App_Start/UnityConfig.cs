using Microsoft.Practices.Unity;
using MixPlayer.Repository;
using MixPlayer.Services;
using System.Web.Http;
using Unity.WebApi;

namespace MixPlayer
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);

			container.RegisterType<IArchivoRepository, ArchivoRepository>();
			container.RegisterType<IArchivoService, ArchivoService>();
			container.RegisterType<IPlayListRepository, PlayListRepository>();
			container.RegisterType<IPlayListService, PlayListService>();
		}
	}
}