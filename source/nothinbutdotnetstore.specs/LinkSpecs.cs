﻿using System.Collections.Generic;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core.link_builder;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(Link))]
    public class LinkSpecs
    {
        public abstract class concern:Observes
        {
        }

        public class when_asked_to_run_a_link : concern
        {
            Establish c = () =>
            {
                link_builder = fake.an<IBuildLinks>();
                LinkBuilderFactory factory = x =>
                {
                    return link_builder;
                };
                spec.change(() => Link.builder_factory).to(factory);
            };

            Because b = () =>
                result = Link.to_run<Link>();

            It should_return_the_link_builder_created_using_the_factory = () =>
                result.ShouldEqual(link_builder);


            static IBuildLinks result;
            static IBuildLinks link_builder;
        }
    }
}