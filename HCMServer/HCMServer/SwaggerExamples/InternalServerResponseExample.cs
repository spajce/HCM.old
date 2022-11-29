using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Filters;

namespace HCMServer.SwaggerExamples
{
    public class InternalServerResponseExample : IExamplesProvider<object>
    {
        public object GetExamples()
        {
            return new { ErrorCode = 500, Message = "An unexpected error occurred" };
        }
    }
}
