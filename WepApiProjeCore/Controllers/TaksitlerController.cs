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
    public class TaksitlerController : ControllerBase
    {
        private ITaksitlerRepository taksitlerRepository;

        private IWebHostEnvironment webHostEnvironment;

        public TaksitlerController(ITaksitlerRepository repo, IWebHostEnvironment environment)
        {
            taksitlerRepository = repo;
            webHostEnvironment = environment;
        }


        [HttpGet]
        public IEnumerable<Taksitler> GetTaksitler()
        {
            return taksitlerRepository.GetAllTaksitler().ToList();
        }

        [HttpGet("{id}")]
        public Taksitler GetTaksitlerById(int id)
        {
            return taksitlerRepository.GetTaksitlerById(id);
        }



        [HttpPost]
        public Taksitler Create([FromBody] Taksitler taksitler)
        {
            return taksitlerRepository.AddTaksitler(taksitler);
        }



        [HttpPut]
        public Taksitler Update([FromForm] Taksitler taksitler)
        {
            return taksitlerRepository.UpdateTaksitler(taksitler);
        }


        [HttpDelete("{id}")]
        public void Delete(int? id) => taksitlerRepository.DeleteTaksitler(id);
    }
}
