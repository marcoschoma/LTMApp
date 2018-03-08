
using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OpenIdConnect.Server;
using LTM.Application.Services;
using LTM.Domain.Commands.Handlers;
using LTM.Domain.Entities;
using LTM.Domain.Repositories;
using LTM.Domain.Services;
using LTM.Infra;
using LTM.Infra.Data;
using LTM.Infra.Data.Base;
using LTM.Infra.Data.Contexts;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using static AspNet.Security.OpenIdConnect.Primitives.OpenIdConnectConstants;

namespace LTM.WebAPI.Security
{
    public class AuthorizationProvider : OpenIdConnectServerProvider
    {
        public override Task ValidateTokenRequest(ValidateTokenRequestContext context)
        {
            if (!context.Request.IsPasswordGrantType() && !context.Request.IsRefreshTokenGrantType())
            {
                context.Reject(
                    error: OpenIdConnectConstants.Errors.UnsupportedGrantType,
                    description: "Unsupported Authentication");//Resources.Security.UnsupportedAuthentication

                return Task.FromResult(0);
            }

            context.Skip();
            return Task.FromResult(0);
        }

        public override async Task HandleTokenRequest(HandleTokenRequestContext context)
        {
            NotificationResult result = null;
            var userService = GetUserService();

            if (context.Request.IsPasswordGrantType())
            {
                result = await userService.IsValidUsernameAndPasswordAsync(context.Request.Username, context.Request.Password);
            }
            else if (context.Request.IsRefreshTokenGrantType())
            {
                var idUser = new Guid(context.Ticket.Principal.GetClaim(ClaimTypes.NameIdentifier));
                string username = context.Ticket.Principal.GetClaim(ClaimTypes.Name);

                result = await userService.IsValidUsernameAndTokenAsync(username, idUser);
            }

            if (result.IsValid && result.Data == null && result.Messages.Any(x => x.Type == NotificationResult.NotificationMessageType.Warning))
                result.AddError(result.Messages.First(x => x.Type == NotificationResult.NotificationMessageType.Warning).Message);

            if (!result.IsValid)
            {
                context.Reject(
                    error: OpenIdConnectConstants.Errors.InvalidGrant,
                    description: result.Errors.FirstOrDefault().Message
                );
            }
            else
            {
                var identity = new ClaimsIdentity(OpenIdConnectServerDefaults.AuthenticationScheme);
                var user = result.Data as UserInfo;

                identity.AddClaim(OpenIdConnectConstants.Claims.Subject, user.IdUser.ToString());
                identity.AddClaim(ClaimTypes.NameIdentifier, user.IdUser.ToString(), Destinations.AccessToken);
                identity.AddClaim(ClaimTypes.Name, user.Username, Destinations.AccessToken);
                identity.AddClaim(ClaimTypes.GivenName, user.FirstName, Destinations.AccessToken, Destinations.IdentityToken);
                identity.AddClaim(ClaimTypes.Email, user.Email, Destinations.AccessToken, Destinations.IdentityToken);

                var ticket = new AuthenticationTicket(
                    new ClaimsPrincipal(identity),
                    new AuthenticationProperties(),
                    OpenIdConnectServerDefaults.AuthenticationScheme
                );

                ticket.SetScopes(
                    Scopes.OpenId,
                    Scopes.OfflineAccess
                );

                context.Validate(ticket);
            }
        }

        private IUserService GetUserService()
        {
            IUnitOfWork _uow = new UnitOfWork();
            LTMDataContext _context = new LTMDataContext(_uow);
            IUserRepository _userRepository = new UserRepository(_uow, _context);
            var _handler = new UserCommandHandler(_userRepository);
            IUserService userApp = new UserService(_userRepository, _handler);
            return userApp;
        }
    }
}