using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;
using TwentyFour.Models;
using TwentyFourProject.Data;

namespace TwentyFour.Services
{
    public class PostServices
    {

        public bool CreatePost(PostCreate post)
        {
            var entity =
                new Post()
                {
                    Title = post.Title,
                    Text = post.Text
                };


            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public object GetPostById(int id)
        {
            throw new NotImplementedException();
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

