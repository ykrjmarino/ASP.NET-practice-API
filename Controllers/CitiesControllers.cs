using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers; //file scoped namespace (whole file)

[ApiController]
[Route("api/[controller]")] // sets the URL prefix — "[controller]" auto-fills with the class name
public class CitiesController : ControllerBase //api/cities
{
  [HttpGet]
  public JsonResult GetCities()
  {
    return new JsonResult(
      new List<object>
      {
        new { id = 1, Name = "New York City" },
        new { id = 2, Name = "Antwerp" }
      });
  }
}
