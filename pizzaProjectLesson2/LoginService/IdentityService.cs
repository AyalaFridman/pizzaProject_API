using Microsoft.AspNetCore.Mvc;
using ClassModels;
using ClassInterface;
using FileService;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
namespace LoginService;
public class IdentityService: ILogin
{
     IWorker _worker;
    public IdentityService(IWorker worker)
    {
        _worker=worker;
    }
    private static SymmetricSecurityKey key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SXkSqsKyNUyvGbnHs7ke2NCq8zQzNLW7mPmHbnZZ"));
    private static string issuer="https://my-pizza.com";
public static SecurityToken GetToken(List<Claim> claims)=>
        new JwtSecurityToken(
            issuer,
            issuer,
            claims,
            expires:DateTime.Now.AddDays(30.0),
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256)
);
     public static TokenValidationParameters GetTokenValidationParameters() =>
            new TokenValidationParameters
            {
                
                ValidIssuer = issuer,
                ValidAudience = issuer,
                IssuerSigningKey = key,
                ClockSkew = TimeSpan.Zero // remove delay of token when expire
            };
    public  SecurityToken Login(string name,string password)
    {
        var workers=_worker.Get();
        var existWorker=workers.FirstOrDefault(Worker=>(Worker.Name.Equals(name)&&(Worker.Password).Equals(password)));
        if(existWorker==null)
            return null;
        List<Claim> claims=new List<Claim>
        {
        new Claim("UserType",existWorker.Role.ToString())
        };
    var token =GetToken(claims);
    return token;
    }
}

