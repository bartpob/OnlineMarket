using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using OnlineMarket.Application.Categories.AddCategory;
using OnlineMarket.Application.Categories.AddSubcategory;
using OnlineMarket.Application.Categories.DeleteCategory;
using OnlineMarket.Application.Categories.EditCategory;
using OnlineMarket.Application.Categories.GetAllCategories;
using OnlineMarket.Application.Categories.GetCategory;

namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator _mediator)
        : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategories()
        {
            var result = await _mediator.Send(new GetAllCategoriesQuery());

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Body);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CategoryResponse>> GetCategoryById(Guid Id)
        {
            var result = await _mediator.Send(new GetCategoryQuery(Id));


            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Body);
        }

        [HttpPost]
        public async Task<ActionResult> CreateCategory(AddCategoryCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPost("{Id}")]
        public async Task<ActionResult> CreateSubCategory(Guid Id, AddSubcategoryRequest request)
        {
            var result = await _mediator.Send(new AddSubcategoryCommand(Id, request.Name));

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteCategory(Guid Id)
        {
            var result = await _mediator.Send(new DeleteCategoryCommand(Id));

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateCategory(Guid Id, UpdateCategoryCommandRequest request)
        {
            var result = await _mediator.Send(new UpdateCategoryCommand(Id, request.Name));

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
          
    }
}
