namespace SchoolSystem.Cli
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Configuration;
    using Framework.Core;
    using Framework.Core.Commands;
    using Framework.Core.Contracts;
    using Framework.Core.Contracts.Commands;
    using Framework.Core.Contracts.Factories;
    using Framework.Core.Contracts.Providers;
    using Framework.Core.Contracts.Repositories;
    using Framework.Core.Providers;
    using Framework.Core.Repositories;
    using Interceptors;
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Extensions.Factory;
    using Ninject.Extensions.Interception.Infrastructure.Language;
    using Ninject.Modules;

    public class SchoolSystemModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Bind(x =>
            {
                x.FromAssembliesInPath(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location))
                .SelectAllClasses()
                .Where(type => type != typeof(Engine))
                .BindDefaultInterface();
            });

            Bind<IEngine>().To<Engine>().InSingletonScope();

            Bind(typeof(IDbRepository<>)).To(typeof(DictionaryDbRepository<>)).InSingletonScope();

            Bind<IReader>().To<ConsoleReaderProvider>().InSingletonScope();
            Bind<IWriter>().To<ConsoleWriterProvider>().InSingletonScope();
            Bind<IParser>().To<CommandParserProvider>().InSingletonScope();

            Bind<CreateStudentCommand>().ToSelf();
            Bind<CreateTeacherCommand>().ToSelf();
            Bind<RemoveStudentCommand>().ToSelf();
            Bind<RemoveTeacherCommand>().ToSelf();
            Bind<StudentListMarksCommand>().ToSelf();
            Bind<TeacherAddMarkCommand>().ToSelf();

            var markFactoryBinding = Bind<IMarkFactory>().ToFactory().InSingletonScope();
            var studentFactoryBinding = Bind<IStudentFactory>().ToFactory().InSingletonScope();
            var commandFactoryBinding = Bind<ICommandFactory>().ToFactory().InSingletonScope();
            Bind<ITeacherFactory>().ToFactory().InSingletonScope();

            Bind<ICommand>().ToMethod(context =>
            {
                Type commandType = (Type)context.Parameters.Single().GetValue(context, null);
                var result = (ICommand)context.Kernel.Get(commandType);

                return result;
            }).NamedLikeFactoryMethod((ICommandFactory commandFactory) => commandFactory.GetCommand(null));

            IConfigurationProvider configurationProvider = Kernel.Get<IConfigurationProvider>();

            if (configurationProvider.IsTestEnvironment)
            {
                commandFactoryBinding.Intercept().With<StopwatchInterceptor>();
                studentFactoryBinding.Intercept().With<StopwatchInterceptor>();
                markFactoryBinding.Intercept().With<StopwatchInterceptor>();
            }
        }
    }
}