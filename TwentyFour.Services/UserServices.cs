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
    public class UserServices
    {
        private readonly Guid _userId;

        public UserServices(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateUser(UserCreate model)
        {
            var entity = new User()
            {
                OwnerId = _userId,
                Name = model.Name,
                Email = model.Email

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.User.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        /*public bool UpdateUser(UserEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Users
                    .Single(e => e.UserId == model.UserId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Email = model.Email;

                return ctx.SaveChanges() == 1;
            }
        }*/
    }
}
