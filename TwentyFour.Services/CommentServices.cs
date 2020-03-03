using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFourProject.Data;
using TwentyFourProject.Models;

namespace TwentyFour.Services
{
    public class CommentServices
    {
        public bool CreateComment(CommentCreate model)        
        {
            var entity = new Comment()
            {
                
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
