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
    public sealed record GetAllCategoriesQuery
        : IRequest<Result<IEnumerable<CategoryResponse>>>;

    public sealed record CategoryResponse(Guid Id, string Name, IEnumerable<CategoryResponse> SubCategories)
    {
        public IEnumerable<CategoryResponse> GetAllCategories()
        {
            yield return this;

            foreach (var subCategory in SubCategories ?? Enumerable.Empty<CategoryResponse>())
            {
                foreach (var subCategoryRecursive in subCategory.GetAllCategories())
                {
                    yield return subCategoryRecursive;
                }
            }
        }
    }
}
