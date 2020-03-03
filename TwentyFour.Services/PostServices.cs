using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFourProject.Data;

namespace TwentyFour.Services
{
    public class PostServices
    {
        private readonly Guid _UserId;

        public PostServices(Guid userId)
        {
            _UserId = userId;
        }

        public bool CreatePost(PostServices post)
        {
            var entity =
                new Post()
                {
                    UserId = _CustomerId,
                    Title = post.Title,
                    Text = post.Text
                };


            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostItem> GetPost()
        {
            using (var ctx = new ApplicationDbContext))
                {
                var query =
                    ctx

                        .Posts
                        .Where(e => e.CustomerId == _CustomerId)
                        .Select(
                        e =>
                        new PostItem
                        {
                            PostId = e.PostId,
                            Title = e.Title
                        }
                        );
                return query.ToArray();
            }
        }
    }
}
