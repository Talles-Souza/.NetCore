using Application.DTOs;
using Application.Service.Interfaces;
using Domain.Entities;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service 
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IProductRepository productRepository;
        private readonly IPersonRepository personRepository;
        private readonly IPurchaseRepository purchaseRepository;

        public PurchaseService(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository)
        {
            this.productRepository = productRepository;
            this.personRepository = personRepository;
            this.purchaseRepository = purchaseRepository;
        }

        public async Task<ResultService<PurchasesDTO>> Create(PurchasesDTO purchasesDTO)
        {
            if (purchasesDTO == null) return ResultService.Fail<PurchasesDTO>("Purchase must be informed");
            var validate =  new PurchasesDTOValidator().Validate(purchasesDTO);
            if (!validate.IsValid) return ResultService.RequestError<PurchasesDTO>("Validation problems", validate);
            var productId = await productRepository.FindByIdCod(purchasesDTO.Cod);
            var personId = await personRepository.FindByIdDocument(purchasesDTO.Document);
            var purchase = new Purchase(productId,personId);
            var data = await purchaseRepository.Create(purchase);
            purchasesDTO.Id = data.Id;
            return ResultService.Ok<PurchasesDTO>(purchasesDTO);
        }
    }
}
