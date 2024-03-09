using MediatR;
using OnlineMarket.Domain.DomainErrors.CategoryErrors;
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
            if(await _categoryRepository.GetByIdAsync(request.Id) == null)
            {
                return Result.Failure(CategoryErrors.CategoryNotExists);
            }

            await _categoryRepository.RemoveAsync(request.Id);

            return Result.Succeeded();
        }
    }
}
