using Domain.Base;
using Domain.Contracts.Application;
using Domain.Contracts.Persistance;
using Domain.Dtos;
using Domain.Entities;

namespace Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        private static CategoryDto Mapper(CategoryEntity category)
        {
            return new CategoryDto
            {
                Id = category.idcategoria,
                Description = category.descripcion,
                Name = category.nombre,
                State = category.estado
            };
        }

        public async Task<BaseResponse<List<CategoryDto>>> GetAll()
        {
            var categories = await this._categoryRepository.GetAll();
            var data = new List<CategoryDto>();
            foreach (var category in categories)
            {
                data.Add(Mapper(category));
            }
            return new BaseResponse<List<CategoryDto>>
            {
                Data = data,
                Code = System.Net.HttpStatusCode.OK,
                Message = "Consulta satisfactoria"
            };
        }

        public async Task<BaseResponse<CategoryDto>> GetById(int id)
        {
            if (id <= 0) throw new Exception("El id de búsqueda no es valido");

            var category = await this._categoryRepository.GetById(id);
            var data = Mapper(category);
            return new BaseResponse<CategoryDto>
            {
                Data = data,
                Code = System.Net.HttpStatusCode.OK,
                Message = "Consulta satisfactoria"
            };
        }
    }
}