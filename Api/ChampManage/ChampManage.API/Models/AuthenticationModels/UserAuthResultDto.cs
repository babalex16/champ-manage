namespace ChampManage.API.Models.AuthenticationModels
{
    /// <summary>
    /// Data transfer object used to provide user with a valid token after successful registration/login.
    /// </summary>
    public class UserAuthResultDto
    {
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
