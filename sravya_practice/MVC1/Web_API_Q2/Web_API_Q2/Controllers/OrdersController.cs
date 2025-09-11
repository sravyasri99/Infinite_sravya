using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using Web_API_Q2.Models; // Adjust this to match your actual namespace

namespace Web_API_Q2.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        private readonly northwindEntities db = new northwindEntities();

        // GET: api/orders/buchanan
        [HttpGet]
        [Route("buchanan")]
        public IHttpActionResult GetOrdersForBuchanan()
        {
            // Disable proxy creation to avoid serialization issues
            db.Configuration.ProxyCreationEnabled = false;

            var orders = db.Orders
                           .Include(o => o.Employee)
                           .Where(o => o.EmployeeID == 5 &&
                                       o.Employee.FirstName == "Steven" &&
                                       o.Employee.LastName == "Buchanan")
                           .ToList();

            if (!orders.Any())
                return NotFound();

            return Ok(orders);
        }
    }
}
