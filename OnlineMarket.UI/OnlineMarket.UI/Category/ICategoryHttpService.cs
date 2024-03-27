using OnlineMarket.Application.Categories.AddCategory;
using OnlineMarket.Application.Categories.AddSubcategory;
using OnlineMarket.Application.Categories.EditCategory;
using OnlineMarket.Application.Categories.GetAllCategories;
using OnlineMarket.Domain.Abstractions.Result;

namespace OnlineMarket.UI.Category
{
    public interface ICategoryHttpService
    {
        public Task<Result<IEnumerable<CategoryResponse>>> GetCategories();
        public Task<Result> PostCategory(AddCategoryCommand request);
        public Task<Result> PostSubCategory(Guid Id, AddSubcategoryRequest request);
        public Task<Result> DeleteCategory(Guid Id);
        public Task<Result<CategoryResponse>> GetCategoryById(Guid Id);
        public Task<Result> PutCategory(Guid Id, UpdateCategoryCommandRequest request);
    }
}
