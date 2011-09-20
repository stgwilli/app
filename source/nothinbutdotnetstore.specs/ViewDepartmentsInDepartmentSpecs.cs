 using System.Collections.Generic;
 using Machine.Specifications;
 using developwithpassion.specifications.extensions;
 using developwithpassion.specifications.rhinomocks;
 using nothinbutdotnetstore.web.application.catalogbrowsing;
 using nothinbutdotnetstore.web.core;

namespace nothinbutdotnetstore.specs
 {   
     public class ViewDepartmentsInDepartmentSpecs
     {
         public abstract class concern : Observes<IOrchestrateAnApplicationFeature,
                                             ViewDepartmentsInDepartment>
         {
        
         }

         public class when_run : concern
         {
             Establish context = () =>
                 {
                     department_repository = depends.on<IFindDepartments>();
                     request = fake.an<IContainRequestInformation>();
                     display_engine = depends.on<IDisplayReports>();
                     sub_departments = new List<Department> { new Department() };
                     department = fake.an<Department>();
                     
                     request.setup(x => x.get_input_model<Department>()).Return(department);
                     department_repository.setup(x => x.get_departments_for(department))
                         .Return(sub_departments);
                 };

             Because b = 
                 () => sut.process(request);

             It should_get_the_specified_department_from_the_request = 
                 () => request.received(x => x.get_input_model<Department>());

             It should_get_the_departments_from_the_department_repository_from_the_specified_department = 
                 () => department_repository.received(x => x.get_departments_for(department));

             It should_display_the_subdepartments = 
                 () => display_engine.received(x => x.display(sub_departments));



             static IContainRequestInformation request;
             static IFindDepartments department_repository;
             static Department department;
             static IDisplayReports display_engine;
             static IEnumerable<Department> sub_departments;
         }
     }
 }
