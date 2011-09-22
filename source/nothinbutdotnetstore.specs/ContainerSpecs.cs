using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.utility.containers;

namespace nothinbutdotnetstore.specs
{
    public class ContainerSpecs
    {
        public abstract class concern : Observes<IFetchDependencies, Container>
        {
        }

        public class when_fetching_a_dependency_from_the_container : concern
        {
            Establish context = () =>
            {
                find_type_factories = depends.on<IFindFactoriesThatCreateDependencies>();

                find_type_factories.setup(x => x.factory_for<FakeType>())
                    .Return(type_factory);
            };

            Because b = () => 
                sut.a<FakeType>();

            It should_get_the_type_factory_based_on_the_specified_dependency =
                () => find_type_factories.received(x => x.factory_for<FakeType>());

            It should_ask_the_factory_to_create_an_instance_of_the_specified_type = 
                () => type_factory.received(x => x.create_an_instance_of(typeof(FakeType)));

            static IFindFactoriesThatCreateDependencies find_type_factories;
            static ICreateOneDependency type_factory;
        }
    }

    class FakeType
    {
    }
}