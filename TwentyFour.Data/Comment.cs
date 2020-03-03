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
        [Key]
        //int CommentID
        [ForeignKey(nameof(Like))]
        int CommentID { get; set; }


        //string CommentText
        [MinLength(2, ErrorMessage = "Please enter at least two characters.")]
        [MaxLength(1000, ErrorMessage = "There are too many characters in this field.")]
        string CommentText { get; set; }


        //User Author -- FOREIGN KEY FROM User ID
        // INSERT "[ForeignKey(nameof(Comment))] ABOVE User ID
        int AuthorID { get; set; }

        //Post CommentPost -- FOREIGN KEY FROM Post ID
        // INSERT "[ForeignKey(nameof(Comment))] ABOVE Post ID
        int PostID { get; set; }
    }
}
