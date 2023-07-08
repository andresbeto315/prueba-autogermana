using Domain.Contracts.Persistance;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Context;

namespace Persistance.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DBContextAutogermana _db;

        public CategoryRepository(DBContextAutogermana db)
        {
            this._db = db;
        }

        public async Task<List<CategoryEntity>> GetAll()
        {
            return await this._db.categoria.Where(c => c.estado == true).ToListAsync();
        }

        public async Task<CategoryEntity> GetById(int id)
        {
            return await this._db.categoria.Where(c => c.idcategoria == id && c.estado == true).FirstOrDefaultAsync();
        }
    }
}