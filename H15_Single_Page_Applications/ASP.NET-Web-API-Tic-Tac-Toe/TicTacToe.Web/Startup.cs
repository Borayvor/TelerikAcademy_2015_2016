﻿using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
using Owin;
using TicTacToe.Data;
using TicTacToe.GameLogic;
using TicTacToe.Web.Infrastructure;
[assembly: OwinStartup(typeof(TicTacToe.Web.Startup))]

namespace TicTacToe.Web
{


    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(GlobalConfiguration.Configuration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            RegisterMappings(kernel);
            return kernel;
        }

        private static void RegisterMappings(StandardKernel kernel)
        {
            kernel.Bind<ITicTacToeData>().To<TicTacToeData>()
                .WithConstructorArgument("context",
                    c => new TicTacToeDbContext());

            kernel.Bind<IGameResultValidator>().To<GameResultValidator>();

            kernel.Bind<IUserIdProvider>().To<AspNetUserIdProvider>();
        }
    }
}
