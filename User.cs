namespace MunicipalServicesApp
{
    /// <summary>
    /// A registered resident account. Passwords are never stored in plain
    /// text - only a salted hash (see UserRepository).
    /// </summary>
    public class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string FullName { get; set; }
    }
}
