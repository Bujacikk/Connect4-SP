using CollectFourCore.ServicesClasses;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace CollectFourCore.Komentare
{
    public class ComentsTableTD : CommentsInteface
    {
        public void CommentAdd(Comment comment)
        {
            using (var context = new CollectFourContext())
            {
                context.Comments.Add(comment);
                context.SaveChanges();
            }
        }

        public IList<Comment> GetCommentsTable()
        {
            using (var context = new CollectFourContext())
            {
                return (from s in context.Comments orderby s.PlayerName descending select s).Take(100).ToList();
            }
        }

        public void PrintCommentsTable()
        {
            Console.WriteLine();
            foreach (Comment comment in GetCommentsTable())
            {
                Console.WriteLine(comment.PlayerName + "  ===>  " + comment.Commentary);
                Console.WriteLine();
            }
        }

       
    }
}
