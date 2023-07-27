using CourseAPIProject.UI.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace CourseAPIProject.UI.Controllers
{
    public class GroupController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (HttpClient client= new HttpClient())
            {
                var token = Request.Cookies["admin_token"];
                client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);
                using (var response = await client.GetAsync("https://localhost:7198/api/groups"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content =await response.Content.ReadAsStringAsync();
                        GroupVM vm = new GroupVM
                        {
                            Groups = JsonConvert.DeserializeObject<List<GroupVMItem>>(content)
                        };
                         return View(vm);

                      }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        return RedirectToAction("login","account");
                    }
                }
            }
            return View("error");
        }
        public IActionResult Create()
        {
            var token = Request.Cookies["admin_token"];
            if (token==null)
            {
                return RedirectToAction("login", "account");
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(GroupCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            using (HttpClient client = new HttpClient())
            {
                var token = Request.Cookies["admin_token"];
                client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);
                StringContent requestContent = new StringContent(JsonConvert.SerializeObject(vm), System.Text.Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:7198/api/groups",requestContent))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("index");
                    }
                    else if (response.StatusCode==System.Net.HttpStatusCode.BadRequest)
                    {
                        var responseContent =await response.Content.ReadAsStringAsync();
                        var errorList = JsonConvert.DeserializeObject<ErrorVM>(responseContent);

                        foreach (ErrorVMItem item in errorList.Errors)
                        {
                            ModelState.AddModelError(item.Key, item.ErrorMessage);
                        }
                        return View();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        return RedirectToAction("login", "account");
                    }
                }
            }
            return View("error");
        }
        public async Task<IActionResult> Edit(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var token = Request.Cookies["admin_token"];
                client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);
                using (var response = await client.GetAsync($"https://localhost:7198/api/groups/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent =await response.Content.ReadAsStringAsync();
                        var vm = JsonConvert.DeserializeObject<GroupEditVM>(responseContent);
                        return View(vm);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        return RedirectToAction("login", "account");
                    }
                }
            }
            return View("error");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,GroupEditVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            using (HttpClient client = new HttpClient())
            {
                var token = Request.Cookies["admin_token"];
                client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);
                StringContent requestContent =new StringContent(JsonConvert.SerializeObject(vm),System.Text.Encoding.UTF8,"application/json");
                using (var response = await client.PutAsync($"https://localhost:7198/api/groups/{id}",requestContent))
                {
                    if (response.IsSuccessStatusCode)
                    {

                        return RedirectToAction("index");
                    }
                    else if (response.StatusCode==System.Net.HttpStatusCode.BadRequest)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var errorList = JsonConvert.DeserializeObject<ErrorVM>(responseContent);

                        foreach (ErrorVMItem item in errorList.Errors)
                        {
                            ModelState.AddModelError(item.Key, item.ErrorMessage);
                        }
                        return View();
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        return RedirectToAction("login", "account");
                    }
                }
            }
            return View("error");
        }
        public async Task<IActionResult> Delete(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                var token = Request.Cookies["admin_token"];
                client.DefaultRequestHeaders.Add(HeaderNames.Authorization, token);
                using (var response = await client.DeleteAsync($"https://localhost:7198/api/groups/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("index");
                    }
                    else if (response.StatusCode==System.Net.HttpStatusCode.BadRequest)
                    {
                        return RedirectToAction("index");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        return RedirectToAction("login", "account");
                    }

                }
            }
            return View("error");
        }
    }
}
