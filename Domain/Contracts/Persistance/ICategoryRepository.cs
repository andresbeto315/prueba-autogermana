using Domain.Entities;

namespace Domain.Contracts.Persistance
{
    public interface ICategoryRepository
    {
        Task<List<CategoryEntity>> GetAll();
        Task<CategoryEntity> GetById(int id);
    }
}