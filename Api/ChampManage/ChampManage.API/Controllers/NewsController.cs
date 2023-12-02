using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models.NewsModels;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace ChampManage.API.Controllers
{
    /// <summary>
    /// API endpoints for managing news.
    /// </summary>
    [Authorize(Policy = "AdminOnly")]
    [Route("api/news")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;
        private readonly IMapper _mapper;

        public NewsController(INewsRepository newsRepository, IMapper mapper)
        {
            _newsRepository = newsRepository ?? throw new ArgumentNullException(nameof(newsRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        /// <summary>
        /// Gets a list of news.
        /// </summary>
        [AllowAnonymous]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetNews()
        {
            var news = await _newsRepository.GetNewsAsync();
            return Ok(_mapper.Map<IEnumerable<NewsDto>>(news));
        }

        /// <summary>
        /// Gets a news item by its ID.
        /// </summary>
        /// <param name="newsId">The ID of the news item.</param>
        [AllowAnonymous]
        [HttpGet("{newsId}", Name = "GetNewsById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<NewsDto>> GetNewsById(int newsId)
        {
            var news = await _newsRepository.GetNewsByIdAsync(newsId);

            if (news == null)
            {
                return NotFound("News not found.");
            }

            return Ok(_mapper.Map<NewsDto>(news));
        }

        /// <summary>
        /// Creates a new news item.
        /// </summary>
        /// <param name="newsCreateDto">The data for the new news item.</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateNews(NewsDto newsCreateDto)
        {
            if (newsCreateDto == null)
            {
                return BadRequest("Invalid news data.");
            }

            var newsEntity = _mapper.Map<News>(newsCreateDto);

            _newsRepository.AddNews(newsEntity);

            if (!await _newsRepository.SaveChangesAsync())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            var newsToReturn = _mapper.Map<NewsDto>(newsEntity);

            return CreatedAtRoute("GetNewsById", new { newsId = newsToReturn.Id }, newsToReturn);
        }

        /// <summary>
        /// Deletes a news item by its ID.
        /// </summary>
        /// <param name="newsId">The ID of the news item to delete.</param>
        [HttpDelete("{newsId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteNews(int newsId)
        {
            var news = await _newsRepository.GetNewsByIdAsync(newsId);

            if (news == null)
            {
                return NotFound("News not found.");
            }

            _newsRepository.DeleteNews(news);

            if (!await _newsRepository.SaveChangesAsync())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }

            return NoContent();
        }
    }
}
