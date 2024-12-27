namespace FCNetwork.Common.Security.User
{
    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class UserLoginResponse
    {
        public string Email { get; set; }
    }
}
