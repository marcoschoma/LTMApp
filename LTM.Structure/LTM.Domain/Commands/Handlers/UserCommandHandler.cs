using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LTM.Domain.Repositories;
using LTM.Infra;

namespace LTM.Domain.Commands.Handlers
{
    public class UserCommandHandler
    {
        private IUserRepository _userRepository;

        private const string passwordSalt = "12D4B2EB-B481-489F-B055-0F0C174C605E E5AC6E94-6E64-401D-B87A-20B69A757F59 5B285613-064B-43F3-A687-471A8B98156B";

        public UserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<NotificationResult> ValidateUsernameAndPasswordAsync(string username, string password)
        {
            var result = new NotificationResult();
            var user = await _userRepository.GetUserByLoginAsync(username);

            var hashedPassword = Hash(password, passwordSalt);

            return result;
        }

        public async Task<NotificationResult> ValidateUsernameAndTokenAsync(string username, Guid? token)
        {
            var result = new NotificationResult();
            return result;
        }

        public static byte[] Hash(string value, string salt)
        {
            return Hash(Encoding.UTF8.GetBytes(value), Encoding.UTF8.GetBytes(salt));
        }

        public static byte[] Hash(byte[] value, byte[] salt)
        {
            var saltedValue = new byte[value.Length + salt.Length];
            value.CopyTo(saltedValue, 0);
            salt.CopyTo(saltedValue, value.Length);

            return new SHA256Managed().ComputeHash(saltedValue);
        }
    }
}
