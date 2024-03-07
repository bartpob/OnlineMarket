using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Categories.AddCategory
{
    public sealed class AddCategoryCommandHandler(ICategoryRepository _categoryRepository)
        : IRequestHandler<AddCategoryCommand, Result>
    {
        public async Task<Result> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _categoryRepository.AddAsync(new Category(request.Name));

            if (result.IsFailure)
                return result;

            return Result.Succeeded();
        }
    }
}
