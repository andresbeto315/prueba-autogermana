using Domain.Contracts.Persistance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly DBContextAutogermana _db;

        public ProductRepository(DBContextAutogermana db)
        {
            this._db = db;
        }

        public async Task<List<ProductEntity>> GetAll()
        {
            return await this._db.product.Where(p => p.estado == true).ToListAsync();
        }

        public async Task<ProductEntity> GetByCode(string code)
        {
            return await this._db.product.Where(p => p.codigo == code && p.estado == true).FirstOrDefaultAsync();
        }

        public async Task<ProductEntity> GetById(int id)
        {
            return await this._db.product.Where(p => p.idproducto == id && p.estado == true).FirstOrDefaultAsync();
        }
    }
}