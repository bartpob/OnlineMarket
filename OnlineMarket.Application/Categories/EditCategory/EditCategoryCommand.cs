using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Categories.EditCategory
{
    public record class EditCategoryCommand(Guid Id, string Name)
        : IRequest<Result>;
}
