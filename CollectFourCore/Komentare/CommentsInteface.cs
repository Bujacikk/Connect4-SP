using System;
using System.Collections.Generic;
using System.Text;

namespace CollectFourCore.Komentare
{
    public interface CommentsInteface
    {
        void PrintCommentsTable();
        void CommentAdd(Comment comment);
        public IList<Comment> GetCommentsTable();
    }
}
