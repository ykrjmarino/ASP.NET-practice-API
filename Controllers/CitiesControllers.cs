using CityInfo.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers; //file scoped namespace (whole file)

[ApiController]
[Route("api/[controller]")] // sets the URL prefix — "[controller]" auto-fills with the class name
public class CitiesController : ControllerBase 
{
  //private readonly AppDbContext _dbContext;

  [HttpGet]
  public JsonResult GetCities()
  {
    return new JsonResult(CitiesDataStore.Current.Cities);
  }

  [HttpGet("{id}")]
  public IActionResult GetOneCity(int id)
  {
    try{
      var cityReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
      return Ok(cityReturn);
    }
    catch (Exception ex){
      return StatusCode(500, $"Something went wrong: {ex.Message}");
    }
  }

  // [HttpPost]
  // public 


  
}
