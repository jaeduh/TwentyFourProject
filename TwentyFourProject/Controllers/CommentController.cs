using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using TwentyFour.Data;
using TwentyFourProject.Data;

namespace TwentyFourProject.Controllers
{
    public class CommentController : ApiController
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        public async Task<IHttpActionResult> PostComment(Comment comment)
        {
            if (comment == null)
                return BadRequest("Request body was empty.");
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            User targetUser = await _context.Users.FindAsync(comment.UserID);
            if (targetUser == null)
                return BadRequest("Invalid User ID");

            Post targetPost = await _context.Post.FindAsync(comment.PostID);
            if (targetPost == null)
                return BadRequest("Invalid Post ID");

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
            return Ok();
        }

        public async Task<IHttpActionResult> GetAllComments()
        {
            return Ok(await _context.Comments.ToListAsync());
        }
    }