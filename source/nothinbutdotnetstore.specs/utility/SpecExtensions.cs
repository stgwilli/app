﻿using developwithpassion.specifications.core;

namespace nothinbutdotnetstore.specs.utility
{
    public static class SpecExtensions
    {
        public static Dependency prepare_container_resolved<Dependency>(this IConfigureSetupPairs spec, ICreateFakes fakes,Dependency dependency)
        {
            return default(Dependency);
        } 
    }
}