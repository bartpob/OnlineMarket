using MediatR;
using OnlineMarket.Domain.Abstractions.Result;
using OnlineMarket.Domain.Announcements;
using OnlineMarket.Domain.Categories;
using OnlineMarket.Domain.DomainErrors.AnnouncementError;
using OnlineMarket.Domain.DomainErrors.CategoryErrors;
using OnlineMarket.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMarket.Application.Announcements.AddAnnoucement
{
    public sealed class AddAnnouncementCommandHandler(IAnnoucementRepository _announcementRepository, 
        IUserRepository _userRepository, 
        ICategoryRepository _categoryRepository)
        : IRequestHandler<AddAnnouncementCommand, Result>
    {
        public async Task<Result> Handle(AddAnnouncementCommand request, CancellationToken cancellationToken)
        {
            if(string.IsNullOrEmpty(request.Description) || string.IsNullOrEmpty(request.Header) || string.IsNullOrEmpty(request.City) || request.Price <= 0)
            {
                return Result.Failure(AnnouncementError.InvalidValue);
            }

            var category = await _categoryRepository.GetByIdAsync(request.CategoryId);

            if(category == null)
            {
                return Result.Failure(CategoryErrors.CategoryNotExists);
            }

            await _announcementRepository.AddAsync(new Announcement(
                await _userRepository.GetById(request.UserId),
                category,
                request.Header,
                request.Description,
                request.Price,
                request.City
                ));

            return Result.Succeeded();
        }
    }
}
