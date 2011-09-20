using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.application.catalogbrowsing;
using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof(ViewTheMainDepartments))]
    public class ViewTheMainDepartmentsSpecs
    {
        public abstract class concern : Observes<IOrchestrateAnApplicationFeature,
                                            ViewTheMainDepartments>
        {
        }

        public class when_run : concern
        {
            //Arrange
            Establish c = () =>
            {
                request = fake.an<IContainRequestInformation>();
                the_store = depends.on<IStore>();
            };

            //Act
            Because b = () =>
                sut.process(request);

            //Assert
            It should_get_a_list_of_the_main_departments_from_the_store =
                () => the_store.received(x => x.get_main_departments());

            static IContainRequestInformation request;
            static IStore the_store;
        }
    }
}