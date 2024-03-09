using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineMarket.Application.Categories.AddCategory;
using OnlineMarket.Application.Categories.AddSubcategory;
using OnlineMarket.Application.Categories.DeleteCategory;
using OnlineMarket.Application.Categories.EditCategory;
using OnlineMarket.Application.Categories.GetAllCategories;
using OnlineMarket.Application.Categories.GetCategory;
using OnlineMarket.Domain.Categories;

namespace OnlineMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateCategory(AddCategoryCommand request)
        {
            var result = await _mediator.Send(request);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPost("{Id}")]
        public async Task<ActionResult> CreateSubcategory(Guid Id, [FromBody] AddSubcategoryRequest request)
        {
            var command = new AddSubcategoryCommand(Id, request.Name);
            var result = await _mediator.Send(command);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            
            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> GetCategories()
        {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query);

            return Ok(result.Body);
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<CategoryResponse>> GetCategoryById(Guid Id)
        {
            var query = new GetCategoryQuery(Id);
            var result = await _mediator.Send(query);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok(result.Body);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> DeleteCategory(Guid Id)
        {
            var command = new DeleteCategoryCommand(Id);

            var result = await _mediator.Send(command);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }

        [HttpPut("{Id}")]
        public async Task<ActionResult> UpdateCategory(Guid Id, EditCategoryCommandRequest request)
        {
            var command = new UpdateCategoryCommand(Id, request.Name);

            var result = await _mediator.Send(command);

            if(result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            return Ok();
        }
        

    }
}
