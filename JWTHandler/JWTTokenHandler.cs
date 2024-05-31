using IdentityModel;
using JWTHandler.Models;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTHandler
{
    public class JWTTokenHandler
    {
        public const string JWTKey = "o22pdgqu45p3z2mmnztlslhceo4vaetjz47vjwwqofo7o46xtgjq";
        private const int JWTValidity = 20;
        private List<UserAccounts> _userAccount=new List<UserAccounts>();
        public JWTTokenHandler()
        {
             _userAccount = new List<UserAccounts> {

            new UserAccounts {UserName="rohith",Password="rohith",Role="admin"},
            new UserAccounts {UserName="ravi",Password="ravi",Role="user"}
            };
        }

        public AuthenticationResponse GenerateJwt(AuthenticationRequest request)
        {
            if(string.IsNullOrWhiteSpace(request.UserName)&& string.IsNullOrWhiteSpace(request.Password))
            {
                return null;
            }
            var useraccount = _userAccount.Where(x => x.UserName == request.UserName && x.Password == request.Password).FirstOrDefault();
            if(useraccount==null) { return null; }

            var tokenKey = Encoding.ASCII.GetBytes(JWTKey);
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, request.UserName),
                new Claim(ClaimTypes.Role,useraccount.Role)
            }),
                Expires = DateTime.UtcNow.AddMinutes(JWTValidity),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token =  tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor));

            return new AuthenticationResponse {

                UserName = request.UserName,
                ExpiresIn = 20,
                JwtToken = token

            };


             


        }

    }
}
