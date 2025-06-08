using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace BoxOptimizerMicroservice.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken)
        {
            _logger.LogError(
                exception,
                "Ocorreu uma exceção não tratada. TraceId: {TraceId}, Path: {Path}, Mensagem: {ErrorMessage}",
                httpContext.TraceIdentifier,
                httpContext.Request.Path,
                exception.Message);

            int statusCode = (int)HttpStatusCode.InternalServerError;
            string details = "Ocorreu um erro inesperado ao processar sua requisição.";

            httpContext.Response.StatusCode = statusCode;
            httpContext.Response.ContentType = "application/problem+json";

            object responsePayload = new
            {
                status = httpContext.Response.StatusCode,
                mensagem = exception.Message,
                details
            };

            await httpContext.Response.WriteAsync(
                JsonSerializer.Serialize(
                    responsePayload,
                    new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase }),
                    cancellationToken
                    );

            return true;
        }
    }
}