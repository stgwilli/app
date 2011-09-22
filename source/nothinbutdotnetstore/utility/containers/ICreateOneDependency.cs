using System;

namespace nothinbutdotnetstore.utility.containers
{
    public interface ICreateOneDependency
    {
        object create_an_instance_of(Type type);
    }
}