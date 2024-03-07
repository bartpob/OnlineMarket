using MediatR;
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
        : IRequestHandler<GetCategoryQuery, Result<Category>>
    {
        public async Task<Result<Category>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.GetByIdAsync(request.Id);

            return result;
        }
    }
}
