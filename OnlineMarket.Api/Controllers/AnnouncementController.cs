using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Application.Announcements.AcceptAnnoucement;
using OnlineMarket.Application.Announcements.AddAnnoucement;
using OnlineMarket.Application.Announcements.DeleteAnnoucement;
using OnlineMarket.Application.Announcements.EditAnnoucement;
using OnlineMarket.Application.Announcements.GetAllAnnouncements;
using OnlineMarket.Application.Announcements.GetAnnouncement;
using OnlineMarket.Application.Announcements.GetUserAnnouncements;
using OnlineMarket.Application.Announcements.GetWaitingAnnouncements;
using OnlineMarket.Application.Announcements.RejectAnnoucement;
using OnlineMarket.Domain.DomainErrors.AnnouncementError;
using OnlineMarket.Domain.Users;
using System.Security.Claims;

namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController(IMediator _mediator)
        : ControllerBase
    {
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddAnnouncement(AddAnnouncementRequest request)
        {
            var userId = User.FindFirstValue("uid")!;

            var result = await _mediator.Send(new AddAnnouncementCommand(
                Guid.Parse(userId),
                request.CategoryId,
                request.Description,
                request.price,
                request.City
                ));

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnouncementResponse>>> GetAllAnnouncements()
        {
            var result = await _mediator.Send(new GetAllAnnouncementsQuery());

            if(result.IsFailure)
            {
                return NotFound();
            }

            return Ok(result.Body);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<IEnumerable<AnnouncementResponse>>> GetAnnouncementById(Guid Id)
        {
            var result = await _mediator.Send(new GetAnnouncementQuery(Id));

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return Ok(result.Body);
        }

        [HttpGet("User")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<AnnouncementResponse>>> GetLoggedInUserAnnouncements()
        {
            var userId = User.FindFirstValue("uid")!;

            var result = await _mediator.Send(
                new GetUserAnnouncementsQuery(Guid.Parse(userId))
                );

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return Ok(result.Body);
        }

        [HttpGet("User/{Id}")]
        public async Task<ActionResult<IEnumerable<AnnouncementResponse>>> GetUserAnnouncements(Guid Id)
        {
            var result = await _mediator.Send(new GetUserAnnouncementsQuery(Id));

            if (result.IsFailure)
            {
                return NotFound(result.Error);
            }

            return Ok(result.Body);
        }

        [HttpGet("Moderator/Waiting")]
        [Authorize(Roles = Roles.Moderator)]
        public async Task<ActionResult<IEnumerable<AnnouncementResponse>>> GetWaitingAnnouncements()
        {
            var result = await _mediator.Send(new GetWaitingAnnouncementsQuery());

            if(result.IsFailure)
            {
                return NotFound();
            }

            return Ok(result.Body);
        }

        [HttpPut("{Id}")]
        [Authorize]
        public async Task<ActionResult> UpdateAnnouncement(EditAnnouncementRequest request)
        {
            var userId = User.FindFirstValue("uid")!;

            var result = await _mediator.Send(new EditAnnouncementCommand(
                request.Id,
                Guid.Parse(userId),
                request.CategoryId,
                request.Description,
                request.Price,
                request.City
                ));

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete("{Id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAnnouncement(Guid Id)
        {
            var userId = User.FindFirstValue("uid")!;

            var result = await _mediator.Send(new DeleteAnnouncementCommand(
                Guid.Parse(userId),
                Id
                ));

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPost]
        [Route("Moderator/Verify/Accept/{Id}")]
        [Authorize(Roles=Roles.Moderator)]
        public async Task<ActionResult> AcceptAnnouncement(Guid Id)
        {
            var result = await _mediator.Send(new AcceptAnnouncementCommand(Id));

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPost("Moderator/Verify/Reject/{Id}")]
        [Authorize(Roles = Roles.Moderator)]
        public async Task<ActionResult> RejectAnnouncement(Guid Id, RejectAnnouncementRequest request)
        {
            var result = await _mediator.Send(new RejectAnnouncementCommand(Id, request.Note));

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
    }
}
