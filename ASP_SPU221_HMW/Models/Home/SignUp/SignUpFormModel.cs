using Microsoft.AspNetCore.Mvc;

namespace ASP_SPU221_HMW.Models.Home.SignUp
{
    public class SignUpFormModel
    {
        [FromForm(Name = "username-nick")]
        public String UserName { get; set; } = null!;
        [FromForm(Name = "user-email")]
        public String UserEmail { get; set; } = null!;
        [FromForm(Name = "user-password1")]
        public String UserPassword { get; set; } = null!;
        [FromForm(Name = "user-password2")]
        public String UserPassword2 { get; set; } = null!;
        [FromForm(Name = "signup-birthdate")]
        public DateTime? Birthdate { get; set; } = null!;
        [FromForm(Name = "singup-avatar")]
        public IFormFile AvatarFile { get; set; } = null!;
        [FromForm(Name = "signup-confirm")]
        public bool Confirm {  get; set; }
        public String? SavedFileName { get; set; }

    }
}
