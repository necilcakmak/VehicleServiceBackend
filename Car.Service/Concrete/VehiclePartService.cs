using AutoMapper;
using Car.Data.Abstract;
using Car.Entities.Concrete;
using Car.Entities.Dtos.VehiclePartsDtos;
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
    public class VehiclePartService:IVehiclePartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehiclePartService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult> Add(VehiclePartAddDto vehiclePartAddDto)
        {
            Dictionary<string, string> validationErrors = new Dictionary<string, string>();
            var uniquePartCode = await _unitOfWork.VehicleParts.GetAsync(x => x.PartCode == vehiclePartAddDto.PartCode);
            if (uniquePartCode != null)
            {
                Result result = new Result(ResultStatus.Error, "Validation Errors");
                validationErrors.Add("PartCode", "Parça Kodu Kullanımda.");
                result.validationErrors = validationErrors;
                return result;
            }
            var vehiclePart = _mapper.Map<VehiclePart>(vehiclePartAddDto);
            await _unitOfWork.VehicleParts.AddAsync(vehiclePart);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "Kayıt Oluşturuldu");
        }

        public async Task<IResult> Delete(int vehiclePartId)
        {
            var result = await _unitOfWork.VehicleParts.AnyAsync(a => a.Id == vehiclePartId);
            if (result)
            {
                var vehiclePart = await _unitOfWork.VehicleParts.GetAsync(a => a.Id == vehiclePartId);

                vehiclePart.IsActive = false;
                await _unitOfWork.VehicleParts.UpdateAsync(vehiclePart);
                await _unitOfWork.SaveAsync();
                return new Result(ResultStatus.Success, "Kayıt Silindi.");
            }
            return new Result(ResultStatus.Error, "Kayıt Bulunamadı.");
        }

        public async Task<IDataResult<VehiclePartDto>> Get(int vehiclePartId)
        {
            var vehiclePart = await _unitOfWork.VehicleParts.GetAsync(c => c.Id == vehiclePartId, c => c.Vehicle);
            if (vehiclePart != null)
            {
                return new DataResult<VehiclePartDto>(ResultStatus.Success, _mapper.Map<VehiclePartDto>(vehiclePart));
            }
            return new DataResult<VehiclePartDto>(ResultStatus.Error, "Böyle bir parça bulunamadı", null);
        }

        public async Task<IDataResult<IList<VehiclePartDto>>> GetAll()
        {
            var vehicleParts = await _unitOfWork.VehicleParts.GetAllAsync(x=>x.IsActive==true, v => v.Vehicle);
            if (vehicleParts.Count > -1)
            {
                return new DataResult<List<VehiclePartDto>>(ResultStatus.Success, _mapper.Map<List<VehiclePartDto>>(vehicleParts));
            }
            return new DataResult<List<VehiclePartDto>>(ResultStatus.Error, "Parça  bulunamadı.", null);
        }

        public async Task<IResult> Update(VehiclePartAddDto vehiclePartAddDto)
        {
            Dictionary<string, string> validationErrors = new Dictionary<string, string>();
            var vehiclePartInDb = await _unitOfWork.VehicleParts.GetAsync(x => x.PartCode == vehiclePartAddDto.PartCode &&x.Id!=vehiclePartAddDto.Id);
            
            if (vehiclePartInDb != null)
            {
                Result result = new Result(ResultStatus.Error, "Validation Errors");
                validationErrors.Add("PartCode", "Parça Kodu Kullanımda.");
                result.validationErrors = validationErrors;
                return result;
            }
            var vehiclePart = _mapper.Map<VehiclePart>(vehiclePartAddDto);
            await _unitOfWork.VehicleParts.UpdateAsync(vehiclePart);
            await _unitOfWork.SaveAsync();
            return new Result(ResultStatus.Success, "Parça Kaydedildi.");
        }
    }
}
