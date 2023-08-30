using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YuGiOhApi.Domain.Models;

namespace YuGiOhApi.Services;

public class TokenService
{
    public string GenerateToken(User user)
    {
        Claim[] claims = new Claim[]
        {
            new Claim("username", user.UserName),
            new Claim("id", user.Id)
        };

        var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("384qfheh89hq89fsda8HFQ349FHE3823HUUHSK"));

        var signInCredentials =
            new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken
            (
                expires: DateTime.Now.AddDays(1),
                claims: claims,
                signingCredentials: signInCredentials
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
