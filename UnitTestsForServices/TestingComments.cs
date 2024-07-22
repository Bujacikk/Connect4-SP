using CollectFourCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace UnitTestsForServices
{
    [TestClass]
    public class TestingComments
    {
        [TestMethod]
        public void CommentAddTestFor1Comment()
        {
            //Tabulka
            CommentsTable commentsTable = new CommentsTable();
            //Komenty
            Comment comment = new Comment("Adrian", "Hra je super");

            //Pridavanie
            commentsTable.CommentAdd(comment);

            //Podmienky
            var WhatShouldBeInTable = 1;
            var WhatIsInTable = commentsTable.GetCommentsTable.Count();

            //Asser
            Assert.AreEqual(WhatShouldBeInTable, WhatIsInTable);
        }
        
        [TestMethod]
        public void CommentAddTestForLotsOfComment()
        {
            //Tabulka
            CommentsTable commentsTable = new CommentsTable();

            //Komenty
            Comment commentAdrian = new Comment("Adrian", "Hra je super");
            Comment commentMatus = new Comment("Matus", "Hra je zla");
            Comment commentAgata = new Comment("Agata", "Velmi ma ta hra bavi");

            //Pridavanie
            commentsTable.CommentAdd(commentAdrian);
            commentsTable.CommentAdd(commentMatus);
            commentsTable.CommentAdd(commentAgata);

            //Podmienky
            var WhatShouldBeInTable = 3;
            var WhatIsInTable = commentsTable.GetCommentsTable.Count();

            //Assert
            Assert.AreEqual(WhatShouldBeInTable, WhatIsInTable);
        }

        [TestMethod]
        public void CommentAddTestForNoComments()
        {
            //Tabulka
            CommentsTable commentsTable = new CommentsTable();

            //Komenty
            //Nepridavam

            //Pridavanie
            //Nepridavam

            //Podmienky
            var WhatShouldBeInTable = 0;
            var WhatIsInTable = commentsTable.GetCommentsTable.Count();

            //Assert
            Assert.AreEqual(WhatShouldBeInTable, WhatIsInTable);
        }
    }
}
