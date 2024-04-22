using Application.Shared.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using System.Net;
using System.Text.Json;

namespace API.Extensions;

public static class ErrorHandlerExtensions
{
    public static void UseErrorHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature == null) return;

                context.Response.Headers.Add("Access-Control-Allow-Origin", "*");
                context.Response.ContentType = "application/json";

                context.Response.StatusCode = contextFeature.Error switch
                {
                    BadRequestException => (int) HttpStatusCode.BadRequest,
                    OperationCanceledException => (int) HttpStatusCode.ServiceUnavailable,
                    ProductNotFoundException => (int) HttpStatusCode.NotFound,
                    DuplicateException => (int) HttpStatusCode.Conflict,
                    _ => (int) HttpStatusCode.InternalServerError
                };

                Log.Error("Something went wrong {Error}", contextFeature.Error);

                Log.Error(contextFeature.Error, contextFeature.Error.StackTrace);
                var responseMessage = contextFeature.Error.Message;
                var errorResponse = new
                {
                    statusCode = context.Response.StatusCode,
                    message = string.IsNullOrEmpty(responseMessage) ? "An error occurred, our team is looking into it" : responseMessage
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            });
        });
    }
}