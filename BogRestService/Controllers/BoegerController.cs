using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookTest;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BogRestService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoegerController : ControllerBase
    {
        static List<Bog> bogList = new List<Bog>()
        {
           new Bog("Karsten", "Know your meme", 550, "1234567890123"),
           new Bog("Karl", "Wisdom of the pool", 750, "1234567890124"),
           new Bog("Dio", "How to za warudo!", 890, "1234567890125")
        };
        // GET: api/Boeger
        [HttpGet]
        public IEnumerable<Bog> Get()
        {
            return bogList;
        }

        // GET: api/Boeger/5
        [HttpGet("{isbn}", Name = "Get")]
        public Bog Get(string isbn)
        {
            return bogList.Find(b => b.Isbn == isbn);
        }

        // POST: api/Boeger
        [HttpPost]
        public void Post([FromBody] Bog b)
        {
            bogList.Add(b);
        }

        // PUT: api/Boeger/5
        [HttpPut("{isbn}")]
        public void Put(string isbn, [FromBody] Bog b)
        {
            Bog bog = Get(isbn);
            if (bog != null)
            {
                bog.Titel = b.Titel;
                bog.Forfatter = b.Forfatter;
                bog.Sidetal = b.Sidetal;
                bog.Isbn = b.Isbn;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{isbn}")]
        public void Delete(string isbn)
        {
            Bog b = Get(isbn);
            if (b != null)
            {
                bogList.Remove(b);
            }
        }
    }
}
