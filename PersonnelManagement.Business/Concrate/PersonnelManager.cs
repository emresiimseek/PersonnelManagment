using FrameworkCore.Abstract;
using FrameworkCore.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PersonnelManagement.Business.Abstract;
using PersonnelManagement.EntityFramework.Concrate;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelManagement.Business.Concrate
{
    public class PersonnelManager : IPersonnelService
    {
        public IPersonnelRepository _personnelRepository { get; set; }
        private readonly AppSettings _appSettings;
        private IUnitOfWork _unitOfWork;
        public PersonnelManager(IPersonnelRepository personnelRepository, IOptions<AppSettings> appSettings, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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
                    new Claim("id", personnel.PersonnelId.ToString())
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

        public async Task<Personnel> AddAsync(Personnel entity)
        {
            await _unitOfWork.Personnel.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public void Update(Personnel entity)
        {
            _unitOfWork.Personnel.Update(entity);
            _unitOfWork.Commit();
        }

        public async Task<Personnel> GetByIdAsync(int Id)
        {
            return await _unitOfWork.Personnel.GetByIdAsync(Id);
        }

        public void Delete(Personnel entity)
        {
            _unitOfWork.Personnel.Delete(entity);
            _unitOfWork.Commit();
        }

        public void Delete(object EntityId)
        {
            _unitOfWork.Department.Delete(EntityId);
            _unitOfWork.Commit();
        }

        public  async Task<Personnel> GetAsync(Expression<Func<Personnel, bool>> filter)
        {
            return await _unitOfWork.Personnel.GetAsync(filter);
        }

        public IEnumerable<Personnel> GetAll(Expression<Func<Personnel, bool>> filter = null)
        {
            return _unitOfWork.Personnel.GetAll(filter);
        }
    }
}
