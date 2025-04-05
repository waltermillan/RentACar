using API.DTOs;
using Core.Entities;
using Core.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Services
{
    public class RentDTOService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICarRepository _carRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IRentRepository _rentRepository;
        private readonly IPayTypeRepository _payTypeRepository;

        public RentDTOService(ICustomerRepository customerRepository, 
                                  ICarRepository carRepository,
                                  IPriceRepository priceRepository,
                                  IRentRepository rentRepository,
                                  IPayTypeRepository payTypeRepository)
        {
            _customerRepository = customerRepository;
            _carRepository = carRepository;
            _priceRepository = priceRepository;
            _rentRepository = rentRepository;
            _payTypeRepository = payTypeRepository;
        }

        public async Task<RentDTO> GetRentDTOAsync(int customerId, int carId, int rentId, int payTypeId, int priceId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            var car = await _carRepository.GetByIdAsync(carId);
            var rent = await _rentRepository.GetByIdAsync(rentId);
            var payType = await _payTypeRepository.GetByIdAsync(payTypeId);
            var price = await _priceRepository.GetByIdAsync(priceId);

            if (customer is null || car is null || rent is null || payType is null || price is null)
                return null;

            var rentDTO = new RentDTO
            {
                Id = rent.Id,
                IdCustomer = customer.Id,
                Name = customer.Name,
                IdModel = car.Id,
                Model = car.Model,
                Brand = car.Brand,
                Day = rent.Day,
                DayRemaining = rent.DayRemaining,
                IdPayTypeName = payType.Id,
                PayTypeName = payType.Name,
                IdPrice = price.Id,
                Price = price.Value
            };

            return rentDTO;
        }

        public async Task <IEnumerable<RentDTO>> GetRentAllRents()
        {
            var rents = await _rentRepository.GetAllAsync();

            if (rents is null)
                return null;

            var rentsDTO = new List<RentDTO>();

            foreach (var rent in rents)
                {
                    var customer = await _customerRepository.GetByIdAsync(rent.IdCustomer);
                    var car = await _carRepository.GetByIdAsync(rent.IdCar);
                    var payType = await _payTypeRepository.GetByIdAsync(rent.PayTypeId);
                    var price = await _priceRepository.GetByIdAsync(rent.PriceId);

                    var rentDTO = new RentDTO
                    {
                        Id = rent.Id,
                        IdCustomer = customer.Id,
                        Name = customer.Name,
                        IdModel = car.Id,
                        Model = car.Model,
                        Brand = car.Brand,
                        Day = rent.Day,
                        DayRemaining = rent.DayRemaining,
                        IdPayTypeName = payType.Id,
                        PayTypeName = payType.Name,
                        IdPrice = price.Id,
                        Price = price.Value
                    };

                    rentsDTO.Add(rentDTO);
                }

            return rentsDTO;
        }
    }
}
