using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Producto.Api.Responses;
using Products.Core.DTO;
using Products.Core.Entities;
using Products.Core.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
namespace ProductsAPI.Controllers
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = _productService;
            _mapper = mapper;
        }

        /// <summary>/// Retrieve all posts
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetProduct))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductDTO>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetProduct()
        {
            var product = _productService.GetProducts();
            var productDtos = _mapper.Map<IEnumerable<ProductDTO>>(product);


            var response = new ApiResponse<IEnumerable<ProductDTO>>(productDtos);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProducts(id);
            var productDto = _mapper.Map<ProductDTO>(product);
            var response = new ApiResponse<ProductDTO>(productDto);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Product(ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);

            await _productService.InsertProducts(product);

            productDto = _mapper.Map<ProductDTO>(product);
            var response = new ApiResponse<ProductDTO>(productDto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, ProductDTO productDto)
        {
            var product = _mapper.Map<Product>(productDto);
            product.Id = id;

            var result = await _productService.UpdateProducts(product);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProducts(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
