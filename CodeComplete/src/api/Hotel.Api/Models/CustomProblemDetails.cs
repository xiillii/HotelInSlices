using Microsoft.AspNetCore.Mvc;

namespace Hote.Api.Models;

class CustomProblemDetails : ProblemDetails
{
  public IDictionary<string, string[]> Errors { get; set; } = new Dictionary<string, string[]>();
}
