using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TestAPICore.Models;

namespace TestAPICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly TestApiCoreContext _context;
        //private readonly IMapper _mapper;
        public ArticleController(TestApiCoreContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            //_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //GET:      api/Article/GetAll
        [HttpGet]
        //[Authorize]
        public ActionResult<IEnumerable<Article>> GetAll()
        {
            var result = _context.ArticleItems
                .Include(a => a.Author)
                .ToList();
            if (!result.Any())
            {
                return NoContent();
            }
            return result;
        }

        //GET:      api/Article/{id}
        [HttpGet("{id}")]
        //[Authorize]
        public ActionResult<Article> GetArticleItem(int id)
        {
            var commandItem = _context.ArticleItems
                .Include(a => a.Author)
                .SingleOrDefault(x => x.Id == id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return commandItem;
        }

        //POST:     api/Article/
        [HttpPost]
        //[Authorize]
        public ActionResult<Article> PostArticleItem(Article article)
        {
            if (article == null)
            {
                return BadRequest();
            }
            _context.ArticleItems.Add(article);
            _context.SaveChanges();

            return CreatedAtAction("GetArticleItem", new Article() { Id = article.Id }, article);
        }
    }
}
