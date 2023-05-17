using AutoMapper;
using HomeApi.Configuration;
using HomeApi.Contracts;
using HomeApi.Contracts.Models.Home;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace HomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        // Ссылка на объект конфигурации
        public IOptions<HomeOptions> _options;
        private IMapper _mapper;
        // Инициализация конфигурации при вызове конструктора
        public HomeController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод для получения информации о доме
        /// </summary>
        [HttpGet] // Для обслуживания Get-запросов
        [Route("info")] // Настройка маршрута с помощью атрибутов
        public IActionResult Info()
        {
            var infoResponse = _mapper.Map<HomeOptions, InfoResponse>(_options.Value);
          
            return StatusCode(200, infoResponse);
        }
    }
}