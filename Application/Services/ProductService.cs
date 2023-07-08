using Domain.Base;
using Domain.Contracts.Application;
using Domain.Contracts.Persistance;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        private static ProductDto Mapper(ProductEntity product)
        {
            return new ProductDto
            {
                Id = product.idproducto,
                Category = product.category,
                Code = product.codigo,
                Description = product.descripcion,
                Image = product.imagen,
                Name = product.nombre,
                Price = product.precio_venta,
                State = product.estado,
                Stock = product.stock
            };
        }

        public async Task<BaseResponse<List<ProductDto>>> GetAll()
        {
            var products = await this._productRepository.GetAll();
            var data = new List<ProductDto>();
            foreach (var product in products)
            {
                data.Add(Mapper(product));
            }
            return new BaseResponse<List<ProductDto>>
            {
                Data = data,
                Code = System.Net.HttpStatusCode.OK,
                Message = "Consulta satisfactoria"
            };
        }

        public async Task<BaseResponse<ProductDto>> GetByCode(string code)
        {
            if (string.IsNullOrEmpty(code)) throw new Exception("El codigo de búsqueda no es valido");

            var product = await this._productRepository.GetByCode(code);
            var data = Mapper(product);
            return new BaseResponse<ProductDto>
            {
                Data = data,
                Code = System.Net.HttpStatusCode.OK,
                Message = "Consulta satisfactoria"
            };
        }

        public async Task<BaseResponse<ProductDto>> GetById(int id)
        {
            if (id < 0) throw new Exception("El id de búsqueda no es valido");

            var product = await this._productRepository.GetById(id);
            var data = Mapper(product);
            return new BaseResponse<ProductDto>
            {
                Data = data,
                Code = System.Net.HttpStatusCode.OK,
                Message = "Consulta satisfactoria"
            };
        }
    }
}