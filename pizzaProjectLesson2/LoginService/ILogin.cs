
// using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using ClassModels;
using ClassInterface;

namespace LoginService;
public interface ILogin{
//  SecurityToken GetToken(List<Claim> claims);
// TokenValidationParameters GetTokenValidationParameters();
SecurityToken Login(string name,string password);
}