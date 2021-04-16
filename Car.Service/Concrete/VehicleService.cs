using AutoMapper;
using Car.Data.Abstract;
using Car.Entities.Concrete;
using Car.Entities.Dtos.CustomerDtos;
using Car.Entities.Dtos.VehicleDtos;
using Car.Service.Abstract;
using Car.Shared.Result.Abstract;
using Car.Shared.Result.Concrete;
using Car.Shared.Result.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car.Service.Concrete
{
    public class VehicleService : IVehicleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(VehicleAddDto vehicleAddDto)
        {
            Dictionary<string, string> validationErrors = new Dictionary<string, string>();
            var MarkaBrand = await _unitOfWork.Vehicles.GetAsync(x => x.Model == vehicleAddDto.Model && x.Brand== vehicleAddDto.Brand && x.IsActive==true);
            if (MarkaBrand != null)
            {
                Result result = new Result(ResultStatus.Error, "Validation Errors");
                validationErrors.Add("Model", "Aynı marka model araç bilgisi ekleyemezsiniz.");
                result.validationErrors = validationErrors;
                return result;
            }
            var vehicle = _mapper.Map<Vehicle>(vehicleAddDto);
            await _unitOfWork.Vehicles.AddAsync(vehicle);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "Araç Eklendi.");
        }

        public async Task<IResult> Delete(int vehicleId)
        {
            var result = await _unitOfWork.Vehicles.AnyAsync(a => a.Id == vehicleId);
            if (result)
            {
                var vehicle = await _unitOfWork.Vehicles.GetAsync(a => a.Id == vehicleId);

                vehicle.IsActive = false;
                await _unitOfWork.Vehicles.UpdateAsync(vehicle);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Kayıt Silindi.");
            }
            return new Result(ResultStatus.Error, "Kayıt Bulunamadı.");
        }

        public async Task<IDataResult<VehicleDto>> Get(int vehicleId)
        {
            var vehicle = await _unitOfWork.Vehicles.GetAsync(c => c.Id == vehicleId);
            if (vehicle != null)
            {
                return new DataResult<VehicleDto>(ResultStatus.Success, new VehicleDto
                {
                    Id=vehicle.Id,
                    Brand=vehicle.Brand,
                    Model=vehicle.Model,
                    CreatedDate = vehicle.CreatedDate,
                    ModifiedDate=vehicle.ModifiedDate,
                    
                });
            }
            return new DataResult<VehicleDto>(ResultStatus.Error, "Böyle bir araç bulunamadı", null);
        }

        public async Task<IDataResult<IList<VehicleDto>>> GetAll()
        {
            var vehicles = await _unitOfWork.Vehicles.GetAllAsync(x=>x.IsActive==true);
            if (vehicles.Count > -1)
            {
                return new DataResult<List<VehicleDto>>(ResultStatus.Success, _mapper.Map<List<VehicleDto>>(vehicles));
            }
            return new DataResult<List<VehicleDto>>(ResultStatus.Error, "Araçlar  bulunamadı.", null);
        }

        public async Task<IResult> Update(VehicleAddDto vehicleAddDto)
        {         
            var vehicleInDb = await _unitOfWork.VehicleParts.GetAsync(x => x.Id == vehicleAddDto.Id);         
            var vehicle = _mapper.Map<Vehicle>(vehicleAddDto);
            await _unitOfWork.Vehicles.UpdateAsync(vehicle);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "Araç Kaydedildi.");
        }
    }
}
