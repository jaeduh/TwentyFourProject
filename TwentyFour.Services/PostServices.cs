using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFourProject.Data;

namespace TwentyFour.Services
{
    public class PostCreate
    {
        private readonly Guid _UserId;

        public PostCreate(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate post)
        {
            var entity =
                new Post()
                {
                    PostId = _userId,
                    Title = post.Title,
                    Text = post.Text
                    
                };


            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

  /*      public IEnumerable<PostItems> GetPost()
        {
            using (var ctx = new ApplicationDbContext))
                {
                var query =
                    ctx

                        .Posts
                        .Where(e => e.UserId == _UserId)
                        .Select(
                        e =>
                        new PostItem
                        {
                            PostId = e.PostId,
                            Title = e.Title
                        }
                        );
                return query.ToArray(); 
            }*/
        }
    }
}
