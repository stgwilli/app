using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class LinkSpecs
    {
        public abstract class concern : Observes
        {
            
        }

        public class when_calling_to_run_for_a_request
        {
            Because b = () => result = Link.to_run<FakeRequest>();

            It should_return_a_url_where_the_url_contains_the_name_of_the_request =
                () => result.ToString().ShouldEqual("FakeRequest.daxko");

            static IBuildLinks result;
        }

        public class when_calling_conditionally : concern
        {
            public class and_the_condition_returns_true
            {

                Because b = () => result = Link.to_run<FakeRequest>()
                    .conditionally<ConditionalRequest>(() => true);

                It should_render_the_link_for_the_request_specified_in_the_condition =
                    () => result.ToString().ShouldEqual("ConditionalRequest.daxko");

                static IBuildLinks result;
            }

            public class and_the_condition_returns_false
            {
                Because b = () => result = Link.to_run<FakeRequest>()
                    .conditionally<ConditionalRequest>(() => false);

                It should_render_the_link_for_the_base_request =
                    () => result.ToString().ShouldEqual("FakeRequest.daxko");

                static IBuildLinks result;
            }

            public class and_there_are_multiple_conditions
            {
                It should_return_the_link_of_the_first_condition_that_passes =
                    () => Link.to_run<FakeRequest>()
                    .conditionally<ConditionalRequest>(() => false)
                    .conditionally<FirstPassingRequest>(() => true)
                    .conditionally<AnotherFakeRequest>(() => false)
                    .ToString().ShouldEqual("FirstPassingRequest.daxko");

                It should_return_the_link_of_the_to_run_if_all_conditions_fail =
                    () => Link.to_run<FakeRequest>()
                        .conditionally<ConditionalRequest>(() => false)
                        .conditionally<AnotherFakeRequest>(() => false)
                        .conditionally<FirstPassingRequest>(() => false)
                        .ToString().ShouldEqual("FakeRequest.daxko");


                static IBuildLinks result;
            }
        }

        public class when_including_a_parameter : concern
        {
            Establish context = () =>
                {
                    department = new SomeFakeItem { id = 5 };
                };

            Because b = () => result = Link.to_run<FakeRequest>()
                .include(department, x => x.id);

            It should_add_the_value_of_the_parameter_to_the_end_of_the_link_separated_by_a_slash =
                () => result.ToString().ShouldEqual("FakeRequest.daxko/5");

            static IBuildLinks result;
            static SomeFakeItem department;
        }
    }

    public class SomeFakeItem
    {
        public int id { get; set; }
    }

    internal class FirstPassingRequest
    {
    }

    internal class AnotherFakeRequest
    {
    }

    public class ConditionalRequest
    {
    }
}