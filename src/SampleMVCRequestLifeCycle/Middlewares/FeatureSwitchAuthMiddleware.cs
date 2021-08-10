using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVCRequestLifeCycle.Middlewares
{
    public class FeatureSwitchAuthMiddleware
    {
        private readonly RequestDelegate _next;

        public FeatureSwitchAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IConfiguration config)
        {
            var endpoint = httpContext.GetEndpoint()?.Metadata.GetMetadata<RouteAttribute>(); // Gets endpoint related data

            if (endpoint != null)
            {
                var featureSwitch = config.GetSection("FeatureSwitches")
                    .GetChildren().FirstOrDefault(x => x.Key == endpoint.Name);

                if (featureSwitch != null && !bool.Parse(featureSwitch.Value))
                {
                    httpContext.SetEndpoint(new Endpoint((context) =>
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        return Task.CompletedTask;
                    },
                    EndpointMetadataCollection.Empty,
                    "Feature Not Found"));
                }
            }

            await _next(httpContext);
        }
    }
}
