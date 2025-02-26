using Core.DTOs;
using Core.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class CustomerDTOService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICarRepository _carRepository;
        private readonly IPriceRepository _priceRepository;
        private readonly IRentRepository _rentRepository;
        private readonly IPayTypeRepository _payTypeRepository;

        public CustomerDTOService(ICustomerRepository customerRepository, 
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

        public async Task<CustomerDTO> GetCustomerDTOAsync(int customerId, int carId, int rentId, int payTypeId, int priceId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            var car = await _carRepository.GetByIdAsync(carId);
            var rent = await _rentRepository.GetByIdAsync(rentId);
            var payType = await _payTypeRepository.GetByIdAsync(payTypeId);
            var price = await _priceRepository.GetByIdAsync(priceId);

            if (customer == null || car == null || rent == null || payType == null || price == null)
            {
                return null;
            }

            var customerDTO = new CustomerDTO
            {
                Id = rent.Id,
                Name = customer.Name,
                Model = car.Model,
                Day = rent.Day,
                DayRemaining = rent.DayRemaining,
                PayTypeName = payType.Name,
                Price = price.Value
            };

            return customerDTO;
        }
    }
}
