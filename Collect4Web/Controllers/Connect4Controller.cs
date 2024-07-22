using Collect4Web.Models;
using CollectFour;
using CollectFourCore;
using CollectFourCore.Komentare;
using CollectFourCore.Ratovanie;
using CollectFourCore.Score;
using Connect4Web;
using Microsoft.AspNetCore.Mvc;

namespace Collect4Web.Controllers
{
    public class Connect4Controller : Controller
    {
        private const string FieldSessionKey = "field";
        private const string Player1SessionKey = "player1";
        private const string Player2SessionKey = "player2";
        private const string SwitchingSessionKey = "switch";
        private const string CheckForEndGameKey = "CheckForEndGame";
        private const string DifficultyKey = "Difficulty";
        private const string BotKey = "bot";

        private ScoreInterface score = new ScoreboardTD();
        private CommentsInteface comments = new ComentsTableTD();
        private RateInterface rate = new RatingTD();

        public IActionResult Index() //-------------------------------------------------------------------------------------------------------------------
        {
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            bool Switching = false;
            bool CheckForEndGame = true;
            var MyText = " ";
            HttpContext.Session.SetObject(FieldSessionKey, field);
            HttpContext.Session.SetObject(SwitchingSessionKey, Switching);
            HttpContext.Session.SetObject(CheckForEndGameKey, CheckForEndGame);
            HttpContext.Session.SetObject(FieldSessionKey, field);

            return View("Index", CreateModel(MyText));
        }

        public IActionResult Move(int token) //-------------------------------------------------------------------------------------------------------------------
        {
           // TransportModel model = new TransportModel();
            var MyText = " ";
            var CheckForEndGame = (bool)HttpContext.Session.GetObject(CheckForEndGameKey);
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);

           // var difficulty = (string)HttpContext.Session.GetObject(DifficultyKey);

            if (CheckForEndGame == false)       //Koniec hry
            {
                HttpContext.Session.SetObject(FieldSessionKey, field);
                HttpContext.Session.SetObject(CheckForEndGameKey, CheckForEndGame);
                return View("Index", CreateModel(MyText));
            }
            var Switching = (bool)HttpContext.Session.GetObject(SwitchingSessionKey);
            
            if (Switching == false)             //tah 1. hrača
            {
                var player1 = (Player)HttpContext.Session.GetObject(Player1SessionKey);
                field.PlayerMove(player1, token, 1);
                var finis = field.IsFinnished();
                if(finis == 1)  //Vyhra
                {
                    MyText = "Vyhral hrac " + player1.Name;
                    score.PlayerAdd(player1);
                    CheckForEndGame = false;
                }
                else if(finis == 2) //Remiza
                {
                    MyText = "Remiza";
                    CheckForEndGame = false;
                }
                HttpContext.Session.SetObject(Player1SessionKey, player1);
                Switching = true;
            }
            else                                //tah 1. hrača
            {
                var player2 = (Player)HttpContext.Session.GetObject(Player2SessionKey);
                field.PlayerMove(player2, token, 2);
                var finis = field.IsFinnished();
                if (finis == 1)  //Vyhra
                {
                    MyText = "Vyhral hrac " + player2.Name;
                    score.PlayerAdd(player2);
                    CheckForEndGame = false;
                }
                else if (finis == 2) //Remiza
                {
                    MyText = "Remiza";
                    CheckForEndGame = false;
                }
                HttpContext.Session.SetObject(Player2SessionKey, player2);
                Switching = false;
            }
            HttpContext.Session.SetObject(CheckForEndGameKey, CheckForEndGame);
            HttpContext.Session.SetObject(FieldSessionKey, field);
            HttpContext.Session.SetObject(SwitchingSessionKey, Switching);

