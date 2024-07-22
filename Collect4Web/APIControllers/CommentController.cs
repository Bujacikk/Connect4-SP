using CollectFourCore;
using CollectFourCore.Komentare;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Collect4Web.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private CommentsInteface commentService = new ComentsTableTD();

        // GET: api/Rate
        [HttpGet]
        public IEnumerable<Comment> GetScores()
        {
            return commentService.GetCommentsTable();
        }

        // POST: api/Rate
        [HttpPost]
        public void Post([FromBody] Comment comment)
        {
            commentService.CommentAdd(comment);
        }
    }
}
