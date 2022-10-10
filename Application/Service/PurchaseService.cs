using Application.DTOs;
using Application.Service.Interfaces;
using AutoMapper;
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
        private readonly IMapper mapper;

        public PurchaseService(IProductRepository productRepository, IPersonRepository personRepository, IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.personRepository = personRepository;
            this.purchaseRepository = purchaseRepository;
            this.mapper = mapper;
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

        public async Task<ResultService> Delete(int id)
        {
            var purchase = await purchaseRepository.FindById(id);
            if (purchase == null) return ResultService.Fail($"Purchase {id} not found");
           await purchaseRepository.Delete(purchase);
            return ResultService.Ok($"Purchase {id} successfully deleted ");

        }

        public async Task<ResultService<ICollection<PurchaseDetailDTO>>> FindByAllAsync()
        {
            var purchases = await purchaseRepository.FindByAll();
            return ResultService.Ok(mapper.Map<ICollection<PurchaseDetailDTO>>(purchases));
        }

        public async Task<ResultService<PurchaseDetailDTO>> FindByIdAsync(int id)
        {
            var purchase = await purchaseRepository.FindById(id);
            if (purchase == null) return ResultService.Fail<PurchaseDetailDTO>("Purchase not found");
            return ResultService.Ok(mapper.Map<PurchaseDetailDTO>(purchase));
             
        }

        public async Task<ResultService<PurchaseDTO>> Update(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null) return ResultService.Fail<PurchaseDTO>("object must be informed");
            var result = new PurchasesDTOValidator().Validate(purchaseDTO);
            if (!result.IsValid) return ResultService.RequestError<PurchaseDTO>("Validation problems", result);
            var purchase = await purchaseRepository.FindById(purchaseDTO.Id);
            if (purchase == null) return ResultService.Fail<PurchaseDTO>("Purchase not found");
            var productId = await productRepository.FindByIdCod(purchaseDTO.Cod);
            var personId = await personRepository.FindByIdDocument(purchaseDTO.Document);
            purchase.Edit(purchase.Id, productId, personId);
            await purchaseRepository.Update(purchase);
            return ResultService.Ok(purchaseDTO); 
        }
    }
}
