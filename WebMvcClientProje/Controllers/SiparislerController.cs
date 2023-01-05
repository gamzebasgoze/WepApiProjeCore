using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebMvcClientProje.Models;

namespace WebMvcClientProje.Controllers
{
    public class SiparislerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Siparisler> siparislerList = new List<Siparisler>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/Siparisler"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    siparislerList = JsonConvert.DeserializeObject<List<Siparisler>>(apiResponse);
                }
            }
            return View(siparislerList);
        }
        public ViewResult GetSiparisler() => View();


        [HttpPost]
        public async Task<IActionResult> GetSiparisler(int id)
        {
            Siparisler siparisler = new Siparisler();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/Siparisler/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    siparisler = JsonConvert.DeserializeObject<Siparisler>(apiResponse);
                }
            }
            return View(siparisler);
        }

        [HttpGet]
        public ViewResult AddSiparisler() => View();

        [HttpPost]

        public async Task<IActionResult> AddSiparisler(Siparisler siparisler)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(siparisler), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44339/api/Siparisler", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        siparisler = JsonConvert.DeserializeObject<Siparisler>(apiResponse);
                    }
                }
                return View(siparisler);
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateSiparisler(int id)
        {
            Siparisler siparisler = new Siparisler();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/Siparisler/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    siparisler = JsonConvert.DeserializeObject<Siparisler>(apiResponse);
                }
            }
            return View(siparisler);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSiparisler(Siparisler siparisler)
        {
            Siparisler bnk = new Siparisler();
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(siparisler.SiparislerID.ToString()), "SiparislerID");
                    content.Add(new StringContent(siparisler.UyeID.ToString()), "UyeID");
                    content.Add(new StringContent(siparisler.SiparisTipi), "SiparisTipi");
                    content.Add(new StringContent(siparisler.SiparisTarih), "SiparisTarih");
                    content.Add(new StringContent(siparisler.Adet.ToString()), "Adet");
                    content.Add(new StringContent(siparisler.Tutar.ToString()), "Tutar");
                    content.Add(new StringContent(siparisler.Aciklama), "Aciklama");
                    using (var response = await httpClient.PutAsync("https://localhost:44339/api/Siparisler", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        bnk = JsonConvert.DeserializeObject<Siparisler>(apiResponse);
                    }
                }
            }
            return View(bnk);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteSiparisler(int SiparislerID)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44339/api/Siparisler/" + SiparislerID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
