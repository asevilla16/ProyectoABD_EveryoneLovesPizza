using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Backend_EveryoneLovesPizza_ADB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend_EveryoneLovesPizza_ADB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private EmpleadosController _employeeManager;
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var response = await _employeeManager.GetEmpleado(model.Correo);
            if (response != null)
            {
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                         new Claim("UserID", model.Correo)
                     }),
                    Expires = DateTime.UtcNow.AddMinutes(10),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("1234567890123456")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescription);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }else
            {
                return BadRequest(new { message = "Usuario o contraseña incorrectos" });
            }
        }
    }
}
