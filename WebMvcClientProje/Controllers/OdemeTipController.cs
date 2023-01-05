using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebMvcClientProje.Models;

namespace WebMvcClientProje.Controllers
{
    public class OdemeTipController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<OdemeTip> odemetipList = new List<OdemeTip>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/OdemeTip"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    odemetipList = JsonConvert.DeserializeObject<List<OdemeTip>>(apiResponse);
                }
            }
            return View(odemetipList);
        }
        public ViewResult GetOdemeTip() => View();


        [HttpPost]
        public async Task<IActionResult> GetOdemeTip(int id)
        {
            OdemeTip odemetip = new OdemeTip();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/OdemeTip/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    odemetip = JsonConvert.DeserializeObject<OdemeTip>(apiResponse);
                }
            }
            return View(odemetip);
        }

        [HttpGet]
        public ViewResult AddOdemeTip() => View();

        [HttpPost]

        public async Task<IActionResult> AddOdemeTip(OdemeTip odemetip)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(odemetip), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync("https://localhost:44339/api/OdemeTip", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        odemetip = JsonConvert.DeserializeObject<OdemeTip>(apiResponse);
                    }
                }
                return View(odemetip);
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> UpdateOdemeTip(int id)
        {
            OdemeTip odemetip = new OdemeTip();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44339/api/OdemeTip/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    odemetip = JsonConvert.DeserializeObject<OdemeTip>(apiResponse);
                }
            }
            return View(odemetip);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateOdemeTip(OdemeTip odemetip)
        {
            OdemeTip bnk = new OdemeTip();
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StringContent(odemetip.OdemeID.ToString()), "OdemeID");
                    content.Add(new StringContent(odemetip.OdemeTipi), "OdemeTipi");
                    using (var response = await httpClient.PutAsync("https://localhost:44339/api/OdemeTip", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        ViewBag.Result = "Success";
                        bnk = JsonConvert.DeserializeObject<OdemeTip>(apiResponse);
                    }
                }
            }
            return View(bnk);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteOdemeTip(int OdemeID)
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44339/api/OdemeTip/" + OdemeID))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }

    }
}
