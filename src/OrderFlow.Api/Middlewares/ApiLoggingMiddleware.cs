namespace OrderFlow.Api.Middlewares;
public class ApiLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ApiLoggingMiddleware> _logger;
    public ApiLoggingMiddleware(RequestDelegate next, ILogger<ApiLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        var correlationId = Guid.NewGuid().ToString();
        context.Response.Headers.Append("X-Correlation-ID", correlationId);
        _logger.LogInformation("📦 API Request {CorrelationId}: {Method} {Path} {QueryString}",
            correlationId,
            context.Request.Method,
            context.Request.Path,
            context.Request.QueryString);
        var originalBodyStream = context.Response.Body;
        using var responseBodyStream = new MemoryStream();
        context.Response.Body = responseBodyStream;
        var startTime = DateTime.UtcNow;
        try
        {
            await _next(context);

            // Depois de processar a requisição, capture a resposta para logging
            responseBodyStream.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(responseBodyStream).ReadToEndAsync();
            _logger.LogInformation("📦 API Response {CorrelationId}: {StatusCode} {Body}",
                correlationId,
                context.Response.StatusCode,
                responseBody.Length > 4096 ? $"[Body too large: {responseBody.Length} bytes]" : responseBody);

            // Copie de volta ao stream original
            responseBodyStream.Seek(0, SeekOrigin.Begin);
            await responseBodyStream.CopyToAsync(originalBodyStream);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "❌ API Exception {CorrelationId}: {Message}", correlationId, ex.Message);

            // Importante: restaure o stream original antes de propagar a exceção
            context.Response.Body = originalBodyStream;
            throw;
        }
        finally
        {
            // Garanta que o stream original seja restaurado mesmo em caso de exceção
            context.Response.Body = originalBodyStream;

            var endTime = DateTime.UtcNow;
            var elapsedMs = (endTime - startTime).TotalMilliseconds;
            _logger.LogInformation("⏱️ API Duration {CorrelationId}: {ElapsedMilliseconds}ms", correlationId, elapsedMs);
        }
    }

    private static async Task<string> GetRequestBody(HttpRequest request)
    {
        request.EnableBuffering();
        using var reader = new StreamReader(
            request.Body,
            encoding: Encoding.UTF8,
            detectEncodingFromByteOrderMarks: false,
            leaveOpen: true);
        var body = await reader.ReadToEndAsync();
        request.Body.Position = 0;
        if (body.Length > 4096)
            return $"[Body too large: {body.Length} bytes]";
        return body;
    }
}