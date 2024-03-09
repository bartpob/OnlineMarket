using MediatR;
using OnlineMarket.Application.Categories.Errors;
using OnlineMarket.Application.Categories.GetAllCategories;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Categories.GetCategory
{
    public sealed class GetCategoryQueryHandler(ICategoryRepository _categoryRepository)
        : IRequestHandler<GetCategoryQuery, Result<CategoryResponse>>
    {
        public async Task<Result<CategoryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if(category == null)
            {
                return Result<CategoryResponse>.Failure(CategoryErrors.CategoryNotExists);
            }

            return Result<CategoryResponse>.Succeeded(new CategoryResponse(category.Id, category.Name, ToCategoryResponse(category.SubCategories)));
        }

        private IEnumerable<CategoryResponse> ToCategoryResponse(IEnumerable<Category> categories)
        {
            if (categories == null)
            {
                return Enumerable.Empty<CategoryResponse>();
            }

            return categories.Select(category => new CategoryResponse(category.Id, category.Name, ToCategoryResponse(category.SubCategories)));
        }
    }
}
