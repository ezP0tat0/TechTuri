namespace TechTuri.Model.Dtos
{
    public class UserDto
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class LoginDto : UserDto
    {
    }
    public class RegisterDto:UserDto
    {
        public string name { get; set; }

        public DateTime joinDate = DateTime.Now;
    }
    public class AuthResponseDto
    {
        public string username{ get; set; }
        public string name { get; set; }
        public string Token { get; set; }
    }
    public class UserInfoDto
    {
        public string username { get; set; }
        public string name { get; set; }
        public DateTime joinDate { get; set; }
    }
}
