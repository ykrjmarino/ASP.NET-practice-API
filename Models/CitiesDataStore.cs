using CityInfo.API.Models.DTOs;

namespace CityInfo.API.Models;

public class CitiesDataStore
{
  public List<CityDto> Cities { get; set; }
  public static CitiesDataStore Current { get; } = new CitiesDataStore();

  public CitiesDataStore()
  {
    Cities =
    [
      new CityDto()
      {
        Id = 1,
        Name = "NYC",
        Description = "niw york",
        PointsOfInterest = new List<PointsOfInterestDto>()
        {
          new PointsOfInterestDto() {
            Id = 1,
            Name = "Central Park",
            Description = "central park, i think sa prototype",
          },
          new PointsOfInterestDto() {
            Id = 2,
            Name = "Empire State Building",
            Description = "inaakyat ko lang yan",
          }
        }
      },
      new CityDto()
      {
        Id = 2,
        Name = "Poland",
        Description = "powland",
        PointsOfInterest = new List<PointsOfInterestDto>()
        {
          new PointsOfInterestDto() {
            Id = 3,
            Name = "Park",
            Description = "ewan ba park lng",
          },
          new PointsOfInterestDto() {
            Id = 4,
            Name = "Wall",
            Description = "bug repellent",
          }
        }
      },
      new CityDto()
      {
        Id = 3,
        Name = "USA",
        Description = "rahh",
        PointsOfInterest = new List<PointsOfInterestDto>()
        {
          new PointsOfInterestDto() {
            Id = 5,
            Name = "Texas",
            Description = "horses and shi",
          }
        }
      }
    ];
  }
}
