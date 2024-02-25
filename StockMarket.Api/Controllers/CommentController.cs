using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockMarket.DataService.Interfaces;
using StockMarket.Models.Models;
using StockMarket.Models.ManualMappingUsingExtensionMethods;
using StockMarket.Models.DTO_s.StockDtos;
using StockMarket.Models.DTO_s.CommentDtos;
using StockMarket.Utility.ResourceParameters;


namespace StockMarket.Api.Controllers
{
    [ApiController]
    [Route("api/comment")]
    public class CommentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CommentController> _logger;

        public CommentController(IUnitOfWork unitOfWork
                                            , ILogger<CommentController> logger
                                           )
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Comment>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllComments([FromQuery] StockResourceParameters<Comment> resourceParameters)
        {
            try
            {
                var comments = await _unitOfWork.CommentRepository.GetAllPagedAsync(resourceParameters);
                var mappedComments = comments.Select(c => c.ToCommentDto());

                return Ok(mappedComments);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An Error Occurred While Retreiveing The Comments Info {nameof(GetAllComments)}");
                return StatusCode(500, "Internal Server Error!!");

            }
        }

        [HttpGet("{commentId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> GetCommentById(int? commentId)
        {
            try
            {
                if (commentId == null) return BadRequest("CommentId can't be NUll Value");

                var comment = await _unitOfWork.CommentRepository.GetByIdAsync(c => c.Id == commentId);

                if (comment == null) return NotFound();

                var mappedComment = comment.ToCommentDto();

                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(mappedComment);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while processing GetCommentById.");
                return StatusCode(500, "Internal server error!!");
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> CreateNewComment([FromBody] CreateCommentDto createCommentDto)
        {
            if (!ModelState.IsValid)
            {
                _logger.LogError($"Invalid POST attempt in {nameof(CreateCommentDto)}");
                return BadRequest(ModelState);
            }

            try
            {
                if (createCommentDto == null) return BadRequest(ModelState);

                var commentMap = createCommentDto.ToCommentFromCreation();

                if (commentMap == null)
                {
                    ModelState.AddModelError("", "Mapping failed. Unable to create Comment.");
                    return BadRequest(ModelState);
                }

                await _unitOfWork.CommentRepository.CreateAsync(commentMap);
                await _unitOfWork.SaveAsync();

                return NoContent();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while creating and adding new Comment {nameof(createCommentDto)}.");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{commentId:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateExistingComment([FromRoute] int commentId, [FromBody] UpdateCommentDto updateCommentDto)
        {
            if (updateCommentDto == null) return BadRequest(ModelState);

            if (!ModelState.IsValid || commentId < 1)
            {
                _logger.LogError($"Invalid Put attempt in {nameof(updateCommentDto)}");
                return BadRequest(ModelState);
            }

            try
            {
                var exisitingComment = await _unitOfWork.CommentRepository.GetByIdAsync(c => c.Id == commentId);

                if (exisitingComment == null)
                {
                    return NotFound();
                }

                _unitOfWork.CommentRepository.Update(exisitingComment);
                await _unitOfWork.SaveAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while updating comment with ID {commentId}.");
                return StatusCode(500, "Internal server error");
            }
        }
        [HttpDelete("{commentId:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<IActionResult> DeleteComment(int? commentId)
        {
            if (commentId == null) { return NotFound(); }

            if (!ModelState.IsValid || commentId < 0)
            {
                _logger.LogError($"Invalid Delete attempt in {nameof(DeleteComment)}");
                return BadRequest(ModelState);
            }

            try
            {
                var deletedComment = await _unitOfWork.CommentRepository.GetByIdAsync(q => q.Id == commentId);

                if (deletedComment == null)
                {
                    return NotFound();
                }

                _unitOfWork.CommentRepository.Delete(deletedComment);
                await _unitOfWork.SaveAsync();
                return NoContent();

            }


            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while Deleting existing Comment {nameof(DeleteComment)}.");
                return StatusCode(500, "Internal server error! Please Try again");

            }
        }
    }
}
