using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.web.application.catalogbrowsing
{
    public class ViewDepartmentsInDepartment : IOrchestrateAnApplicationFeature
    {
        IFindDepartments department_repository;
        IDisplayReports display_engine;

        public ViewDepartmentsInDepartment(IFindDepartments department_repository, IDisplayReports display_engine)
        {
            this.department_repository = department_repository;
            this.display_engine = display_engine;
        }

        public void process(IContainRequestInformation request)
        {
            display_engine.display(department_repository.get_departments_for(request.get_input_model<Department>()));
        }
    }
}