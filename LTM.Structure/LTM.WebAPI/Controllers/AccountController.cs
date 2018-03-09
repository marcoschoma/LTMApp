using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using LTM.Domain.Commands.Input;
using LTM.Domain.Commands.Input.User;
using LTM.Domain.Commands.Results;
using LTM.Domain.Services;
using LTM.Infra;
using LTM.Infra.Settings;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LTM.WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private IUserService _service;

        public AccountController(IUserService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]UserAuthenticationCommand authentication)
        {
            var result = new NotificationResult();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(AppSettings.Site.UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                client.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue(System.Threading.Thread.CurrentThread.CurrentCulture.Name));

                var contentData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", authentication.Username),
                    new KeyValuePair<string, string>("password", authentication.Password),
                    new KeyValuePair<string, string>("grant_type", "password")
                });

                var response = await client.PostAsync("connect/token", contentData);

                var str = await response.Content.ReadAsStringAsync();
                var tokenAuthentication = JsonConvert.DeserializeObject<UserTokenCommandResult>(str);

                if (response.IsSuccessStatusCode)
                {
                    result.Data = tokenAuthentication;
                    result.IsValid = true;
                }
                else
                    result.AddError(tokenAuthentication.Error_description);
            }

            return Ok(result);
        }

        [HttpPost("refreshToken")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody]UserRefreshTokenCommand authentication)
        {
            NotificationResult result = new NotificationResult();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(AppSettings.Site.UrlApi);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                var contentData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("refresh_token", authentication.Refresh_token),
                    new KeyValuePair<string, string>("grant_type", "refresh_token")
                });

                var response = await client.PostAsync("connect/token", contentData);

                string str = await response.Content.ReadAsStringAsync();
                var tokenAuthentication = JsonConvert.DeserializeObject<UserTokenCommandResult>(str);

                if (response.IsSuccessStatusCode)
                    result.Data = tokenAuthentication;
                else
                    result.AddError(tokenAuthentication.Error_description);
            }

            return Ok(result);
        }
    }
}