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
    public class SiparislerController : ControllerBase
    {
        private ISiparislerRepository siparislerRepository;

        private IWebHostEnvironment webHostEnvironment;

        public SiparislerController(ISiparislerRepository repo, IWebHostEnvironment environment)
        {
            siparislerRepository = repo;
            webHostEnvironment = environment;
        }


        [HttpGet]
        public IEnumerable<Siparisler> GetSiparisler()
        {
            return siparislerRepository.GetAllSiparisler().ToList();
        }

        [HttpGet("{id}")]
        public Siparisler GetSiparislerById(int id)
        {
            return siparislerRepository.GetSiparislerById(id);
        }



        [HttpPost]
        public Siparisler Create([FromBody] Siparisler siparisler)
        {
            return siparislerRepository.AddSiparisler(siparisler);
        }



        [HttpPut]
        public Siparisler Update([FromForm] Siparisler siparisler)
        {
            return siparislerRepository.UpdateSiparisler(siparisler);
        }


        [HttpDelete("{id}")]
        public void Delete(int? id) => siparislerRepository.DeleteSiparisler(id);
    }
}
