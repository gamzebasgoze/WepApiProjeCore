using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebMvcClientProje.Models;

namespace WebMvcClientProje.Controllers
{
    public class BankaDetayController: Controller
    {
        public async Task<IActionResult> Index()
        {
            List<BankaDetay> bankadetayList = new List<BankaDetay>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/BankaDetay"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bankadetayList = JsonConvert.DeserializeObject<List<BankaDetay>>(apiResponse);
                }
            }
            return View(bankadetayList);
        }
        public ViewResult GetBankaDetay() => View();


        [HttpPost]
        public async Task<IActionResult> GetBankaDetay(int id)
        {
            BankaDetay bankadetay = new BankaDetay();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/BankaDetay/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bankadetay = JsonConvert.DeserializeObject<BankaDetay>(apiResponse);
                }
            }
            return View(bankadetay);
        }

        [HttpGet]
        public ViewResult AddBankaDetay() => View();

        [HttpPost]

        public async Task<IActionResult> AddBankaDetay(BankaDetay bankadetay)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(bankadetay), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44339/api/BankaDetay", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        bankadetay = JsonConvert.DeserializeObject<BankaDetay>(apiResponse);
                    }
                }
                return View(bankadetay);
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateBankaDetay(int id)
        {
            BankaDetay bankadetay = new BankaDetay();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/BankaDetay/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    bankadetay = JsonConvert.DeserializeObject<BankaDetay>(apiResponse);
                }
            }
            return View(bankadetay);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBankaDetay(BankaDetay bankadetay)
        {
            BankaDetay bnk = new BankaDetay();
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(bankadetay.BankaDetayID.ToString()), "BankaDetayID");
                    content.Add(new StringContent(bankadetay.BankaID.ToString()), "BankaID");
                    content.Add(new StringContent(bankadetay.KullaniciAdi), "KullaniciAdi");
                    content.Add(new StringContent(bankadetay.Sifre), "Sifre");
                    content.Add(new StringContent(bankadetay.MagazaNo), "MagazaNo");
                    content.Add(new StringContent(bankadetay.Host), "Host");
                    using (var response = await httpClient.PutAsync("https://localhost:44339/api/BankaDetay", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        bnk = JsonConvert.DeserializeObject<BankaDetay>(apiResponse);
                    }
                }
            }
            return View(bnk);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBankaDetay(int BankaDetayID)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44339/api/BankaDetay/" + BankaDetayID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
