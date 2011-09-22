using System;

namespace nothinbutdotnetstore.web.core
{
    public class ParameterizedLinkBuilder<Item, Property> : IBuildLinks
    {
        readonly IBuildLinks original_builder;
        readonly Item item;
        readonly Func<Item, Property> accessor;

        public ParameterizedLinkBuilder(IBuildLinks original_builder, Item item, Func<Item, Property> accessor)
        {
            this.original_builder = original_builder;
            this.item = item;
            this.accessor = accessor;
        }

        public override string ToString()
        {
            return String.Format("{0}/{1}", original_builder, accessor(item));
        }
    }
}