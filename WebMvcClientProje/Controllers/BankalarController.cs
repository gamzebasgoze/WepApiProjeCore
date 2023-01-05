using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebMvcClientProje.Models;

namespace WebMvcClientProje.Controllers
{
    public class BankalarController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Bankalar> bankalarList = new List<Bankalar>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/Bankalar"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bankalarList = JsonConvert.DeserializeObject<List<Bankalar>>(apiResponse);
                }
            }
            return View(bankalarList);
        }
        public ViewResult GetBankalar() => View();


        [HttpPost]
        public async Task<IActionResult> GetBankalar(int id)
        {
            Bankalar bankalar = new Bankalar();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/Bankalar/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bankalar = JsonConvert.DeserializeObject<Bankalar>(apiResponse);
                }
            }
            return View(bankalar);
        }

        [HttpGet]
        public ViewResult AddBankalar() => View();

        [HttpPost]

        public async Task<IActionResult> AddBankalar(Bankalar bankalar)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(bankalar), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44339/api/Bankalar", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        bankalar = JsonConvert.DeserializeObject<Bankalar>(apiResponse);
                    }
                }
                return View(bankalar);
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateBankalar(int id)
        {
            Bankalar bankalar = new Bankalar();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/Bankalar/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bankalar = JsonConvert.DeserializeObject<Bankalar>(apiResponse);
                }
            }
            return View(bankalar);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBankalar(Bankalar bankalar)
        {
            Bankalar bnk = new Bankalar();
            if (ModelState.IsValid) 
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(bankalar.BankaID.ToString()), "BankaID");
                    content.Add(new StringContent(bankalar.BankaAdi), "BankaAdi");
                    content.Add(new StringContent(bankalar.BankaLogo), "BankaLogo");
                    content.Add(new StringContent(bankalar.Aktif), "Aktif");
                    using (var response = await httpClient.PutAsync("https://localhost:44339/api/Bankalar", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        bnk = JsonConvert.DeserializeObject<Bankalar>(apiResponse);
                    }
                }
            }
            return View(bnk);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBankalar(int BankaID)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44339/api/Bankalar/" + BankaID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }

    }
}
