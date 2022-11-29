using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCMServer.Apis.V1.Controllers.Employees;
using Swashbuckle.AspNetCore.Filters;

namespace HCMServer.SwaggerExamples
{
    public class EmployeeResultExample : IMultipleExamplesProvider<EmployeeModel>
    {
        public IEnumerable<SwaggerExample<EmployeeModel>> GetExamples()
        {
            yield return SwaggerExample.Create(
                "Example 1", new EmployeeModel
                {
                    LastName = "Example 1"
                });

            yield return SwaggerExample.Create(
              "Example 2", new EmployeeModel
              {
                  LastName = "Example 2"
              });
        }
    }
}
