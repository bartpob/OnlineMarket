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
    public record class GetAllCategoriesQuery
        : IRequest<Result<IEnumerable<Category>>>;
}
