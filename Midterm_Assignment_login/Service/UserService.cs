// UserService.cs (Application Service layer)
public class UserService
{
    private readonly Dictionary<string, User> _userStorage = new Dictionary<string, User>();

    public bool RegisterUser(string username, string password, string? email = null)
    {
        if (_userStorage.ContainsKey(username))
            return false; // Username already exists

        if (password.Length < 8 || !PasswordMeetsComplexity(password))
            return false; // Password does not meet complexity requirements

        _userStorage.Add(username, new User
        {
            Username = username,
            PasswordHash = BcryptHelper.HashPassword(password),
            Email = email
        });

        return true; // Registration successful
    }

    public bool Login(string username, string password, out User user)
    {
        user = null;

        if (!_userStorage.ContainsKey(username))
            return false; // Username not found

        user = _userStorage[username];

        if (!BcryptHelper.VerifyPassword(password, user.PasswordHash))
            return false; // Incorrect password

        return true; // Login successful
    }

    private bool PasswordMeetsComplexity(string password)
    {
        // Implement your password complexity rules here
        return true;
    }
}
