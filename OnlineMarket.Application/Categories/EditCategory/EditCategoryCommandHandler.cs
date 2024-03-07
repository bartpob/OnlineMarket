using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Categories.EditCategory
{
    public sealed class EditCategoryCommandHandler(ICategoryRepository _categoryRepository)
        : IRequestHandler<EditCategoryCommand, Result>
    {
        public async Task<Result> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryRequest = await _categoryRepository.GetByIdAsync(request.Id);

            if (categoryRequest.IsFailure) return categoryRequest;

            categoryRequest.Body!.Update(request.Name);

            var result = await _categoryRepository.UpdateAsync(categoryRequest.Body);

            return result;
        }
    }
}
