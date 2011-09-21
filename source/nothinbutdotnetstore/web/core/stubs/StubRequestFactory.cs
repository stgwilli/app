﻿using System.Web;
using nothinbutdotnetstore.web.application.catalogbrowsing;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubRequestFactory : ICreateRequests
    {
        public IContainRequestInformation create_request_from(HttpContext context)
        {
            return new StubRequest();
        }

        class StubRequest : IContainRequestInformation
        {
            public InputModel map_a<InputModel>()
            {
                object item = null;
                if (typeof(InputModel).Equals(typeof(ViewTheDepartmentsOfADepartmentInput)))
                {
                    item = new ViewTheDepartmentsOfADepartmentInput();
                }
                else
                {
                    item = new ViewTheProductsInADepartmentInputModel();
                }
                return (InputModel) item;
            }
        }
    }
}