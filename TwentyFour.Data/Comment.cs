using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFourProject.Data;

namespace TwentyFour.Data
{
    public class Comment
    {
        [Required]
        //int CommentID
        [ForeignKey(nameof(Like))]
        int CommentID { get; set; }
        //string CommentText
        [MinLength(2, ErrorMessage = "Please enter at least two characters.")]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]

        string Text { get; set; }

        //User Author -- FOREIGN KEY FROM User ID
        // INSERT "[ForeignKey(nameof(Comment))] ABOVE User ID
        int AuthorID { get; set; }

        //Post CommentPost -- FOREIGN KEY FROM Post ID
        // INSERT "[ForeignKey(nameof(Comment))] ABOVE Post ID
        int PostID { get; set; }
    }

    //Controller -- Unsure where to put this because of current file tree/naming convention.
    public class CommentController
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
}
