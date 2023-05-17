using AutoMapper;
using HomeApi.Configuration;
using HomeApi.Contracts.Devices;
using HomeApi.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using HomeApi.Contracts.Validation;

namespace HomeApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DevicesController : ControllerBase
    {
        private IOptions<HomeOptions> _options;
        private IMapper _mapper;

        public DevicesController(IOptions<HomeOptions> options, IMapper mapper)
        {
            _options = options;
            _mapper = mapper;
        }

        /// <summary>
        /// Просмотр списка подключенных устройств
        /// </summary>
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return StatusCode(200, "Устройства отсутствуют");
        }

        /// <summary>
        /// Добавление нового устройства
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public IActionResult Add(
            [FromBody]
            AddDevicesRequest request)
        {
          var validator = new AddDeviceRequestValidator();
            var result = validator.Validate(request);
            if(!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            return StatusCode(200, $"Устройство {request.Name} добавлено!");
        }
    }
}
