using AspNet.Security.OpenIdConnect.Primitives;
using AspNet.Security.OpenIdConnect.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            /*NotificationResult result = null;
            IUserApplicationService userApp = GetUserApp();

            if (context.Request.IsPasswordGrantType())
            {
                result = await userApp.IsValidUsernameAndPasswordAsync(context.Request.Username, context.Request.Password);
            }
            else if (context.Request.IsRefreshTokenGrantType())
            {
                Guid idUser = new Guid(context.Ticket.Principal.GetClaim(ClaimTypes.NameIdentifier));
                string username = context.Ticket.Principal.GetClaim(ClaimTypes.Name);

                result = await userApp.IsValidUsernameAndTokenAsync(username, idUser);
            }

            if (result.IsValid && result.Data == null && result.Messages.Any(x => x.Type == "warning"))
                result.AddError(result.Messages.First(x => x.Type == "warning").Message);

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
            }*/
        }

        private IUserApplicationService GetUserApp()
        {
            IUnitOfWork _uow = new UnitOfWork();
            CgDataContext _context = new CgDataContext(_uow);
            IEmailService _emailService = new EmailService();
            IUserRepository _userRepository = new UserRepository(_uow, _context);
            IUserPhotoRepository _photoRepository = new UserPhotoRepository(_uow, _context);
            UserCommandHandler _handler = new UserCommandHandler(_userRepository, _photoRepository, _emailService);
            IUserApplicationService userApp = new UserApplicationService(_uow, _userRepository, _handler);
            return userApp;
        }
    }
}