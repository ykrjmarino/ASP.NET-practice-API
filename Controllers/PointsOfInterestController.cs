using CityInfo.API.Models;
using CityInfo.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Controllers;

[ApiController] 
[Route("api/cities/{cityId}/[controller]")] //pointsofinterest

public class PointsOfInterestController : ControllerBase
{
  [HttpGet]
  public ActionResult<IEnumerable<PointsOfInterestDto>> GetPointOfInterest(int cityId)
  {
    try{
      var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

      if (city is null) return NotFound();

      return Ok(city.PointsOfInterest);
    }
    catch (Exception ex){
      return StatusCode(500, $"Something went wrong: {ex.Message}");
    }
  }

  [HttpGet("{poiId}")]
  public ActionResult<PointsOfInterestDto> GetPointOfInterest(int cityId, int poiId)
  {
    try{
      var city = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == cityId);

      if (city is null) return NotFound();

      var poi = city.PointsOfInterest.FirstOrDefault(p => p.Id == poiId);

      if (poi is null) return NotFound();

      return Ok(poi);
    }
    catch (Exception ex){
      return StatusCode(500, $"Something went wrong: {ex.Message}");
    }
  }
}
