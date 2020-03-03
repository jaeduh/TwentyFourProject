using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Services
{
    public class LikeServices
    {
        public bool AddLike(LikeModel model)
        {
            var like = new Like()
            {
                Liker = model.Liker,
                Liked = model.Liked,
            };
            using (var context = new ApplicationDbContext())
            {
                context.Like.Add(like);
                return context.SaveChanges() == 1;
            }

        }

    }
}
