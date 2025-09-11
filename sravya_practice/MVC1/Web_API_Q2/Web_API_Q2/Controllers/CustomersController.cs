using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Web_API_Q2.Models;

namespace Web_API_Q2.Controllers
{
    public class CustomersController : ApiController
    {
        private readonly northwindEntities db = new northwindEntities();

        // GET: api/customers/bycountry?country=Germany
        [HttpGet]
        [Route("api/customers/bycountry")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var customers = db.GetCustomersByCountry(country).ToList();

            if (!customers.Any())
                return NotFound();

            return Ok(customers);
        }
    }

}