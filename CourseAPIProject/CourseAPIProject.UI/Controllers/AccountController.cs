using CourseAPIProject.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CourseAPIProject.UI.Controllers
{
    public class AccountController : Controller
    {
        HttpClient _client;
        public AccountController()
        {
            _client = new HttpClient();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM vmx, string returnURL=null)
        {
            Console.WriteLine("salam");
            if (!ModelState.IsValid)
            {
                return View();
            }

            StringContent requestContent = new StringContent(JsonConvert.SerializeObject(vmx), System.Text.Encoding.UTF8, "application/json");
            using (var response = await _client.PostAsync("https://localhost:7198/api/Accounts/login", requestContent))
            {
                Console.WriteLine(response.StatusCode.ToString());
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var resp= JsonConvert.DeserializeObject<LoginResponseVM>(content);
                    Response.Cookies.Append("admin_token","Bearer "+ resp.Token);
                    if (returnURL==null)
                    {
                        return RedirectToAction("index", "home");
                    }
                    else
                    {
                        return Redirect(returnURL);
                    }
                }
                if (response.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    ModelState.AddModelError("", "Username or password is not correct!");
                    return View(vmx);
                }
            }
            return View("error");
        }
        public IActionResult Logout()
        {
            Response.Cookies.Append("admin_token", "");
            return RedirectToAction("login");
        }
    }
}
