using MediatR;
using OnlineMarket.Domain.DomainErrors.CategoryErrors;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Categories.AddSubcategory
{
    public sealed class AddSubcategoryCommandHandler(ICategoryRepository _categoryRepository)
        : IRequestHandler<AddSubcategoryCommand, Result>
    {
        public async Task<Result> Handle(AddSubcategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return Result.Failure(CategoryErrors.CategoryNotExists);
            }

            if (string.IsNullOrEmpty(request.Name))
            {
                return Result.Failure(CategoryErrors.EmptyName);
            }

            if (await _categoryRepository.GetByNameAsync(request.Name) != null)
            {
                return Result.Failure(CategoryErrors.NameTaken);
            }

            category.AddCategory(new Category(request.Name));

            await _categoryRepository.UpdateAsync(category);

            return Result.Succeeded();
        }
    }
}
