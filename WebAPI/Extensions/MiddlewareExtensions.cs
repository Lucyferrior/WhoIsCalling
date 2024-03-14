using System.Net;
using Entities.ErrorModels;
using Microsoft.AspNetCore.Diagnostics;
using Services.Contrats;

namespace WebAPI.Extensions;

public static class MiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
    {
        app.UseExceptionHandler(appErr =>
        {
            appErr.Run(async context =>
            {
                context.Response.StatusCode =
                    (int)HttpStatusCode.InternalServerError; //hata olduğunda tüm hatalar şu anda 500 olarak dönüyor
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    logger.LogError($"Something went wrong: {contextFeature.Error}");
                    await context.Response.WriteAsync(new ErrorDetails()
                    {
                        StatusCode = context.Response.StatusCode,
                        Message = "Internal server error."
                    }.ToString());
                }
            });
        });
    }
}