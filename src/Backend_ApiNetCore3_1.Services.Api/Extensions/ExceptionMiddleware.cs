using KissLog;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Backend_ApiNetCore3_1.Services.Api.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;
        private readonly KissLog.ILogger _kissLogger;

        public ExceptionMiddleware(RequestDelegate next,
                                   ILogger<ExceptionMiddleware> logger,
                                   KissLog.ILogger kissLogger)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _kissLogger = kissLogger ?? throw new ArgumentNullException(nameof(kissLogger));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception e)
            {
                _logger.LogError($"Something went wrong: {e}");
                if (context.Response.HasStarted)
                {
                    _logger.LogWarning("The response has already started, the Exception Middleware will not be executed");
                    throw;
                }
                await HandleExceptionAsync(context, e);

                _kissLogger.Debug("Mensagem: " + e.Message + " Origem: " + e.Source);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception e)
        {

            var result = JsonConvert.SerializeObject(new
            {
                ErrorCode = (int)HttpStatusCode.InternalServerError,
                ErrorMessage = e.Message
            });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(result.ToString());


        }
    }
}
