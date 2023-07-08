using Domain.Base;
using Domain.Dtos;

namespace Domain.Contracts.Application
{
    public interface IProductService
    {
        Task<BaseResponse<List<ProductDto>>> GetAll();
        Task<BaseResponse<ProductDto>> GetById(int id);
        Task<BaseResponse<ProductDto>> GetByCode(string code);
    }
}