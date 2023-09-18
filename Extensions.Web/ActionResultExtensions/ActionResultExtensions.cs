using System.Net; 
using Extensions.Web.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Extensions.Web.ActionResultExtensions;

public static class ActionResultExtensions
{
    public static ActionResult HandleResult<T>(this ActionResult action, Result<T> result)
    {
        switch (result.StatusCode)
        {
            case HttpStatusCode.OK:
                return new OkObjectResult(result.Value);
            case HttpStatusCode.NotFound:
                return CreateResponse(HttpStatusCode.NotFound, result.Error);
            case HttpStatusCode.BadRequest:
                return new BadRequestObjectResult(result.Error);
            case HttpStatusCode.Unauthorized:
                return new UnauthorizedObjectResult(result.Error);
            default:
                return CreateResponse(HttpStatusCode.InternalServerError, result.Error);
        }
    }
    
    public static ActionResult HandleResult(this ActionResult action, Result result)
    {
        switch (result.StatusCode)
        {
            case HttpStatusCode.OK:
                return CreateResponse(HttpStatusCode.OK);
            case HttpStatusCode.NotFound:
                return CreateResponse(HttpStatusCode.NotFound, result.Error);
            case HttpStatusCode.BadRequest:
                return new BadRequestObjectResult(result.Error);
            case HttpStatusCode.Unauthorized:
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