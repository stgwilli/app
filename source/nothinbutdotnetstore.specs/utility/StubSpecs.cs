using Machine.Specifications;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;
using nothinbutdotnetstore.web.core.utility;

namespace nothinbutdotnetstore.specs.utility
{
    public class concern : Observes
    {
         
    }

    public class when_requesting_a_stub_from_the_stub_gateway : concern
    {

        Because b = () => result = Stub.with<StubDisplayEngine>();

        It should_return_the_stubbed_item = 
            () => result.ShouldBeOfType<StubDisplayEngine>();


        static StubDisplayEngine result;
    }
}