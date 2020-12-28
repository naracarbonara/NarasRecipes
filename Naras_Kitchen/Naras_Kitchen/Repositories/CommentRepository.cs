using Naras_Kitchen.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Naras_Kitchen.Repositories.Interfaces
{
    public class CommentRepository:ICommentRepository
    {
        private readonly RecipeDbContext Context;
        public CommentRepository(RecipeDbContext Context)
        {
            this.Context = Context;       
        }
        public void Add(Comment comment)
        {
            Context.Comments.Add(comment);
            Context.SaveChanges();
        }
    }
}
