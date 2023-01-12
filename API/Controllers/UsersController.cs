using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Dtos;
using API.Helpers;
using API.Infrastructure.DataContext;
using API.Infrastructure.Implements;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Windows.System;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IGenericRepository<UserApi> _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IGenericRepository<UserApi> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserApi>>> GetUsers()
        {
            var data = await _userRepository.ListAllAsync();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserApi>> GetUsers(int id)
        {
            var data = await _userRepository.GetByIdAsync(id);
            return Ok(data);
        }
    }
}
