using System;

namespace nothinbutdotnetstore.web.core
{
    public static class Link
    {
        public static IBuildLinks to_run<Request>()
        {
            return new LinkBuilder<Request>(RequestNaming.strategy);
        }

        public static IBuildLinks conditionally<AlternateRequest>(this IBuildLinks original_builder, Func<bool> condition)
        {
            return new ConditionalLinkBuilder(to_run<AlternateRequest>(), original_builder, condition);
        }

        public static IBuildLinks include<Item, Property>(this IBuildLinks original_builder, Item item, Func<Item, Property> accessor)
        {
            return new ParameterizedLinkBuilder<Item, Property>(original_builder, item, accessor);
        }
    }
}