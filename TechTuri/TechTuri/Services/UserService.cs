using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TechTuri.Model;
using TechTuri.Model.Dtos;

namespace TechTuri.Services
{
    public interface IUSerService
    {
        Task<UserInfoDto> GetUserInfo(string uname);
    }
    public class UserService : IUSerService
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
            var user = _context.Users.Where(x => x.username.Equals(uname)).FirstOrDefaultAsync();
            UserInfoDto result=new UserInfoDto();
            _mapper.Map(user, result);

            return result;
        }
    }
}
