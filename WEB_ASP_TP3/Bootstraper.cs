using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB_ASP_TP3.Repository;


namespace FirstApplication
{
    public class Bootstraper
    {

        public static IUnityContainer Initialize() {

            var container = new UnityContainer();

            container.RegisterType<ILivroRepository, LivroRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;



        }


    }
}