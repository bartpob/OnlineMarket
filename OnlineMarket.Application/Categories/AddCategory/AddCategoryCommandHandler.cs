using MediatR;
using OnlineMarket.Domain.DomainErrors.CategoryErrors;
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
            if(string.IsNullOrEmpty(request.Name))
            {
                return Result.Failure(CategoryErrors.EmptyName);
            }

            if (await _categoryRepository.GetByNameAsync(request.Name) != null)
            {
                return Result.Failure(CategoryErrors.NameTaken);
            }

            await _categoryRepository.AddAsync(new Category(request.Name));

            return Result.Succeeded();
        }
    }
}
