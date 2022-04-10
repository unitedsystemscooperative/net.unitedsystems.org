﻿using System;
using System.Linq;
using System.Net.Http.Headers;
using Microsoft.Azure.Functions.Worker.Http;
using OidcApiAuthorization.Abstractions;

namespace OidcApiAuthorization;

public class AuthorizationHeaderBearerTokenExtractor : IAuthorizationHeaderBearerTokenExtractor
{
    /// <summary>
    /// Extracts the Bearer token from the Authorization header of the given HTTP request headers.
    /// </summary>
    /// <param name="httpRequestHeaders">
    /// The headers from an HTTP request.
    /// </param>
    /// <returns>
    /// The Bearer token extracted from the Authorization header (without the "Bearer " prefix),
    /// or null if the Authorization header was not found, it is in an invalid format,
    /// or its value is not a Bearer token.
    /// </returns>
    public string GetToken(HttpHeadersCollection httpRequestHeaders)
    {
        // Get a StringValues object that represents the content of the Authorization header found in the given
        // headers.
        // Note that the default for a IHeaderDictionary is a StringValues object with one null string.
        var rawAuthorizationHeaderValue = httpRequestHeaders.SingleOrDefault(x => x.Key == "Authorization").Value;

        var authorizationHeaderValue = rawAuthorizationHeaderValue as string[] ?? rawAuthorizationHeaderValue.ToArray();
        if (authorizationHeaderValue.Length != 1)
            // StringValues' Count will be zero if there is no Authorization header
            // and greater than one if there are more than one Authorization headers.
            return null;

        // We got a value from the Authorization header.

        if (!AuthenticationHeaderValue.TryParse(
                authorizationHeaderValue.First(), // StringValues automatically convert to string.
                out var authenticationHeaderValue))
            // Invalid token format.
            return null;

        if (!string.Equals(
                authenticationHeaderValue.Scheme,
                "Bearer",
                StringComparison.InvariantCultureIgnoreCase)) // Case insensitive.
            // The Authorization header's value is not a Bearer token.
            return null;

        // Return the token from the Authorization header.
        // This is the token with the "Bearer " prefix removed.
        // The Parameter will be null, if nothing followed the "Bearer " prefix.
        return authenticationHeaderValue.Parameter;
    }
}