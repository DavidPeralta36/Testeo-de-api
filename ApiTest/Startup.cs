using Microsoft.IdentityModel.Tokens;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Owin;
using System.Configuration;

[assembly: OwinStartup(typeof(ApiTest.Startup))]
namespace ApiTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var issuer = "https://tu-auth0-dominio.auth0.com/";
            var audience = ConfigurationManager.AppSettings["Auth0:Audience"];
            var secret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["LNUC5RFBK1_anY-XaFsrkNmEvNywD8XVvKa8ZyFDQHAd8RyC2Kd_EJm4EJT6yMfh"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidIssuer = issuer,
                ValidAudience = audience,
                IssuerSigningKey = new SymmetricSecurityKey(secret)
            };

            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                TokenValidationParameters = tokenValidationParameters
            });
        }
    }
}
