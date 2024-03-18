using System.Security.Cryptography;
using System.Text;

namespace FilesystemAndStreams.Services
{
    public class UserService
    {
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>();
        private readonly ILogger _logger;
        public UserService(ILogger logger)
        {
            _logger = logger;
        }

        public void Register(string userName, string password)
        {
            try
            {
                if (userName.Length < 6 || password.Length < 10)
                {
                    throw new ArgumentException("The user name must be atlest 6 characters long and the password must be atleast 10 characters long.");
                }

                if (_users.ContainsKey(userName)) 
                {
                    throw new InvalidOperationException($"The user name {userName} already exists.");
                }

                var hashedPassword = ComputeSha256Hash(password);
                _users[userName] = hashedPassword;

                _logger.LogSuccess("Register", DateTime.UtcNow.ToString(), "success");
            }
            catch (Exception ex)
            {
                _logger.LogError("Register", DateTime.UtcNow.ToString(), "failure", ex.Message);
            }
        }

        public void SignIn(string userName, string password)
        {
            try
            {
                bool isAuthenticated = false;

                if (_users.ContainsKey(userName))
                {
                    var hashedPassword = ComputeSha256Hash(password);
                    var existingPassword = _users[userName];
                    isAuthenticated = existingPassword == hashedPassword;
                }

                if (isAuthenticated == false)
                {
                    throw new InvalidOperationException("The user name or password are wrong.");
                }

                _logger.LogSuccess("SignIn", DateTime.UtcNow.ToString(), "success");
            }
            catch (Exception ex)
            {
                _logger.LogError("SignIn", DateTime.UtcNow.ToString(), "failure", ex.Message);
            }
        }

        private string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }
    }
}
