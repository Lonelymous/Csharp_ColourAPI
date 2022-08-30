using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ColoursAPI.Models;
using ColoursAPI.Data;

namespace ColoursAPI.Controllers
{
    [Route("api/[controller]/[action]")]
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

        // Get
        [HttpGet]
        public JsonResult Get(int id)
        {
            var result = _context.Colours.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            
            return new JsonResult(Ok(result));
        }

        // Get all
        [HttpGet]
        public JsonResult GetAll()
        {
            var result = _context.Colours.ToList();

            return new JsonResult(Ok(result));
        }

        // Delete
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            var result = _context.Colours.Find(id);

            if (result == null)
            {
                return new JsonResult(NotFound());
            }
            _context.Colours.Remove(result);
            _context.SaveChanges();
            return new JsonResult(NoContent());
        }
    }
}
