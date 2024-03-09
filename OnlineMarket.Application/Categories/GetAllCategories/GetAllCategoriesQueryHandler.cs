using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Categories.GetAllCategories
{
    public sealed class GetAllCategoriesQueryHandler(ICategoryRepository _categoryRepository)
        : IRequestHandler<GetAllCategoriesQuery, Result<IEnumerable<CategoryResponse>>>
    {
        public async Task<Result<IEnumerable<CategoryResponse>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetAllAsync();

            
            return Result<IEnumerable<CategoryResponse>>.Succeeded(ToCategoryResponse(categories));
        }

        private IEnumerable<CategoryResponse> ToCategoryResponse(IEnumerable<Category> categories)
        {
           if(categories == null)
           {
                return Enumerable.Empty<CategoryResponse>();
           }

            return categories.Select(category => new CategoryResponse(category.Id, category.Name, ToCategoryResponse(category.SubCategories)));
        }
    }
}
