﻿using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Interfaces
{
    public interface IPurchaseService
    {
        Task<ResultService<PurchaseDTO>> Create(PurchaseDTO purchasesDTO);
    }
}
