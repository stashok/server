﻿using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using Stashkevich.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stashkevich
{
    public class Startup
    {
        public static OAuthAuthorizationServerOptions OAuthOptions { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            OAuthOptions = new OAuthAuthorizationServerOptions
            {
                TokenEndpointPath = new PathString("/token"),
                Provider = new OAuthCustomTokenProvider(),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(20),
                AllowInsecureHttp = true,
                RefreshTokenProvider = new OAuthCustomRefreshTokenProvider()
            };
            app.UseOAuthBearerTokens(OAuthOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}