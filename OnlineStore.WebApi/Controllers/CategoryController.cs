using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.Application.Common.DTOs.Categories;
using OnlineStore.Application.Features.Categories.Commands.CreateCategory;
using OnlineStore.Application.Features.Categories.Commands.DeleteCategory;
using OnlineStore.Application.Features.Categories.Commands.UpdateCategory;
using OnlineStore.Application.Features.Categories.Queries.GetAllCategory;
using OnlineStore.Application.Features.Categories.Queries.GetByIdCategory;

namespace OnlineStore.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var result = await _mediator.Send(new GetAllCategoryQuery());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategoryById(long id)
        {
            var result = await _mediator.Send(new GetByIdCategoryQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<long>> CreateCategory(CreateCategoryCommand command)
        {
            var categoryId = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryId }, categoryId);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CategoryDto>> UpdateCategory(long id, UpdateCategoryCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID mismatch");
            var result = await _mediator.Send(command);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCategory(long id)
        {
            await _mediator.Send(new DeleteCategoryCommand(id));
            return NoContent();
        }
    }
}
