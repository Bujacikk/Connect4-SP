using CollectFourCore.Komentare;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace CollectFourCore
{
    public class CommentsTable : CommentsInteface
    {
        List<Comment> commentsTable;
        public CommentsTable()
        {
            commentsTable = new List<Comment>();
        }
        public List<Comment> GetCommentsTable
        {
            get
            { return commentsTable; }
        }
        public void Serialize()
        {
            using (StreamWriter file = File.CreateText(@"C:\temp\coments.json"))
            {
                if (file == null) return;
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, commentsTable);
            }
        }

        public void Deserialize()
        {
            using (StreamReader file = File.OpenText(@"C:\temp\coments.json"))
            {
                if (file == null) return;
                JsonSerializer serializer = new JsonSerializer();
                commentsTable = (List<Comment>)serializer.Deserialize(file, typeof(List<Comment>));
            }
        }

        public void PrintCommentsTable()
        {
            Console.WriteLine();
            Deserialize();
            foreach (Comment comment in GetCommentsTable)
            {
                Console.WriteLine(comment.PlayerName + "  ===>  " + comment.Commentary);
                Console.WriteLine();
            }
        }
        public void CommentAdd(Comment comment)
        {
            GetCommentsTable.Add(comment);
        }

        IList<Comment> CommentsInteface.GetCommentsTable()
        {
            throw new NotImplementedException();
        }
    }
}
