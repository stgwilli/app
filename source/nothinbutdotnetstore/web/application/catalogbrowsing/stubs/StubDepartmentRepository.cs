using System.Collections.Generic;
using System.Linq;

namespace nothinbutdotnetstore.web.application.catalogbrowsing.stubs
{
    public class StubDepartmentRepository:IFindDepartments
    {
        public IEnumerable<Department> get_the_main_departments_in_the_store()
        {
            return Enumerable.Range(1, 100).Select(x => new Department{name = x.ToString("Department 0")});
        }

        public IEnumerable<Department> get_departments_for(Department department)
        {
            return Enumerable.Range(1, 100).Select(x => new Department { name = x.ToString("Subdepartment 0")});
        }
    }
}