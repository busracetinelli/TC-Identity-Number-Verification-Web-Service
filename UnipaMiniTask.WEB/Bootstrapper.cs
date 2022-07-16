using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using UnipaMiniTask.BLL;
using System.Configuration;

namespace UnipaMiniTask.WEB
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container.RegisterType<BLLContext, BLLContext>(new InjectionConstructor(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString));

            return container;
        }
    }
}