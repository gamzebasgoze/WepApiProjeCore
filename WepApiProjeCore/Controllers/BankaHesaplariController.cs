using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WepApiProjeCore.Models;

namespace WepApiProjeCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankaHesaplariController : ControllerBase
    {
        private IBankaHesaplariRepository bankahesaplariRepository;

        private IWebHostEnvironment webHostEnvironment;

        public BankaHesaplariController(IBankaHesaplariRepository repo, IWebHostEnvironment environment)
        {
            bankahesaplariRepository = repo;
            webHostEnvironment = environment;
        }


        [HttpGet]
        public IEnumerable<BankaHesaplari> GetBankaHesaplari()
        {
            return bankahesaplariRepository.GetAllBankaHesaplari().ToList();
        }

        [HttpGet("{id}")]
        public BankaHesaplari GetBankaHesaplariById(int id)
        {
            return bankahesaplariRepository.GetBankaHesaplariById(id);
        }



        [HttpPost]
        public BankaHesaplari Create([FromBody] BankaHesaplari bankahesaplari)
        {
            return bankahesaplariRepository.AddBankaHesaplari(bankahesaplari);
        }



        [HttpPut]
        public BankaHesaplari Update([FromForm] BankaHesaplari bankahesaplari)
        {
            return bankahesaplariRepository.UpdateBankaHesaplari(bankahesaplari);
        }


        [HttpDelete("{id}")]
        public void Delete(int? id) => bankahesaplariRepository.DeleteBankaHesaplari(id);
    }
}
