using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
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
        private static Random r = new Random();
        private static ProyectoABDContext _context = new ProyectoABDContext();
        private EmpleadosController _employeeManager  = new EmpleadosController(_context);
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            dynamic response = null;
            if (model != null)
            {
                response = _employeeManager.GetEmpleado(model.Correo);
            }
            Type objType = response.GetType();
            PropertyInfo[] props = objType.GetProperties();
            var correo = props[4].GetValue(response);
            if (correo != null)
            {
                
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                         new Claim("UserID", model.Correo)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Random16DigitString())), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescription);
                var token = tokenHandler.WriteToken(securityToken);
                model.Token = token;
                model.Empleado = response;
                return Ok(model);
            }else
            {
                return BadRequest(new { message = "Usuario o contraseña incorrectos" });
            }
        }

        static string Random16DigitString()
        {
            var v = new char[16];
            for (var j = 0; j < 16; j++) v[j] = (char)(r.NextDouble() * 10 + 48);
            return new string(v);
        }
    }
}
