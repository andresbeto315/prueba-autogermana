using Domain.Base;
using Domain.Dtos;

namespace Domain.Contracts.Application
{
    public interface ICategoryService
    {
        Task<BaseResponse<List<CategoryDto>>> GetAll();
        Task<BaseResponse<CategoryDto>> GetById(int id);
    }
}