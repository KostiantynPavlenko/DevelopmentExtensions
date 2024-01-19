using System.Net; 
using Extensions.Web.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Extensions.Web.ActionResultExtensions;

public static class ActionResultExtensions
{
    public static ActionResult HandleResult<T>(this ActionResult action, Result<T> result)
    {
        switch (result.State)
        {
            case ResultState.Ok:
                return new OkObjectResult(result.Value);
            case ResultState.NotFound:
                return CreateResponse(HttpStatusCode.NotFound, result.Error);
            case ResultState.BadRequest:
                return new BadRequestObjectResult(result.Error);
            case ResultState.Unauthorized:
                return new UnauthorizedObjectResult(result.Error);
            default:
                return CreateResponse(HttpStatusCode.InternalServerError, result.Error);
        }
    }
    
    public static ActionResult HandleResult(this ActionResult action, Result result)
    {
        switch (result.State)
        {
            case ResultState.Ok:
                return CreateResponse(HttpStatusCode.OK);
            case ResultState.NotFound:
                return CreateResponse(HttpStatusCode.NotFound, result.Error);
            case ResultState.BadRequest:
                return new BadRequestObjectResult(result.Error);
            case ResultState.Unauthorized:
                return new UnauthorizedObjectResult(result.Error);
            default:
                return CreateResponse(HttpStatusCode.InternalServerError, result.Error);
        }
    }
    
    private static ActionResult CreateResponse(HttpStatusCode statusCode, Error error = null)
    {
        var response = new ObjectResult(error)
        {
            StatusCode = (int)statusCode
        };

        return response;
    }
}