            return View("Index",CreateModel(MyText)); 
        }
        public IActionResult SaveComment(string Meno, string Komentar) //-------------------------------------------------------------------------------------------------------------------
        {
            Comment komentar = new Comment(Meno, Komentar);
            comments.CommentAdd(komentar);

            return View("Index", CreateModel(" "));
        }
        public IActionResult SaveRate(string Meno, int Rate) //-------------------------------------------------------------------------------------------------------------------
        {
            Rate hodnotenie = new Rate(Meno, Rate);
            rate.RattingAdd(hodnotenie);

            return View("Index", CreateModel(" "));
        }
        public IActionResult AddPlayersMultiplayer(string playerName1, string playerName2) //-------------------------------------------------------------------------------------------------------------------
        {
            var player1 = new Player(playerName1);
            var player2 = new Player(playerName2);
            var difficulty = 0;
            HttpContext.Session.SetObject(Player1SessionKey, player1);
            HttpContext.Session.SetObject(Player2SessionKey, player2);
            HttpContext.Session.SetObject(DifficultyKey, difficulty);
            var field = new Field(6, 7);
            bool Switching = false;
            bool CheckForEndGame = true;
            HttpContext.Session.SetObject(FieldSessionKey, field);
            HttpContext.Session.SetObject(SwitchingSessionKey, Switching);
            HttpContext.Session.SetObject(CheckForEndGameKey, CheckForEndGame);

            return View("Index", CreateModel(" "));
        }
        public IActionResult AddPlayerBot(string playerName1, int difficulty) //-------------------------------------------------------------------------------------------------------------------
        {
            if (difficulty < 0 || difficulty > 3)       //Koniec hry
            {
               var MyText = " ";
               return View("Index", CreateModel(MyText));
            }
            var player1 = new Player(playerName1);
            HttpContext.Session.SetObject(Player1SessionKey, player1);
            HttpContext.Session.SetObject(DifficultyKey, difficulty);

            var field = new Field(6, 7);
            var bot = new Bot(field);
            HttpContext.Session.SetObject(BotKey, bot);
            bool Switching = false;
            bool CheckForEndGame = true;
            
            HttpContext.Session.SetObject(FieldSessionKey, field);
            HttpContext.Session.SetObject(SwitchingSessionKey, Switching);
            HttpContext.Session.SetObject(CheckForEndGameKey, CheckForEndGame);

            return View("Index", CreateModel(" "));
        }
        public IActionResult BotGame(int token) //-------------------------------------------------------------------------------------------------------------------------------------------------
        {
            var MyText = " ";
            var CheckForEndGame = (bool)HttpContext.Session.GetObject(CheckForEndGameKey);
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            

            if (CheckForEndGame == false)       //Koniec hry 
            {
                HttpContext.Session.SetObject(FieldSessionKey, field);
                HttpContext.Session.SetObject(CheckForEndGameKey, CheckForEndGame);
                MyText = "HRA UKONCENA";
                return View("Index", CreateModel(MyText));
            }
           
                var player1 = (Player)HttpContext.Session.GetObject(Player1SessionKey);     //Tah hraca
                field.PlayerMove(player1, token, 1);
                var finis = field.IsFinnished();
                if (finis == 1)  //Vyhra
                {
                    MyText = "Vyhral hrac " + player1.Name;
                    score.PlayerAdd(player1);
                    CheckForEndGame = false;
                    HttpContext.Session.SetObject(FieldSessionKey, field);
                    HttpContext.Session.SetObject(CheckForEndGameKey, CheckForEndGame);
                    HttpContext.Session.SetObject(Player1SessionKey, player1);
                    return View("Index", CreateModel(MyText));
            }
                else if (finis == 2) //Remiza
                {
                    MyText = "Remiza";
                    CheckForEndGame = false;
                    HttpContext.Session.SetObject(FieldSessionKey, field);
                    HttpContext.Session.SetObject(CheckForEndGameKey, CheckForEndGame);
                    HttpContext.Session.SetObject(Player1SessionKey, player1);
                    return View("Index", CreateModel(MyText));
                }
        
            HttpContext.Session.SetObject(FieldSessionKey, field);
            HttpContext.Session.SetObject(CheckForEndGameKey, CheckForEndGame);
            HttpContext.Session.SetObject(Player1SessionKey, player1);

            MyText = BotMove();
           
            return View("Index", CreateModel(MyText));
        }
            private TransportModel CreateModel(string text) //-------------------------------------------------------------------------------------------------------------------
        {
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            var diff = (int)HttpContext.Session.GetObject(DifficultyKey);
            TransportModel model = new TransportModel();
            var rateNumber = rate.CountRating();

            if(diff == 0)
            {
                var player1 = (Player)HttpContext.Session.GetObject(Player1SessionKey);
                var player2 = (Player)HttpContext.Session.GetObject(Player2SessionKey);
                model.player1 = player1;
                model.player2 = player2;
                HttpContext.Session.SetObject(Player1SessionKey, player1);
                HttpContext.Session.SetObject(Player1SessionKey, player2);
            }
            if (diff != 0)
            {
                var player1 = (Player)HttpContext.Session.GetObject(Player1SessionKey);
                model.player1 = player1;
                HttpContext.Session.SetObject(Player1SessionKey, player1);
            }
            model.Diff = diff;
            model.MyText = text;
            model.MyField = field;
            model.Score = score.GetTopScores();
            model.Comments = comments.GetCommentsTable();
            model.Rate = rateNumber;

            HttpContext.Session.SetObject(FieldSessionKey, field);
            HttpContext.Session.SetObject(DifficultyKey, diff);
            return model;
        }

