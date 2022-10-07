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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<ResultService<ProductDTO>> Create(ProductDTO productDTO)
        {
            if (productDTO == null) return ResultService.Fail<ProductDTO>("Object must be informed");
            var result = new ProductDTOValidator().Validate(productDTO);
            if (!result.IsValid) return ResultService.RequestError<ProductDTO>("Problem in validation", result);
            var product =  _mapper.Map<Product>(productDTO);
            var data = await _repository.Create(product);
            return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(data));
        }

        public async Task<ResultService> Delete(int id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return ResultService.Fail("Product not found");
            await _repository.Delete(id);
            return ResultService.Ok($"Product with ID : {id} was delected");
        }

        public async Task<ResultService<ICollection<ProductDTO>>> FindByAll()
        {
            var products = await _repository.FindByAll();
            return ResultService.Ok<ICollection<ProductDTO>>(_mapper.Map<ICollection<ProductDTO>>(products));
        }

        public async Task<ResultService<ProductDTO>> FindById(int id)
        {
            var product = await _repository.FindById(id);
            if (product == null) return ResultService.Fail<ProductDTO>("Product not found");
            return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(product));
        }

        public async  Task<ResultService> Update(ProductDTO productDTO)
        {
            if (productDTO == null) return ResultService.Fail("Product must be informed");
            var validation = new ProductDTOValidator().Validate(productDTO);
            if (!validation.IsValid) return ResultService.RequestError("Validation problems", validation);
            var product = await _repository.FindById(productDTO.Id);
            if (product == null) return ResultService.Fail("Product not found");
            product = _mapper.Map<ProductDTO,Product>(productDTO,product);
            await _repository.Update(product);
            return ResultService.Ok("Product edited successfull");
        }
    }
}
