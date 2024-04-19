using Microsoft.Identity.Client;

namespace ASP_SPU221_HMW.Models.Home.SignUp
{
    public class SignUpPageModel
    {
        public String? Message { get; set; } = null!;
        public bool? IsSuccess {  get; set; }
        public SignUpFormModel? SignUpFormModel { get; set; }
    }
}
