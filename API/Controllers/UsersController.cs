using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Dtos;
using API.Helpers;
using API.Infrastructure.DataContext;
using API.Infrastructure.Implements;
using AutoMapper;
using Google.Api.Ads.AdWords.v201809;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Windows.System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        // GET: UsersController
        private readonly UserContext _userRepository;
        private readonly IMapper _mapper;

        public UserController(UserContext userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<User>>> GetUser()
        {
            var users = await _userRepository.User.ToListAsync();
            var data = _mapper.Map<IReadOnlyList<User>, IReadOnlyList<UserToReturnDto>>(users);
            return Ok(data);
        }
    }
}
