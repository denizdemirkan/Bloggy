using AutoMapper.Internal.Mappers;
using Bloggy.Core.DTOs;
using Bloggy.Core.Entities;
using Bloggy.Core.Services;
using Bloggy.Core.UnitOfWorks;
using Bloggy.Service.Mappings;
using Bloggy.SharedLibrary.DTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bloggy.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(UserManager<User> userManager, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
        }


        public async Task<Response<UserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Email = createUserDto.Email,
                UserName = createUserDto.UserName,
            };

            // Password hashing
            var result = await _userManager.CreateAsync(user, createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                return Response<UserDto>.Fail(new ErrorDto(errors, true), 400);
            }

            await _unitOfWork.CommitAsync();

            return Response<UserDto>.Success(ObjectMapper.Mapper.Map<UserDto>(user), 200);
        }

        public async Task<Response<UserDto>> GetUserByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                return Response<UserDto>.Fail("No such user found!", 400, true);
            }

            return Response<UserDto>.Success(ObjectMapper.Mapper.Map<UserDto>(user), 200);

        }
    }
}
