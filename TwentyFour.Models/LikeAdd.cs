using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwentyFour.Data;

namespace TwentyFour.Models
{
    class LikeAdd
    {
        public int LikeCount { get; set; }

        public Post Liked { get; set; }
        public User Liker { get; set; }
    }
}
