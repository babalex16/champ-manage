using AutoMapper;
using ChampManage.API.Entities;
using ChampManage.API.Models;
using ChampManage.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChampManage.API.Controllers
{
    [Authorize(Policy = "AdminOnly")]
    [Route("api/news")]
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

        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetNews()
        {
            var news = await _newsRepository.GetNewsAsync();
            return Ok(_mapper.Map<IEnumerable<NewsDto>>(news));
        }

        [AllowAnonymous]
        [HttpGet("{newsId}", Name = "GetNewsById")]
        public async Task<ActionResult<NewsDto>> GetNewsById(int newsId)
        {
            var news = await _newsRepository.GetNewsByIdAsync(newsId);

            if (news == null)
            {
                return NotFound("News not found.");
            }

            return Ok(_mapper.Map<NewsDto>(news));
        }

        [HttpPost]
        public async Task<ActionResult<NewsDto>> CreateNews(NewsDto newsCreateDto)
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

        [HttpDelete("{newsId}")]
        public async Task<ActionResult> DeleteNews(int newsId)
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
