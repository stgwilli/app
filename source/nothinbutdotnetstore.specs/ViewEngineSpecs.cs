using System.Web;
using Machine.Specifications;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.aspnet;

namespace nothinbutdotnetstore.specs
{
    [Subject(typeof (DisplayEngine))]
    public class DisplayEngineSpecs
    {
        public abstract class concern : Observes<IDisplayReports, DisplayEngine>
        {
        }

        public class when_displaying_a_report_model : concern
        {
            Establish context = () =>
                {
                    view_finder = depends.on<IFindViews>();
                };

            Because b = () => sut.display(new FakeReportModel());

            It should_find_a_view_that_can_render_the_report_model =
                () => view_finder.received(x => x.find_view_for<FakeReportModel>());

            static IFindViews view_finder;
        }
    }

    public class FakeReportModel
    {
    }
}