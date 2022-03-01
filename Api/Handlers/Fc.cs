using System.Collections.Generic;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace UnitedSystemsCooperative.Web.Api
{
    public class FleetCarriersApi
    {
        private readonly ILogger _logger;

        public FleetCarriersApi(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<FleetCarriersApi>();
        }

        [Function("fc")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}