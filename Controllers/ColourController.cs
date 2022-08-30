using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ColoursAPI.Models;
using ColoursAPI.Data;

namespace ColoursAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColourController : ControllerBase
    {
        private readonly ApiContext _context;

        public ColourController(ApiContext apiContext)
        { 
            _context = apiContext;
        }

        // Create/Edit
        [HttpPost]
        public JsonResult CreateEdit(Colour colour)
        {
            if (colour.Id == 0)
            {
                _context.Colours.Add(colour);
            }
            else
            {
                var colourInDb = _context.Colours.Find(colour.Id);

                if (colourInDb == null)
                {
                    return new JsonResult(NotFound());
                }

                colourInDb = colour;
            }

            _context.SaveChanges();

            return new JsonResult(Ok(colour));
        }
    }
}
