﻿using Business.Abstract;
using Core.Entity.Models;
using Core.Security.Hasing;
using Core.Security.TokenHandler;
using Entities.DTOs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IdentityModel.Tokens.Jwt;

namespace CosmetsyApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthManager _authManager;
        private readonly TokenGenerator _tokenGenerator;
        private readonly HasingHandler _hashingHandler;

        public AuthController(IAuthManager authManager, TokenGenerator tokenGenerator, HasingHandler hashingHandler)
        {
            _authManager = authManager;
            _tokenGenerator = tokenGenerator;
            _hashingHandler = hashingHandler;

        }

        [HttpPost("login")]
        public async Task<object> LoginUser(LoginDTO model)
        {
            var user = _authManager.Login(model.Email);

            if (user == null) return Ok(new { status = 404, message = "Bele bir istifadeci tapilmadi." });

            if (user.Email == model.Email && user.Password == _hashingHandler.PasswordHash(model.Password))
            {

                var resultUser = new UserDTO(user.Id, user.FullName, user.Email);
                resultUser.Token = _tokenGenerator.Token(user);

                return Ok(new { status = 200, message = resultUser });
            }
            return Ok(new { status = 404, message = "Email ve ya sifre sehvdir." });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDTO model)
        {

            var user = _authManager.GetUserByEmail(model.Email);

            if (user != null)
            {
                return Ok(new { status = 201, message = "Email is exist" });
            }

            var pass = model.Password;

            if (pass.Length >= 5)
            {
                _authManager.Register(model);
                return Ok(new { status = 200, message = "Okey" });
            }
            return Ok(new { status = 404, message = "Parolunuzun uzunlugu en az 5 simvol olmalidir." });

        }

        [Authorize]
        [HttpGet("getbyemail")]
        public async Task<IActionResult> GetByEmail()
        {
            var _bearer_token = Request.Headers[HeaderNames.Authorization].ToString().Replace("Bearer ", "");
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityTeam = handler.ReadJwtToken(_bearer_token);
            var email = jwtSecurityTeam.Claims.FirstOrDefault(x => x.Type == "email").Value;
            var user = _authManager.GetUserByEmail(email);
            var result = new UserDTO(user.Id, user.FullName, user.Email);
            return Ok(result);
        }

        [HttpGet("allusers")]
        public List<User> GetUsers()
        {
            return _authManager.GetUsers();
        }


    }
}