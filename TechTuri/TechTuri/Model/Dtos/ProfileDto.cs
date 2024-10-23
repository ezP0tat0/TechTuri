namespace TechTuri.Model.Dtos
{
    public class ProfileDto
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    public class LoginDto : ProfileDto
    {
    }
    public class RegisterDto:ProfileDto
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
}
