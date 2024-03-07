using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Categories.DeleteCategory
{
    public sealed class DeleteCategoryCommandHandler(ICategoryRepository _categoryRepository)
        : IRequestHandler<DeleteCategoryCommand, Result>
    {
        public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryRequest = await _categoryRepository.GetByIdAsync(request.Id);

            if (categoryRequest.IsFailure) return categoryRequest;

            var result = await _categoryRepository.RemoveAsync(request.Id);

            if (!result.IsFailure) return result;

            return Result.Succeeded();
        }
    }
}
