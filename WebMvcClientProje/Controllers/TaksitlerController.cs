using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebMvcClientProje.Models;

namespace WebMvcClientProje.Controllers
{
    public class TaksitlerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Taksitler> taksitlerList = new List<Taksitler>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/Taksitler"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    taksitlerList = JsonConvert.DeserializeObject<List<Taksitler>>(apiResponse);
                }
            }
            return View(taksitlerList);
        }
        public ViewResult GetTaksitler() => View();


        [HttpPost]
        public async Task<IActionResult> GetTaksitler(int id)
        {
            Taksitler taksitler = new Taksitler();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/Taksitler/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    taksitler = JsonConvert.DeserializeObject<Taksitler>(apiResponse);
                }
            }
            return View(taksitler);
        }

        [HttpGet]
        public ViewResult AddTaksitler() => View();

        [HttpPost]

        public async Task<IActionResult> AddTaksitler(Taksitler taksitler)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(taksitler), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44339/api/Taksitler", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        taksitler = JsonConvert.DeserializeObject<Taksitler>(apiResponse);
                    }
                }
                return View(taksitler);
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateTaksitler(int id)
        {
            Taksitler taksitler = new Taksitler();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/Taksitler/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    taksitler = JsonConvert.DeserializeObject<Taksitler>(apiResponse);
                }
            }
            return View(taksitler);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTaksitler(Taksitler taksitler)
        {
            Taksitler bnk = new Taksitler();
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(taksitler.TaksitID.ToString()), "TaksitID");
                    content.Add(new StringContent(taksitler.BankaID.ToString()), "BankaID");
                    content.Add(new StringContent(taksitler.Taksit.ToString()), "Taksit");
                    content.Add(new StringContent(taksitler.EkTaksit.ToString()), "EkTaksit");
                    content.Add(new StringContent(taksitler.VadeFarki.ToString()), "VadeFarki");
                    content.Add(new StringContent(taksitler.Aciklama), "Aciklama");
                    using (var response = await httpClient.PutAsync("https://localhost:44339/api/Taksitler", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        bnk = JsonConvert.DeserializeObject<Taksitler>(apiResponse);
                    }
                }
            }
            return View(bnk);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTaksitler(int TaksitID)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44339/api/Taksitler/" + TaksitID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
