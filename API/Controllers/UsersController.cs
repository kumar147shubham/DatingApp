using Microsoft.AspNetCore.Mvc;
using API.Data;
using System.Collections.Generic;
using API.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;
using API.DTOs;
using AutoMapper;

namespace API.Controllers
{
    [Authorize]
    public class UsersController: BaseApiController
    {
        private readonly IUserRepository _userRepository;
        public readonly IMapper _mapper;
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            // var users = await _userRepository.GetUsersAsync();
            // var userToReturn = _mapper.Map<IEnumerable<MemberDto>>(users);
            //  return Ok(userToReturn);
            return Ok(await _userRepository.GetMembersAsync());
        }

        //api/users/3
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _userRepository.GetMemberAsunc(username);
        }


    }
}