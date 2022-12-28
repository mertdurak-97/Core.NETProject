using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;
        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void AddComment(Comment comment)
        {

            _commentDal.Insert(comment);
        }

        public void DeleteComment(Comment comment)
        {
            _commentDal.Delete(comment);
        }

        public Comment GetCommentId(int id)
        {
            return _commentDal.GetById(id);
        }

        public List<Comment> GetCommentListWithBlog()
        {
            return _commentDal.GetListWithBlog();
        }

        public List<Comment> ListAllComment(int id)
        {
            return _commentDal.GetListAll(x => x.BlogID == id);
        }

        public void UpdateComment(Comment comment)
        {
            _commentDal.Update(comment);
        }
    }
}
