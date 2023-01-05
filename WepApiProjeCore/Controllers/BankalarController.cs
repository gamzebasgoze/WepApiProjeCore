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
    public class BankalarController : ControllerBase
    {
        private IBankalarRepository bankalarRepository;

        private IWebHostEnvironment webHostEnvironment;

        public BankalarController(IBankalarRepository repo, IWebHostEnvironment environment)
        {
            bankalarRepository = repo;
            webHostEnvironment = environment;
        }


        [HttpGet]
        public IEnumerable<Bankalar> GetBankalar()
        {
            return bankalarRepository.GetAllBankalar().ToList();
        }

        [HttpGet("{id}")]
        public Bankalar GetBankalarById(int id)
        {
            return bankalarRepository.GetBankalarById(id);
        }



        [HttpPost]
        public Bankalar Create([FromBody] Bankalar bankalar)
        {
            return bankalarRepository.AddBankalar(bankalar);
        }



        [HttpPut]
        public Bankalar Update([FromForm] Bankalar bankalar)
        {
            return bankalarRepository.UpdateBankalar(bankalar);
        }


        [HttpDelete("{id}")]
        public void Delete(int? id) => bankalarRepository.DeleteBankalar(id);
    }
}
