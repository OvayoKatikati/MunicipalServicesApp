using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace MunicipalServicesApp
{
    /// <summary>
    /// In-memory account store for the login/registration screen. Each
    /// account gets a random salt and the password is hashed with PBKDF2
    /// (Rfc2898DeriveBytes), so plain-text passwords are never kept.
    /// A Dictionary keyed by username gives O(1) lookup at login.
    /// Accounts last only for the current run, like the rest of the app's data.
    /// </summary>
    public static class UserRepository
    {
        private static readonly Dictionary<string, User> _users =
            new Dictionary<string, User>(StringComparer.OrdinalIgnoreCase);

        static UserRepository()
        {
            // Demo account so a marker can log in without registering first.
            Register("resident", "Password1", "Demo Resident");
        }

        public static bool UserExists(string username)
        {
            return !string.IsNullOrWhiteSpace(username) && _users.ContainsKey(username);
        }

        /// <summary>Creates an account. Returns false if the username is taken or input is empty.</summary>
        public static bool Register(string username, string password, string fullName)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password)) return false;
            if (_users.ContainsKey(username)) return false;

            string salt = GenerateSalt();
            _users[username] = new User
            {
                Username = username,
                Salt = salt,
                PasswordHash = HashPassword(password, salt),
                FullName = string.IsNullOrWhiteSpace(fullName) ? username : fullName
            };
            return true;
        }

        /// <summary>Returns the matching User if the credentials are correct, otherwise null.</summary>
        public static User Authenticate(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || password == null) return null;

            User user;
            if (!_users.TryGetValue(username, out user)) return null;

            return HashPassword(password, user.Salt) == user.PasswordHash ? user : null;
        }

        private static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        private static string HashPassword(string password, string salt)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, Convert.FromBase64String(salt), 10000))
            {
                return Convert.ToBase64String(pbkdf2.GetBytes(32));
            }
        }
    }
}
