using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Compilation;
using nothinbutdotnetstore.utility.containers;
using nothinbutdotnetstore.utility.containers.simple;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.tasks
{
    public class Startup
    {
        static IDictionary<IRepresentAType, ICreateADependency> factories;

        public static void run()
        {
            factories = new Dictionary<IRepresentAType, ICreateADependency>();

            var container =
                new Container(new DependencyFactoryRegistry(factories, type => new SimpleDependencyFactory(delegate
                {
                    throw new NotImplementedException(string.Format("Failed to create an instance of {0}", type.Name));
                })));

            Depends.container_resolver = () => container;

            populate_factories();
        }

        static void populate_factories()
        {
            //factories.Add(new SimpleTypeKey(typeof(IFindViewForModel)), new SimpleDependencyFactory(() => new WebFormViewRegistry(BuildManager.)));

            factories.Add(new SimpleTypeKey(typeof(IDisplayReports)), new SimpleDependencyFactory(() => new WebFormDisplayEngine(Depends.on.a<IFindViewForModel>(), () => HttpContext.Current)));
            
            factories.Add(new SimpleTypeKey(typeof(IEnumerable<IProcessOneRequest>)), new SimpleDependencyFactory(() => new StubSetOfCommands()));

            factories.Add(new SimpleTypeKey((typeof(IFindCommands))), new SimpleDependencyFactory(() => new CommandRegistry(Depends.on.a<IEnumerable<IProcessOneRequest>>(), new StubMissingCommand())));
            
            factories.Add(new SimpleTypeKey(typeof(IProcessRequests)), new SimpleDependencyFactory(() => new FrontController(Depends.on.a<IFindCommands>())));
        }
    }
}