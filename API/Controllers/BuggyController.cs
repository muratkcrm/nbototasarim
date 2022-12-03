using API.Errors;
using API.Infrastructure.DataContext;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _context;
        public BuggyController(StoreContext context)
        {
            _context = context;
        }
        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var product = _context.Products.Find(5);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(new ApiResponse(401));
        }
        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var product = _context.Products.Find(5);
            var productToReturn = product.ToString();
            if (product == null)
            {
                return NotFound();
            }
            return Ok(new ApiResponse(500));
        }
        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return BadRequest(new ApiResponse(404));
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFoundRequest(int id)
        {
            return Ok(new ApiResponse(400));
        }

    }
}
