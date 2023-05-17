using FluentValidation;
using HomeApi.Contracts.Models.Devices;

namespace HomeApi.Contracts.Validation
{
    public class AddDeviceRequestValidator : AbstractValidator<AddDevicesRequest>
    {
        string[] _validLocations;
        public AddDeviceRequestValidator()
        {
            _validLocations = new[]
            {
                "Kitchen",
                "Bathroom",
                "Livingroom",
                "Toilet"
            };
            RuleFor(x => x.Name).NotEmpty(); // Проверим на null и на пустое свойство
            RuleFor(x => x.Manufacturer).NotEmpty();
            RuleFor(x => x.Model).NotEmpty();
            RuleFor(x => x.SerialNumber).NotEmpty();
            RuleFor(x => x.CurrentVolts).NotEmpty().InclusiveBetween(120, 220); // Проверим, что значение в заданном диапазоне
            RuleFor(x => x.GasUsage).NotNull();
            RuleFor(x => x.Location).NotEmpty().Must(BeSupported).WithMessage($"Please choose one of the following locations: {string.Join(", ", _validLocations)}");
        }
        private bool BeSupported(string location)
        {
            // Проверим, содержится ли значение в списке допустимых
            return _validLocations.Any(e => e == location);
        }
    }
}

