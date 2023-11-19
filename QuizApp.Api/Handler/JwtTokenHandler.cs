using Microsoft.IdentityModel.Tokens;
using QuizApp.Shared.Models.Dto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QuizApp.Api.Handler
{
    public class JwtTokenHandler
    {
        public const string JwtSecurityKey = $"p{{FIRSbrI!1&cB!]g-l*l\"B^HUnV*@v3cko(|.VP(FrV[AN6\"WH[3VC-q9+>b9`";
        private const int JwtTokenValidityMins = 20;
        public string GenerateJwtToken(string userName)
        {
            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JwtTokenValidityMins);
            var tokenKey = Encoding.ASCII.GetBytes(JwtSecurityKey);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name,userName)
            });

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature);

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials
            };

            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            //var jwtDto = new JwtDTO
            //{
            //    Token = token,
            //    ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds
            //};
            return token;
        }
    }
}
