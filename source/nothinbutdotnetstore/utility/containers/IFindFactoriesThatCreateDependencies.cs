namespace nothinbutdotnetstore.utility.containers
{
    public interface IFindFactoriesThatCreateDependencies
    {
        ICreateOneDependency factory_for<Dependency>(); 
    }
}