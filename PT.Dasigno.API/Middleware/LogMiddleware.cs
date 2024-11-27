using Newtonsoft.Json;
using PT.Dasigno.BLL.Base;
using System.Net;

namespace PT.Dasigno.API.Middleware
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LogMiddleware(RequestDelegate next, ILogger<LogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context != null)
            {
                var method = context.Request.Path;

                try
                {
                    _logger.LogInformation("Inicia ejecución del método {Method}.", method);

                    await _next(context);

                    var statusCode = context.Response.StatusCode;
                    _logger.LogInformation("Finaliza ejecución del método {Method}. Status code {StatusCode}.", method, statusCode);
                }
                catch (Exception ex)
                {
                    int statusCodeError = (int)HttpStatusCode.InternalServerError; // Valor por defecto

                    // Determinar el código de estado basado en el tipo de excepción
                    if (ex is KeyNotFoundException)
                    {
                        statusCodeError = (int)HttpStatusCode.NotFound;
                    }
                    // Agregar aquí más condiciones según sea necesario

                    _logger.LogError(ex, "Ocurrió un error en el método {Method}. Status code {StatusCode}.", method, statusCodeError);
                    await HandleGlobalExcepcionAsync(context, ex.Message, statusCodeError);
                }
            }
        }


        /// <summary>
        /// Manejador global de excepciones
        /// </summary>
        /// <param name="context">Contexto</param>
        /// <param name="ex">Excepcion</param>
        /// <returns>Response</returns>
        private static Task HandleGlobalExcepcionAsync(HttpContext context, string message, int statusCode)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode; // Usar el código de estado proporcionado

            ResponseDetails response = new ResponseDetails
            {
                Success = false,
                Message = message
            };

            return context.Response.WriteAsync(JsonConvert.SerializeObject(response));
        }

    }
}
