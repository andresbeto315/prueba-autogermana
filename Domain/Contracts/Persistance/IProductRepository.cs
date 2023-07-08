using Domain.Entities;

namespace Domain.Contracts.Persistance
{
    public interface IProductRepository
    {
        Task<List<ProductEntity>> GetAll();
        Task<ProductEntity> GetById(int id);
        Task<ProductEntity> GetByCode(string code);
    }
}