﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MyAppWebAPI_HIENLTH.Data;
using MyAppWebAPI_HIENLTH.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MyAppWebAPI_HIENLTH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly AppSetting _appSettings;

        public UserController(MyDbContext context, IOptionsMonitor<AppSetting> optionsMonitor) 
        { 
            _context = context;
            _appSettings = optionsMonitor.CurrentValue;
        
        }

        [HttpPost("Login")]
        public IActionResult Validate(LoginModel model)
        {
            var user = _context.NguoiDungs.SingleOrDefault(p => p.UserName == model.UserName
            && p.PassWord == model.PassWord);
            if(user == null)
            {
                return Ok(new ApiResponse
                {
                    Success = false,
                    Message = "Invalid username/password"
                });
            }

            //cấp token

            return Ok(new ApiResponse
            {
                Success = true,
                Message = "Authenticate success",
                Data = GenerateToken(user)
            });
        }

        private string GenerateToken(NguoiDung nguoiDung)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();

            var secretKeyBytes = Encoding.UTF8.GetBytes(_appSettings.SecretKey);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new []
                {
                    new Claim(ClaimTypes.Name, nguoiDung.HoTen),
                    new Claim(ClaimTypes.Email, nguoiDung.Email),
                    new Claim("UserName", nguoiDung.UserName),
                    new Claim("Id", nguoiDung.Id.ToString()),

                    //roles

                    new Claim("TokenId",Guid.NewGuid().ToString())
                }),

                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKeyBytes),SecurityAlgorithms.HmacSha512Signature)
                
            };

            var token = jwtTokenHandler.CreateToken(tokenDescription);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}