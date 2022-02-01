using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebApiTiempo.Settings;
using WebApiTiempo.Models;
using WebApiTiempo.Servicios;

namespace WebApiTiempo.Data
{
    public class WebApiTiempoContext : DbContext
    {

        public DbSet<TiempoItem> TiempoItem { get; set; }

        public DbSet<User> Usuario { get; set; }

        private readonly AppSettings _appSettings;



        public WebApiTiempoContext(IOptions<AppSettings> appSettings,  DbContextOptions<WebApiTiempoContext> options)
            : base(options)
        {
            _appSettings = appSettings.Value;
        }

 
      

        public AuthResponse Authenticate(AuthRequest user)
        {
            var user1 = Usuario.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            // 1.- control null
            if (user1 == null) return null;
            // 2.- control db

            // autenticacion válida -> generamos jwt
            var (token, validTo) = generateJwtToken(user1);

            // Devolvemos lo que nos interese
            return new AuthResponse
            {
                Id = user1.Id,
                FirstName = user1.FirstName,
                LastName = user1.LastName,
                Username = user1.Username,
                Token = token,
                ValidTo = validTo
            };

        }

        public IEnumerable<User> GetAll()
        {
            return Usuario;
        }

        public User GetById(int id)
        {
            return Usuario.FirstOrDefault(x => x.Id == id);
        }

        // internos
        private (string token, DateTime validTo) generateJwtToken(User user)
        {
            // generamos un token válido para 7 días
            var dias = 7; 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role),
                }),
                Expires = DateTime.UtcNow.AddDays(dias),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return (token: tokenHandler.WriteToken(token), validTo: token.ValidTo);
        }






    }
}
