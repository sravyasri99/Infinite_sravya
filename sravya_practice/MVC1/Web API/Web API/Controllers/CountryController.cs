using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API.Models;

namespace Web_API.Controllers
{
    public class CountryController : ApiController
    {
        private static List<Country> countries = new List<Country>
        {
            new Country { CountryId = 1, CountryName = "India", Capital = "Delhi" },
            new Country { CountryId = 2, CountryName = "France", Capital = "Paris" },
            new Country { CountryId = 3, CountryName = "England", Capital = "Londan" },
            new Country { CountryId = 4, CountryName = "USA", Capital = "Washington" }
        };
        [HttpGet]
        public HttpResponseMessage GetAllPersons()
        {
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, countries);
            return response;
        }

        [HttpGet]
        [Route("ByCountryId")]
        public IHttpActionResult GetCountryNameById(int CID)
        {
            string cname = countries.Where(c => c.CountryId == CID).SingleOrDefault()?.CountryName;
            if (cname == null)
            {
                return NotFound();
            }
            return Ok(cname);
        }
        [HttpPost]
        public List<Country> PostAll([FromBody] Country c)
        {
            countries.Add(c);
            return countries;
        }

        [HttpPut]

        public IEnumerable<Country> Put(int CountryId, [FromUri] Country c)
        {
            countries[CountryId - 1] = c;
            return countries;
        }

        [HttpDelete]

        public IEnumerable<Country> Delete(int CountryId)
        {
            countries.RemoveAt(CountryId - 1);
            return countries;
        }

    }
}