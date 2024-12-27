namespace FCNetwork.Common.Security.User
{
    public class RegisterRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string DeviceId { get; set; }
        public string GameTag { get; set; }
    }

    public class RegisterResponse
    {
        public string Email { get; set; }
    }
}
