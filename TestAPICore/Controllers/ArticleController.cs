using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public ArticleController(TestApiCoreContext context)
        {
            _context = context;
        }

        //GET:      api/Article/GetAll
        [HttpGet]
        [Route("GetAll")]
        public ActionResult<IEnumerable<Article>> GetAll()
        {
            return _context.ArticleItems;
        }

        //GET:      api/Article/{id}
        [HttpGet("{id}")]
        [Route("GetById")]
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
        [Route("")]
        public ActionResult<Article> PostArticleItem(Article article)
        {
            _context.ArticleItems.Add(article);
            _context.SaveChanges();

            return CreatedAtAction("GetArticleItem", new Article() { Id = article.Id }, article);
        }
    }
}
