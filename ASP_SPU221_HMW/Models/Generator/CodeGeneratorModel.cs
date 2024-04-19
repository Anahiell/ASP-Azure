using Microsoft.AspNetCore.Mvc;

namespace ASP_SPU221_HMW.Models.Generator
{
    public class CodeGeneratorModel
    {
        public String PageTitle { get; set; }
        public GeneratorModelForm? FormModel { get; set; }
        public String SomeCode { get; set; } = null!;

    }
}
