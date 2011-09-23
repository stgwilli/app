using System;

namespace nothinbutdotnetstore.web.core
{
    public interface ICreateModels
    {
        object create_model_for(Type type);
    }
}