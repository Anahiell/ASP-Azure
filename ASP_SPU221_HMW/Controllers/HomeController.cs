using ASP_SPU221_HMW.Data.Dal;
using ASP_SPU221_HMW.Models;
using ASP_SPU221_HMW.Models.Generator;
using ASP_SPU221_HMW.Models.Home.SignUp;
using ASP_SPU221_HMW.Models.UserM;
using ASP_SPU221_HMW.Services.Hash;
using ASP_SPU221_HMW.Services.Kdf;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace ASP_SPU221_HMW.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IRandCodeService _randCodeService;
        private readonly IKdfService _kdfService;
        private readonly DataAcessor _dataAccessor;
        public HomeController(ILogger<HomeController> logger, IRandCodeService randCodeService, IKdfService kdfService, DataAcessor dataAccessor)
        {
            _logger = logger;
            _randCodeService = randCodeService;
            _kdfService = kdfService;
            _dataAccessor = dataAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult UserPage(UserPageFormModel? formUserPage)
        {
            UserPage_PageModel model = new()
            {
                PageTitle = "User Page",
                Model = formUserPage
            };
            return View(model);
        }
        public ViewResult IocGeneratorView(GeneratorModelForm? form)
        {
            if (form != null)
            {
                string salt = "3";
                string encryptedPassword = _kdfService.GetDerivedKey(form.Password, salt);

                CodeGeneratorModel model = new CodeGeneratorModel
                {
                    PageTitle = "somew",
                    FormModel = new GeneratorModelForm
                    {
                        SomeSaltCode = encryptedPassword,
                        Salt = salt
                    },
                    SomeCode = _randCodeService.Digest()
                };

                return View(model);
            }
            else
            {
                return View(new CodeGeneratorModel { PageTitle = "somew", FormModel = null });
            }
        }
        public ViewResult SignIn()
        {
            return View();
        }
        public ViewResult SignUp(SignUpFormModel? formModel)
        {
            SignUpPageModel pageModel = new()
            {
                SignUpFormModel = formModel,
                ValidationErrors = _ValidateSignUpModel(formModel)
            };
            if (formModel?.UserEmail != null)
            {
                if (pageModel.ValidationErrors.Count > 0)
                {
                    pageModel.Message = "Registration Error";
                    pageModel.IsSuccess = false;
                }
                else
                {
                    _dataAccessor.UserDao.SignupUser(mapUser(formModel));
                    pageModel.Message = "Registration Success";
                    pageModel.IsSuccess = true;
                }
            }

            return View(pageModel);
        }
        private Data.Entities.User mapUser(SignUpFormModel formModel)
        {
            String salt = GenerateRandomSalt(2);
            return new()
            {
                Id = Guid.NewGuid(),
                Name = formModel.UserNick,
                Email = formModel.UserEmail,
                Registered = DateTime.Now,
                Birthdate = formModel.Birthdate,
                Salt = salt,
                DerivedKey = _kdfService.GetDerivedKey("123", salt)
            };
        }
        private Dictionary<String, String> _ValidateSignUpModel(SignUpFormModel? FormModel)
        {
            Dictionary<String, String> result = new();
            if (FormModel == null)
            {
                result[nameof(FormModel)] = "model empty";
            }
            if(FormModel != null) 
            {
                if (String.IsNullOrEmpty(FormModel.UserNick))
                {
                    result[nameof(FormModel.UserNick)] = "Name is empty";
                }
                if (String.IsNullOrEmpty(FormModel.UserNick))
                {
                    result[nameof(FormModel.UserEmail)] = "Email is empty";
                }
                if (! _dataAccessor.UserDao.IsEmailFree(FormModel.UserEmail))
                {
                    result[nameof(FormModel.UserEmail)] = "email in use";
                }
                if (!FormModel.Confirm)
                {
                    result[nameof(FormModel.Confirm)] = "ConfirmExpected";
                }
            }
            return result;
        }
        private string GenerateRandomSalt(int length)
        {
            const string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            byte[] randomBytes = new byte[length];

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(randomBytes);
            }

            StringBuilder saltBuilder = new StringBuilder(length);
            foreach (byte b in randomBytes)
            {
                saltBuilder.Append(allowedChars[b % allowedChars.Length]);
            }

            return saltBuilder.ToString();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
