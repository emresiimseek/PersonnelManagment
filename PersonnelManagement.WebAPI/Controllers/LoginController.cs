using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameworkCore.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonnelManagement.Business.Abstract;
using PersonnelManagement.EntityFramework.Concrate;
using PersonnelManagement.WebAPI.Filters.Authentication;

namespace PersonnelManagement.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private IPersonnelService _personnelService;
        public LoginController(IPersonnelService personnelService)
        {
            _personnelService = personnelService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Authenticate([FromBody] Personnel userParam)
        {
            Personnel personnel =  await _personnelService.Authenticate(userParam.UserName, userParam.Password);

            if (personnel == null)
                return  BadRequest(new { message = "Username or password is incorrect" });
            return  Ok(personnel);
        }


    }
}
