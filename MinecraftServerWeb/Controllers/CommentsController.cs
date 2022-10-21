using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MinecraftServerWeb.Models;
using MinecraftServerWeb.Repository.Interfaces;
using MinecraftServerWeb.Utility;

namespace MinecraftServerWeb.Controllers
{ 
    [Authorize(Roles= SD.RoleOwner + ", " + SD.RoleAdmin + ", " + SD.RoleUser + SD.RoleMod)] 
    public class CommentsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CommentsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        // POST: Comments/AddComment/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComment(int postId, string content)
        {
            if (content == "")
            {
                return BadRequest("no content do comment");
            }
            if (null == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                return Unauthorized();
            }

            if (null == _unitOfWork.Post.GetFirstOrDefault(e => e.PostId == postId))
            {
                return BadRequest("Wrong post Id");
            }
            Comment comment = new()
            {
                AuthorId = User.FindFirstValue(ClaimTypes.NameIdentifier),
                Content = content,
                PostId = postId
            };
            _unitOfWork.Comment.Add(comment);
            _unitOfWork.Commit();
            return new AcceptedResult();
        }

        // DELETE: Comments/DeleteComment/5/6
        [Route("Comments/DeleteComment/{postId}/{commentId}")]
        [ValidateAntiForgeryToken]
        [HttpDelete]
        public ActionResult DeleteComment(int postId, int commentId)
        {
            Comment comment = _unitOfWork.Comment.GetFirstOrDefault(e => e.PostId == postId && e.CommentId == commentId);
            if (comment == null)
            {
                return BadRequest();
            }

            if (!User.IsInRole(SD.RoleAdmin) && !User.IsInRole(SD.RoleAdmin) &&
                User.FindFirstValue(ClaimTypes.NameIdentifier) != comment.AuthorId)
            {
                return Forbid();
            }
            _unitOfWork.Comment.Remove(comment);
            _unitOfWork.Commit();
            return new AcceptedResult();
        }
    }
}
