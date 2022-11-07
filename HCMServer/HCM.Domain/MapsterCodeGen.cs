using System.Reflection;
using Mapster;

namespace HCM.Domain
{
    public class MapsterCodeGen : ICodeGenerationRegister
    {
        public void Register(CodeGenerationConfig config)
        {
            config.AdaptTo("[name]Dto").
                ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "HCM.Domain.Entities");
        }
    }
}
