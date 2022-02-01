﻿using Hann.Application.CargoManager.Application.DTOs.VehicleTypes;
using Hann.Application.CargoManager.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hann.Application.CargoManager.Application.Features.VehicleTypes.Requests.Commands
{
    public class UpdateVehicleTypeCommand : IRequest<BaseCommandResponse>
    {
        public UpdateVehicleTypeDto UpdateVehicleTypeDto { get; set; }
    }
}