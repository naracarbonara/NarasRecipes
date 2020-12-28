using Naras_Kitchen.Data;
using Naras_Kitchen.Repositories.Interfaces;
using Naras_Kitchen.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Services
{
    public class CommentService:ICommentService

    {
        private readonly ICommentRepository CommentRepository;
        public CommentService(ICommentRepository CommentRepository)
        {
            this.CommentRepository = CommentRepository;
        }

        public void Add(string commentText, int recipeId, string userId, string userName) 
        {
            var comment = new Comment();
            comment.CommentText = commentText;
            comment.RecipeId = recipeId;
            comment.DateCreated = DateTime.Now;
            comment.UserId = userId;
            comment.UserName = userName;
            CommentRepository.Add(comment);
        }
    }
}
