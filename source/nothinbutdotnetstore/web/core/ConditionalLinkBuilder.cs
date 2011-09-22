using System;

namespace nothinbutdotnetstore.web.core
{
    public class ConditionalLinkBuilder : IBuildLinks
    {
        readonly IBuildLinks success_condition_builder;
        readonly IBuildLinks failed_condition_builder;
        readonly Func<bool> condition;

        public ConditionalLinkBuilder(IBuildLinks success_condition_builder, IBuildLinks failed_condition_builder, Func<bool> condition)
        {
            this.success_condition_builder = success_condition_builder;
            this.failed_condition_builder = failed_condition_builder;
            this.condition = condition;
        }

        public override string ToString()
        {
            return condition() 
                       ? success_condition_builder.ToString() 
                       : failed_condition_builder.ToString();
        }
    }
}