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
        : IRequestHandler<GetAllCategoriesQuery, Result<IEnumerable<Category>>>
    {
        public async Task<Result<IEnumerable<Category>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetAllAsync();

            return result;
        }
    }
}
