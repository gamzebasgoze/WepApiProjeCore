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
    public class BankaDetayController : ControllerBase
    {
        private IBankaDetayRepository bankadetayRepository;

        private IWebHostEnvironment webHostEnvironment;

        public BankaDetayController(IBankaDetayRepository repo, IWebHostEnvironment environment)
        {
            bankadetayRepository = repo;
            webHostEnvironment = environment;
        }


        [HttpGet]
        public IEnumerable<BankaDetay> GetBankaDetay()
        {
            return bankadetayRepository.GetAllBankaDetay().ToList();
        }

        [HttpGet("{id}")]
        public BankaDetay GetBankaDetayById(int id)
        {
            return bankadetayRepository.GetBankaDetayById(id);
        }



        [HttpPost]
        public BankaDetay Create([FromBody] BankaDetay bankadetay)
        {
            return bankadetayRepository.AddBankaDetay(bankadetay);
        }



        [HttpPut]
        public BankaDetay Update([FromForm] BankaDetay bankadetay)
        {
            return bankadetayRepository.UpdateBankaDetay(bankadetay);
        }


        [HttpDelete("{id}")]
        public void Delete(int? id) => bankadetayRepository.DeleteBankaDetay(id);
    }
}
