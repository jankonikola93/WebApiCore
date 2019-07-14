using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config)
        {
            _config = config;
        }
        //[HttpPost]
        //[AllowAnonymous]
        //public IActionResult Login([FromBody]Login user)
        //{
        //    if (user == null)
        //    {
        //        return BadRequest("Invalid client request");
        //    }

        //    if (user.Username == "nikola" && user.Password == "P@ssw0rd")
        //    {
        //        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("thisismykeythisismykey"));
        //        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        //        var tokeOptions = new JwtSecurityToken(
        //            issuer: "https://localhost:44357/",
        //            audience: "https://localhost:44357/",
        //            claims: new List<Claim>(),
        //            expires: DateTime.Now.AddMinutes(5),
        //            signingCredentials: signinCredentials
        //        );

        //        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        //        return Ok(new { Token = tokenString });
        //    }
        //    else
        //    {
        //        return Unauthorized();
        //    }
        //}
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Authorize(Client clientModel)
        {
            var client = new HttpClient();
            var disco = await client.GetDiscoveryDocumentAsync("https://localhost:44308");
            if (disco.IsError)
            {
                return BadRequest();
            }
            var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = disco.TokenEndpoint,
                ClientId = clientModel.ClientId,
                ClientSecret = clientModel.ClientSecret,
                Scope = clientModel.Scope,
            });

            if (tokenResponse.IsError)
            {
                return StatusCode(500);
            }

            return Ok(tokenResponse.Json);
        }
    }
}