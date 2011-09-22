using System;

namespace nothinbutdotnetstore.web.core
{
    public delegate string RequestNameStrategy(Type type);

    public static class RequestNaming
    {
        public static RequestNameStrategy strategy = type => String.Format("{0}.daxko", type.Name);
    }
}