using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using TechTuri.Model;
using TechTuri.Model.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TechTuri.Services
{
    public interface IUserService
    {
        Task<UserInfoDto> GetUserInfo(string uname);
        Task InfoChange(UserInfoChangeDto uc);
    }
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;
        public UserService(DataContext context,IMapper mapper)
        { 
            _context = context;
            _mapper = mapper;
        }

        public async Task<UserInfoDto> GetUserInfo(string uname)
        {
            var user =await _context.Users.Where(x => x.username.Equals(uname)).FirstOrDefaultAsync();
            UserInfoDto result = new UserInfoDto();

            _mapper.Map(user, result);

            return result;
        }
        public async Task InfoChange(UserInfoChangeDto uc)
        {
            var user = await _context.Users.Where(x => x.username.Equals(uc.originalUsername)).FirstOrDefaultAsync();
            if(uc.username.Length>0) user.username = uc.username;
            if(uc.name.Length>0) user.name = uc.name;
            if(uc.password.Length>0)
            {
                CreatePasswordHash(uc.password, out byte[] psHash, out byte[] pwSalt);

                user.pwHash = psHash;
                user.pwSalt = pwSalt;
            }
            await _context.SaveChangesAsync();
        }
        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
