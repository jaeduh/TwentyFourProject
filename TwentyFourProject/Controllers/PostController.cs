using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TwentyFour.Models;
using TwentyFour.Services;

namespace TwentyFourProject.Controllers
{
    [Authorize]
    public class PostController : ApiController
    {
  /*      public IHttpActionResult Get()
        {
            PostServices postServices = CreatePostService();
            var posts = postServices.GetPosts();
            return Ok(posts);
        } */
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreatePostService();

            if (!service.CreatePost(post))
                return InternalServerError();

            return Ok();
        }
        private PostServices CreatePostService()
        {
            var noteService = new PostServices();
            return noteService;
        } 

        public IHttpActionResult Get(int id)
        {
            PostServices noteService = CreatePostService();
            var note = noteService.GetPostById(id);
            return Ok(note);
        }

        /*      public IHttpActionResult Put(NoteEdit note)
              {
                  if (!ModelState.IsValid)
                      return BadRequest(ModelState);

                  var service = CreateNoteService();

                  if (!service.UpdateNote(note))
                      return InternalServerError();

                  return Ok();
              }

              public IHttpActionResult Delete(int id)
              {
                  var service = CreateNoteService();

                  if (!service.DeleteNote(id))
                      return InternalServerError();

                  return Ok();
              } */
    }
}
