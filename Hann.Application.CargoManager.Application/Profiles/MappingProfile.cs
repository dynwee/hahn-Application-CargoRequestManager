using AutoMapper;
using Hann.Application.CargoManager.Application.DTOs.CargoRequests;
using Hann.Application.CargoManager.Application.DTOs.Terminals;
using Hann.Application.CargoManager.Application.DTOs.VehicleAllocations;
using Hann.Application.CargoManager.Application.DTOs.VehicleTypes;
using Hann.Application.CargoManager.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CargoRequest, CargoRequestDto>().ReverseMap();
            CreateMap<CargoRequest, CreateCargoRequestDto>().ReverseMap();
            CreateMap<CargoRequest, UpdateCargoRequestDto>().ReverseMap();
            CreateMap<CargoRequest, CargoRequestDetailsDto>().ReverseMap();

            CreateMap<Terminal, TerminalDto>().ReverseMap();
            //CreateMap<Terminal, LeaveRequestListDto>().ReverseMap();
            CreateMap<Terminal, CreateTerminalDto>().ReverseMap();
            CreateMap<Terminal, UpdateTerminalDto>().ReverseMap();

            CreateMap<VehicleAllocation, VehicleAllocationDto>().ReverseMap();
            CreateMap<VehicleAllocation, CreateVehicleAllocationDto>().ReverseMap();
            CreateMap<VehicleAllocation, UpdateVehicleAllocationDto>().ReverseMap();

            CreateMap<VehicleType, VehicleTypeDto>().ReverseMap();
            CreateMap<VehicleType, CreateVehicleTypeDto>().ReverseMap();
            CreateMap<VehicleType, UpdateVehicleTypeDto>().ReverseMap();
        }
    }
}
