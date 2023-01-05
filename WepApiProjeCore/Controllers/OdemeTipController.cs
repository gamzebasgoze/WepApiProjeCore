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
    public class OdemeTipController : ControllerBase
    {
        private IOdemeTipRepository odemetipRepository;

        private IWebHostEnvironment webHostEnvironment;

        public OdemeTipController(IOdemeTipRepository repo, IWebHostEnvironment environment)
        {
            odemetipRepository = repo;
            webHostEnvironment = environment;
        }


        [HttpGet]
        public IEnumerable<OdemeTip> GetOdemeTip()
        {
            return odemetipRepository.GetAllOdemeTip().ToList();
        }

        [HttpGet("{id}")]
        public OdemeTip GetOdemeTipById(int id)
        {
            return odemetipRepository.GetOdemeTipById(id);
        }



        [HttpPost]
        public OdemeTip Create([FromBody] OdemeTip odemetip)
        {
            return odemetipRepository.AddOdemeTip(odemetip);
        }



        [HttpPut]
        public OdemeTip Update([FromForm] OdemeTip odemetip)
        {
            return odemetipRepository.UpdateOdemeTip(odemetip);
        }


        [HttpDelete("{id}")]
        public void Delete(int? id) => odemetipRepository.DeleteOdemeTip(id);
    }
}
