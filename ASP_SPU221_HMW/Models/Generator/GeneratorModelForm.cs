using Microsoft.AspNetCore.Mvc;

namespace ASP_SPU221_HMW.Models.Generator
{
    public class GeneratorModelForm
    {
       
        [FromForm(Name = "encCode")]
        public String SomeSaltCode { get; set; } = null!;
        [FromForm(Name = "saltCode")]
        public String Salt { get; set; } = null!;
        [FromForm(Name = "password")]
        public String Password {  get; set; } = null!;
    }
}
