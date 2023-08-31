using BhdBankClone.Core.Application.Exceptions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Text.Json;
using BhdBankClone.Core.Application.Wrappers;

namespace BhdBankCloneApi.Middlewares
{
  public class ErrorHandleMiddleware
  {
    private readonly RequestDelegate _next;

    public ErrorHandleMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
      try
      {
        await _next(httpContext);
      }
      catch (Exception error)
      {
        var response = httpContext.Response;
        response.ContentType = "application/json";

        //if error.InnerException

        var responseModel = new Response<string>() { Succeeded = false, Message = error?.Message };

        if (error is ApiException apiException)
        {
          if (apiException.ValidationErrors != null)
          {
            foreach (var valError in apiException.ValidationErrors)
            {
              Console.WriteLine(valError.ToString());
              responseModel.Errors.Add(valError.ToString());
            }
          } else
          {
            responseModel.Errors = null;
          }
        }

        switch (error)
        {
          case ApiException e:
            switch (e.StatusCode)
            {
              case (int)HttpStatusCode.BadRequest:
                response.StatusCode = (int)HttpStatusCode.BadRequest; //400
                break;

              case (int)HttpStatusCode.NotFound:
                response.StatusCode = (int)HttpStatusCode.NotFound; //404
                break;

              default:
                response.StatusCode = (int)HttpStatusCode.InternalServerError; //500
                break;
            }
            break;

          case KeyNotFoundException e:
            response.StatusCode = (int)HttpStatusCode.NotFound; //404
            break;

          default:
            response.StatusCode = (int)HttpStatusCode.InternalServerError; //500
            break;
        }

        var result = JsonSerializer.Serialize(responseModel);
        await response.WriteAsync(result);

      }
    }
  }
}
