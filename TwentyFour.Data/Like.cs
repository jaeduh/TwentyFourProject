﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwentyFour.Data
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public int LikeCount { get; set; }

        public Post Liked { get; set; }
        public User Liker { get; set; }
    }
}
