using LTM.Domain.Commands.Input;
using LTM.Domain.Entities;
using LTM.Domain.Repositories;
using LTM.Infra;
using System;
using System.Threading.Tasks;

namespace LTM.Domain.Commands.Handlers
{
    public class UserCommandHandler
    {
        private IUserRepository _userRepository;

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<NotificationResult> ValidateUsernameAndPasswordAsync(string username, string password)
        {
            var result = new NotificationResult();
            var user = await _userRepository.GetUserByLoginAsync(username);

            var hashedPassword = Cryptography.Hash(password);

            if (user.Password == hashedPassword)
            {
                result.IsValid = true;
                user.Password = null;
                result.Data = user;
            }
            else
            {
                result.IsValid = false;
                result.AddError("Invalid username/password");
            }
            return result;
        }

        public async Task<NotificationResult> InsertAsync(InsertUserCommand userCommand)
        {
            var item = new UserInfo(userCommand);
            return await _userRepository.InsertAsync(item);
        }

        public async Task<NotificationResult> ValidateUsernameAndTokenAsync(string username, Guid? token)
        {
            var result = new NotificationResult();
            var user = await _userRepository.GetUserByLoginAsync(username);
            return result;
        }
    }
}
