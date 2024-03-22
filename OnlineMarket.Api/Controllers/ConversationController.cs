using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Application.Conversations.GetAllConversations;
using OnlineMarket.Application.Conversations.GetConversation;
using OnlineMarket.Application.Conversations.SendMessage;
using OnlineMarket.Application.Conversations.StartNewConversation;
using System.Security.Claims;

namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ConversationController(IMediator _mediator)
        : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ConversationResponse>>> GetConversations()
        {
            var userId = User.FindFirstValue("uid")!;

            var result = await _mediator.Send(new GetAllConversationsQuery(
                Guid.Parse(userId)
                ));

            return Ok(result.Body);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<ConversationResponse>> GetConversations(Guid Id)
        {
            var userId = User.FindFirstValue("uid")!;

            var result = await _mediator.Send(new GetConversationQuery(
                Id,
                Guid.Parse(userId)
                ));

            return Ok(result.Body);
        }

        [HttpPost("SendMessage")]
        public async Task<ActionResult> SendMessage(SendMessageRequest request)
        {
            var userId = User.FindFirstValue("uid")!;

            var result = await _mediator.Send(new SendMessageCommand(
                request.ConversationId,
                Guid.Parse(userId),
                request.Text
                ));

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPost("StartConversation")]
        public async Task<ActionResult> StartConversation(StartNewConversationRequest request)
        {
            var userId = User.FindFirstValue("uid")!;

            var result = await _mediator.Send(new StartNewConversationCommand(
                request.AnnouncementId,
                Guid.Parse(userId),
                request.Text
                ));

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

    }
}
