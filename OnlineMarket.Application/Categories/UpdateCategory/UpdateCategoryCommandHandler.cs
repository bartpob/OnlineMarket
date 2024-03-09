using MediatR;
using OnlineMarket.Domain.DomainErrors.CategoryErrors;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Categories.EditCategory
{
    public sealed class UpdateCategoryCommandHandler(ICategoryRepository _categoryRepository)
        : IRequestHandler<UpdateCategoryCommand, Result>
    {
        public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrEmpty(request.Name))
            {
                return Result.Failure(CategoryErrors.EmptyName);
            }

            if (await _categoryRepository.GetByNameAsync(request.Name) != null)
            {
                return Result.Failure(CategoryErrors.NameTaken);
            }

            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category == null)
            {
                return Result.Failure(CategoryErrors.CategoryNotExists);
            }

            category.Update(request.Name);

            await _categoryRepository.UpdateAsync(category);

            return Result.Succeeded();
        }
    }
}
