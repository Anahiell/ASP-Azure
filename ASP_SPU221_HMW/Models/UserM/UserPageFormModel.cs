using Microsoft.AspNetCore.Mvc;

namespace ASP_SPU221_HMW.Models.UserM
{
    public class UserPageFormModel
    {
        [FromForm(Name = "username-nick")]
        public String UserNick {  get; set; }
        [FromForm(Name = "user-email")]
        public String UserEmail { get; set; }
        [FromForm(Name = "user-password1")]
        public String UserPassword { get; set; }
    }
}
