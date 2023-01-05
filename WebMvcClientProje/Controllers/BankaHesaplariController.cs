using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebMvcClientProje.Models;

namespace WebMvcClientProje.Controllers
{
    public class BankaHesaplariController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<BankaHesaplari> bankahesaplariList = new List<BankaHesaplari>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/BankaHesaplari"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bankahesaplariList = JsonConvert.DeserializeObject<List<BankaHesaplari>>(apiResponse);
                }
            }
            return View(bankahesaplariList);
        }
        public ViewResult GetBankaHesaplari() => View();


        [HttpPost]
        public async Task<IActionResult> GetBankaHesaplari(int id)
        {
            BankaHesaplari bankahesaplari = new BankaHesaplari();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/BankaHesaplari/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bankahesaplari = JsonConvert.DeserializeObject<BankaHesaplari>(apiResponse);
                }
            }
            return View(bankahesaplari);
        }

        [HttpGet]
        public ViewResult AddBankaHesaplari() => View();

        [HttpPost]

        public async Task<IActionResult> AddBankaHesaplari(BankaHesaplari bankahesaplari)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(bankahesaplari), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44339/api/BankaHesaplari", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        bankahesaplari = JsonConvert.DeserializeObject<BankaHesaplari>(apiResponse);
                    }
                }
                return View(bankahesaplari);
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateBankaHesaplari(int id)
        {
            BankaHesaplari bankahesaplari = new BankaHesaplari();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/BankaHesaplari/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bankahesaplari = JsonConvert.DeserializeObject<BankaHesaplari>(apiResponse);
                }
            }
            return View(bankahesaplari);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBankaHesaplari(BankaHesaplari bankahesaplari)
        {
            BankaHesaplari bnk = new BankaHesaplari();
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(bankahesaplari.BankaHesapID.ToString()), "BankaHesapID");
                    content.Add(new StringContent(bankahesaplari.BankaID.ToString()), "BankaID");
                    content.Add(new StringContent(bankahesaplari.HesapSahibi), "HesapSahibi");
                    content.Add(new StringContent(bankahesaplari.HesapKurTip), "HesapKurTip");
                    content.Add(new StringContent(bankahesaplari.HesapNo), "HesapNo");
                    content.Add(new StringContent(bankahesaplari.IbanNo), "IbanNo");
                    using (var response = await httpClient.PutAsync("https://localhost:44339/api/BankaHesaplari", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        bnk = JsonConvert.DeserializeObject<BankaHesaplari>(apiResponse);
                    }
                }
            }
            return View(bnk);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBankaHesaplari(int BankaHesapID)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44339/api/BankaHesaplari/" + BankaHesapID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
