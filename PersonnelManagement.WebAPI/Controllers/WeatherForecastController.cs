using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FrameworkCore.Abstract;
using FrameworkCore.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonnelManagement.Business.Abstract;
using PersonnelManagement.Business.Concrete;
using PersonnelManagement.EntityFramework.Concrete;

namespace PersonnelManagement.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDepartmentService _departmentService;
        private readonly IUnitOfWork _unitOfWork;


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDepartmentService departmentServicek, IUnitOfWork unitOfWork)
        {
            _departmentService = departmentServicek;
            _logger = logger;
            _unitOfWork = unitOfWork;

        }

        [HttpPost]
        public async Task<IActionResult> Save()
        {
            await _departmentService.AddAsync(new Department { Name = "Deneme2", CreatedOn = DateTime.Now.AddDays(5), ModifiedOn = DateTime.Now.AddDays(4) });
            return NoContent();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
