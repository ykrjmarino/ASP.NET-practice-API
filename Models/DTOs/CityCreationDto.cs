using Microsoft.AspNetCore.Mvc;

namespace CityInfo.API.Models.DTOs;

public class CityCreationDto 
{
  //public int Id { get; set; } //should be automatically created
  public string Name { get; set; } = string.Empty; 
  public string ? Description { get;set; }
}