namespace ChampManage.API.Models.UserModels
{
    /// <summary>
    /// Data transfer object for retrieving user by his email address.
    /// </summary>
    public class UserEmailDto
    {
        public string Email { get; set; } = string.Empty;
    }
}
