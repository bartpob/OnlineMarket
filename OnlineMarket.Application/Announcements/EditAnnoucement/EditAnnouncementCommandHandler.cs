using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.Categories;
using OnlineMarket.Domain.DomainErrors.AnnouncementError;
using OnlineMarket.Domain.DomainErrors.CategoryErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.EditAnnoucement
{
    public sealed class EditAnnouncementCommandHandler(IAnnoucementRepository _announcementRepository, ICategoryRepository _categoryRepository)
        : IRequestHandler<EditAnnouncementCommand, Result>
    {
        public async Task<Result> Handle(EditAnnouncementCommand request, CancellationToken cancellationToken)
        {
            var announcement = await _announcementRepository.GetByIdAsync(request.Id);

            if (announcement == null)
            {
                return Result.Failure(AnnouncementError.AnnouncementNotExists);
            }

            if (string.IsNullOrEmpty(request.Description) || string.IsNullOrEmpty(request.City) || request.Price <= 0)
            {
                return Result.Failure(AnnouncementError.InvalidValue);
            }

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if (category == null)
            {
                return Result.Failure(CategoryErrors.CategoryNotExists);
            }

            announcement.Update(request.Description, category, request.Price, request.City);

            await _announcementRepository.UpdateAsync(announcement);

            return Result.Succeeded();
        }
    }
}
