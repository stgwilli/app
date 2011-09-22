namespace nothinbutdotnetstore.utility.containers
{
    public class Container : IFetchDependencies
    {
        IFindFactoriesThatCreateDependencies dependency_factories;

        public Container(IFindFactoriesThatCreateDependencies dependency_factories)
        {
            this.dependency_factories = dependency_factories;
        }

        public Dependency a<Dependency>()
        {
            dependency_factories.factory_for<Dependency>();

            return default(Dependency);
        }
    }
}