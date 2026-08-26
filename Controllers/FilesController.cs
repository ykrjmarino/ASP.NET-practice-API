using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace CityInfo.API.Controllers;

[ApiController]
[Route("api/[controller]")]

public class FilesController : ControllerBase
{
  private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

  public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
  {
    _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider ?? throw new System.ArgumentNullException(
      nameof(fileExtensionContentTypeProvider));
  }

  [HttpGet("{fileId}")]
  public ActionResult GetFile(string fileId)
  {
    //look up actual file
    var pathToFile = "try-exampleCode.md";

    //check if file exists
    if (!System.IO.File.Exists(pathToFile)) return NotFound();

    if (!_fileExtensionContentTypeProvider.TryGetContentType(pathToFile, out var contentType))
    {
      contentType = "application/octet-stream"; //default type
    }

    var bytes = System.IO.File.ReadAllBytes(pathToFile);
    return File(bytes, contentType, Path.GetFileName(pathToFile));
  }

  
}
