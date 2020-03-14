using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestAPICore.Models;

namespace TestAPICore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly TestApiCoreContext _context;
        private readonly IMapper _mapper;
        public ArticleController(TestApiCoreContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        //GET:      api/Article/GetAll
        [HttpGet]
        //[Authorize]
        [Route("GetAll")]
        public ActionResult<IEnumerable<Article>> GetAll()
        {
            var result = _context.ArticleItems;
            if (result == null)
            {
                return NoContent();
            }
            return _context.ArticleItems;
        }

        //GET:      api/Article/{id}
        [HttpGet("{id}")]
        //[Authorize]
        [Route("{id:int}")]
        public ActionResult<Article> GetArticleItem(int id)
        {
            var commandItem = _context.ArticleItems.Find(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return commandItem;
        }

        //POST:     api/Article/
        [HttpPost]
        //[Authorize]
        [Route("")]
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
