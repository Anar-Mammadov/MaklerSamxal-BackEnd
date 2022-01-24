using MaklerSamxal.WebUI.Application.Core;
using MaklerSamxal.WebUI.Models.DataContexts;
using MaklerSamxal.WebUI.Models.Entity;
using MaklerSamxal.WebUI.Models.Entity.Membership;
using MaklerSamxal.WebUI.Models.FormModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MaklerSamxal.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        readonly MaklerSamxalDbContext db;
        readonly IConfiguration configuration;
        readonly UserManager<MaklerUser> userManager;
        readonly SignInManager<MaklerUser> signInManager;
        public HomeController(MaklerSamxalDbContext db, IConfiguration configuration, UserManager<MaklerUser> userManager, SignInManager<MaklerUser> signInManager)
        {
            this.db = db;
            this.configuration = configuration;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About(Testimionals testimionals)
        {
            var data = db.Testimionalss.Where(d => d.DeleteByUserId == null).ToList();

            return View(data);
        }
        public IActionResult Agents(Agent agents)
        {
            var data = db.Agents.Where(d => d.DeleteByUserId == null).ToList();

            return View(data);
            
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(Contact model)
        {

            if (ModelState.IsValid)
            {
                db.Contacts.Add(model);
                db.SaveChanges();

                return Json(new
                {
                    error = false,
                    message = "Sorgunuz qeyd alindi"
                });


            }

            return Json(new
            {
                error = true,
                message = "Sorgunuz qeyde alinmadi"
            });

        }



        [HttpGet]
        public IActionResult Register()
        {
            //Eger giris edibse routda myaccount/sing yazanda o seyfe acilmasin homa tulaasin
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterFormModel register)
        {

            //Eger giris edibse routda myaccount/sing yazanda o seyfe acilmasin homa tulaasin
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            //Yeni user yaradiriq.
            MaklerUser user = new MaklerUser
            {

                UserName = register.UserName,
                Email = register.Email,
                Activates = true
            };



            string token = $"subscribetoken-{register.UserName}-{DateTime.Now:yyyyMMddHHmmss}"; // token yeni id goturuk

            token = token.Encrypt("");

            string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirmm?token={token}"; // path duzeldirik



            var mailSended = configuration.SendEmail(user.Email, "Riode seyfesi gagas", $"Zehmet olmasa <a href={path}>Link</a> vasitesile abuneliyi tamamlayin");


            var person = await userManager.FindByNameAsync(user.UserName);

                
            if (person == null)
            {
                //Burda biz userManager vasitesile user ve RegistirVM passwword yoxluyuruq.(yaradiriq)
                var identityRuselt = await userManager.CreateAsync(user, register.Password);


                //Startupda yazdigimiz qanunlara uymursa Configure<IdentityOptions> onda error qaytariq summary ile.;
                if (!identityRuselt.Succeeded)
                {
                    foreach (var error in identityRuselt.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                //Yratdigimiz user ilk yarananda user rolu verik.

                await userManager.AddToRoleAsync(user, "User");

                return RedirectToAction("Signin", "Home");

            }


            if (person.UserName != null)
            {
                ViewBag.ms = "Bu username evvelceden qeydiyyatdan kecib";

                return View(register);
            }
            return null;

        }

        public IActionResult Signin()
        {
           // Eger giris edibse routda myaccount / sing yazanda o seyfe acilmasin homa tulaasin
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Signin(LoginFormModel user)
        {


            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("index", "Home");

            }

            if (ModelState.IsValid)
            {

                MaklerUser founderUser = null;

                if (user.UserName.IsEmail())
                {
                    founderUser = await userManager.FindByEmailAsync(user.UserName); //Eger Isdifadeci email gore giris edibse onu yoxlayir 
                }
                else
                {
                    founderUser = await userManager.FindByNameAsync(user.UserName); //YOX EGER USERNAME GORE GIRIBSE ONU AXTARIS EDIR.

                }

                if (founderUser == null) //Eger login ola bilmirse gonderir view gonderir yeni isdifadeci tapilmiyanda
                {
                    ViewBag.Ms = "Isdifadeci sifresi ve parol sefdir gagas";
                    return View(user);

                }

                if (founderUser.EmailConfirmed == false)
                {
                    ViewBag.Ms = "Zehmet olmasa Emailinizi testiq edin....";
                    return View(user);
                }

                //Eger database isdifadeci user deyilse onda gire bilmez.

                if (!await userManager.IsInRoleAsync(founderUser, "User"))
                {
                    ViewBag.Ms = "Isdifadeci sifresi ve parol sefdir gagas";
                    return View(user);
                }




                if (founderUser.Activates == false)
                {
                    ViewBag.ms = "Siz admin terefinden banlanmisiz";
                    return View(user);
                }

                if (founderUser.Activates == true)
                {
                    var sRuselt = await signInManager.PasswordSignInAsync(founderUser, user.Password, true, true); //Burda giwi edirik.

                    if (sRuselt.Succeeded != true) // Eger giriw zamani ugurlu deyilse yeni gire bilmirse 
                    {
                        ViewBag.Ms = "Isdifadeci sifresi ve parol sefdir gagas";
                        return View(user);

                    }
                    var redirectUrl = Request.Query["ReturnUrl"];

                    if (!string.IsNullOrWhiteSpace(redirectUrl))
                    {
                        return Redirect(redirectUrl);
                    }

                    return RedirectToAction("Index", "Home");

                }
            }

            ViewBag.Ms = "Melumatlari doldur gagas";
            return View(user);
        }


        [HttpPost]
        [Route("/Subscrice.html")]
        public IActionResult Subscrice([Bind("Email")] Subscrice model)
        {

            if (ModelState.IsValid)
            {
                var current = db.Subscrices.FirstOrDefault(s => s.Email.Equals(model.Email));
                if (current != null && current.EmailConfirmed == true)
                {
                    return Json(new
                    {

                        error = true,
                        massege = "Bu E-Mail evvelceden qeydiyyati edilib"

                    });
                }
                else if (current != null && (current.EmailConfirmed ?? false == false))
                {
                    return Json(new
                    {

                        error = true,
                        massege = "Bu E-Mail evvelceden qeydiyyati edilib "

                    });
                }


                db.Subscrices.Add(model);
                db.SaveChanges();


                string token = $"subscribetoken-{model.Id}-{DateTime.Now:yyyyMMddHHmmss}"; // token yeni id goturuk

                token = token.Encrypt("");

                string path = $"{Request.Scheme}://{Request.Host}/subscribe-confirm?token={token}"; // path duzeldirik



                var mailSended = configuration.SendEmail(model.Email, "MaklerSamxaldi seyfesi gagas", $"Siz yeni melumatlardan xederdar olacaqsiniz");
                if (mailSended == false)
                {
                    db.Database.RollbackTransaction();

                    return Json(new
                    {
                        error = false,
                        massege = "Email-gonderilmasi zamini xeta bas verdi!"

                    });
                }

                return Json(new
                {

                    error = false,
                    massege = "Sorgunuz ugurla qeyde alindi!!"

                });
            }



            return Json(new
            {

                error = true,
                massege = "Sorgunuzun Icrasi zamani xeta yarandi,Zehmet olmasa yeniden yoxlayin"

            });
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("subscribe-confirmm")]
        public IActionResult SubscibeConfirm(string token)
        {


            token = token.Decrypte("");

            Match match = Regex.Match(token, @"subscribetoken-(?<id>[a-zA-Z0-9]*)(.*)-(?<timeStampt>\d{14})");

            if (match.Success)
            {
                string id = match.Groups["id"].Value;
                string executeTimeStamp = match.Groups["executeTimeStamp"].Value;

                var subsc = db.Users.FirstOrDefault(s => s.UserName == id);

                if (subsc == null)
                {
                    ViewBag.ms = Tuple.Create(true, "Token xetasi");
                    goto end;
                }
                if (subsc.EmailConfirmed == true)
                {
                    ViewBag.ms = Tuple.Create(true, "Artiq tesdiq edildi");
                    goto end;
                }
                subsc.EmailConfirmed = true;
                db.SaveChanges();

                ViewBag.ms = Tuple.Create(false, "Abuneliyiniz tesdiq edildi");

            }
        end:
            return View();
        }



        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Signin));
        }


        public IActionResult Accessdenied()
        {
            return View();
        }
    }
}
