using FrameworkCore.Abstract;
using FrameworkCore.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonnelManagement.Business.Abstract;
using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Business.Concrate
{
    public class PersonnelManager : IPersonnelService
    {
        public IPersonnelRepository _personnelRepository { get; set; }
        private readonly AppSettings _appSettings;
        public PersonnelManager(IPersonnelRepository personnelRepository, IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _personnelRepository = personnelRepository;
        }


        public async Task<Personnel> Authenticate(string username, string password)
        {

            Personnel personnel = await _personnelRepository.GetPersonnel(p => p.UserName == username && p.Password == password);
            if (personnel == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, personnel.PersonnelId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            personnel.Token = tokenHandler.WriteToken(token);

            // remove password before returning
            personnel.Password = null;

            return personnel;
        }
    }
}
