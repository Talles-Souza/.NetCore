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

        public async Task<ResultService<PurchaseDTO>> Create(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null) return ResultService.Fail<PurchaseDTO>("Purchase must be informed");
            var validate =  new PurchasesDTOValidator().Validate(purchaseDTO);
            if (!validate.IsValid) return ResultService.RequestError<PurchaseDTO>("Validation problems", validate);
            var productId = await productRepository.FindByIdCod(purchaseDTO.Cod);
            var personId = await personRepository.FindByIdDocument(purchaseDTO.Document);
            var purchase = new Purchase(productId,personId);
            var data = await purchaseRepository.Create(purchase);
            purchaseDTO.Id = data.Id;
            return ResultService.Ok<PurchaseDTO>(purchaseDTO);
        }
    }
}
