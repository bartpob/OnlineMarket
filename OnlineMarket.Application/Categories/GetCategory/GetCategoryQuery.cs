using MediatR;
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
    public sealed record class GetCategoryQuery(Guid Id)
        : IRequest<Result<CategoryResponse>>;
}
