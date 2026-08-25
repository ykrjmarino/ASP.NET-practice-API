using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Models.DTOs;

public class CityDto //what the servers returns to the client
{
  public int Id { get; set; }
  public string Name { get; set; } = string.Empty; //Not nullable = set to " " string
  public string ? Description { get;set; } //Nullable
  public int NumberOfPointsOfInterest
  {
    get
    {
      return PointsOfInterest.Count;
    }
  }
  public ICollection<PointsOfInterestDto> PointsOfInterest { get; set;} = [];
}