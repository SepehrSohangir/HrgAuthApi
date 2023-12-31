﻿using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;

using HrgAuthApi.Dto;
namespace HrgAuthApi.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlerMiddleware> _logger;

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger)
        {
            _next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Log the exception
                LogException(ex);

                // Set the response status code to Internal Server Error
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                // Create a standardized error response
                var errorResponse = new Dto.FailedResponseDto
                {
                    Status = "InternalServerError",
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                    Message = "بروز خطای داخلی"
                };

                // Serialize and write the error response to the response stream
                var jsonResponse = JsonConvert.SerializeObject(errorResponse);
                await context.Response.WriteAsync(jsonResponse);
            }
        }

        private void LogException(Exception ex)
        {
            _logger.LogError(ex, "Unexpected error occured");
        }
    }
}