        public string BotMove() //-------------------------------------------------------------------------------------------------------------------
        {
            var MyText = " ";
            var field = (Field)HttpContext.Session.GetObject(FieldSessionKey);
            var CheckForEndGame = (bool)HttpContext.Session.GetObject(CheckForEndGameKey);

            if (CheckForEndGame == false)       //Koniec hry 
            {
                HttpContext.Session.SetObject(FieldSessionKey, field);
                HttpContext.Session.SetObject(CheckForEndGameKey, CheckForEndGame);
                MyText = "HRA UKONCENA";
                return MyText;
            }

            var bot = (Bot)HttpContext.Session.GetObject(BotKey);
            var difficulty = (int)HttpContext.Session.GetObject(DifficultyKey);

            int columnInt2;  //tah bota
            bot.SetField(field);
            if (difficulty == 1)
            {
                columnInt2 = bot.RandomNumberForBot();
                field.SetToken(columnInt2, 2);
            }
            if (difficulty == 2)
            {
                if (bot.BotTryWinMedium() != 10)
                {
                    columnInt2 = bot.BotTryWinMedium();
                }
                else
                {
                    if (bot.BotContraPlayerMedium() == 10)
                    {
                        columnInt2 = bot.RandomNumberForBot();
                    }
                    else
                    {
                        columnInt2 = bot.BotContraPlayerMedium();
                    }
                }
                field.SetToken(columnInt2, 2);
            }
            if (difficulty == 3)
            {
                if (bot.BotTryWinHard() != 10)
                {
                    columnInt2 = bot.BotTryWinHard();
                }
                else
                {
                    if (bot.BotContraPlayerHard() == 10)
                    {

                        columnInt2 = bot.RandomNumberForBot();
                    }
                    else
                    {
                        columnInt2 = bot.BotContraPlayerHard();
                    }
                }
                field.SetToken(columnInt2, 2);
            }

            var finis = field.IsFinnished();
            if (finis == 1)  //Vyhra
            {
                MyText = "Vyhral BOT";
                CheckForEndGame = false;
            }
            else if (finis == 2) //Remiza
            {
                MyText = "Remiza";
                CheckForEndGame = false;
            }
            HttpContext.Session.SetObject(BotKey, bot);
            HttpContext.Session.SetObject(DifficultyKey, difficulty);
            HttpContext.Session.SetObject(FieldSessionKey, field);
            HttpContext.Session.SetObject(CheckForEndGameKey, CheckForEndGame);
            return MyText;
        }

    }
}
