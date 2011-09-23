using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    public class RequestInformationSpecs
    {
         public abstract class concern : Observes<IContainRequestInformation, RequestInformation>
         {
             
         }


        public class when_mapping_a_model_from_the_request_information : concern
        {
            Establish context = () =>
                {
                    model_factory = depends.on<ICreateModels>();
                };

            Because b = () => sut.map_a<FakeType>();

            It should_ask_the_model_factory_for_an_instance_of_the_input_model =
                () => model_factory.received(x => x.create_model_for(typeof(FakeType)));

            static ICreateModels model_factory;
        }
    }
}