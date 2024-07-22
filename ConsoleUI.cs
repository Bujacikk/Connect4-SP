using CollectFourCore;
using CollectFourCore.Komentare;
using CollectFourCore.Ratovanie;
using CollectFourCore.Score;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectFour
{

    public class ConsoleUI
    {
        Player player1, player2;
        String name1, name2;
        public CommentsInteface commentsTable;
        public RateInterface rating;
        //var scoreboard = new Scoreboard();
        public ScoreInterface Scoreboard;
        private readonly Field _field;
        List<string> menuItems;

        public ConsoleUI(Field field)
        {
            _field = field;
            Scoreboard = new ScoreboardTD();
            commentsTable = new ComentsTableTD();
            rating = new RatingTD();

            menuItems = new List<string>()
                {
                    "Play(P)",
                    "Score(S)",
                    "Komentáre(K)",
                    "Hodnotenie(H)",
                    "Exit(E)"
                };
        }

       

        public void Menu()
        {
            string title = @"
    _________                                     __    ___________                  
    \_   ___ \  ____   ____   ____   ____   _____/  |_  \_   _____/___  __ _________ 
    /    \  \/ /  _ \ /    \ /    \_/ __ \_/ ___\   __\  |    __)/  _ \|  |  \_  __ \
    \     \___(  <_> )   |  \   |  \  ___/\  \___|  |    |     \(  <_> )  |  /|  | \/
     \______  /\____/|___|  /___|  /\___  >\___  >__|    \___  / \____/|____/ |__|   
            \/            \/     \/     \/     \/            \/                     ";


            Console.WriteLine(title);
            Console.WriteLine();
            Console.WriteLine(menuItems[0] + "      " + menuItems[1] + "     " + menuItems[2] + "     " + menuItems[3] + "     " + menuItems[4]);
        }

        public void Run()
        {
            _field.GenerateField();
            _field.PrintField();
            while (true)
            {
                PlayerMove(player1, 1);
                PlayerMove(player2, 2); 
            }
        }
        
        public int ProcessInput()
        {
            int znak = Console.ReadKey().KeyChar;
            if (znak >= 49 && znak <= 55)
            {
                znak = znak - 48;
                return znak;
            }
            else
            {
                while (znak < 49 || znak > 55)
                {
                    Console.WriteLine();
                    Console.Write("Zadal si nespravny znak, opakuj volbu: ");
                    znak = Console.ReadKey().KeyChar;
                    if (znak >= 49 && znak <= 55)
                    {
                        znak = znak - 48;
                        return znak;
                    }
                }

            }
            return znak;
        }
        public void ChosePlayers(int playercount, int mode)
        {
            if(playercount == 2 &&  mode == 0)
            {
                Console.Clear();
                Console.Write("Zadaj meno hrača č.1 : ");
                name1 = Console.ReadLine();
                player1 = new Player(name1);

                Console.Clear();
                Console.Write("Zadaj meno hrača č.2 : ");
                name2 = Console.ReadLine();
                player2 = new Player(name2);

                Run();
            }
            if(playercount == 1)
            {
                Console.Clear();
                Console.Write("Zadaj meno hrača: ");
                name1 = Console.ReadLine();
                player1 = new Player(name1);

                Bot bot = new Bot(_field, Scoreboard);
                if(mode == 1)
                {
                    BotRun(bot,1);
                }
                if (mode == 2)
                {
                    BotRun(bot, 2);
                }
            }
            
        }
       
        public void ScoreMinus(Player player)
        {
            int score = player.Score;
            score = score - 50;
            player.Score = score;
        }

        public void ReadingUserInput()
        {
            int znak = Console.ReadKey().KeyChar;

            do
            {
                if (znak == 112 || znak == 101 || znak == 115 || znak == 107 || znak == 104)
                {
                    switch (znak)
                    {
                        case 'p':
                            ChoseGameMode();
                            break;
                        case 's':
                            Console.Clear();
                            Menu();
                            Scoreboard.PrintScoreboard();
                            break;
                        case 'k':
                            Console.Clear();
                            commentsTable.PrintCommentsTable();
                            CommentsSwitch();
                            break;
                        case 'h':                           //HODNOTENIE
                            Console.Clear();
                            rating.PrintRating();
                            RatesSwitch();
                            break;
                        case 'e':
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                znak = Console.ReadKey().KeyChar;
            }
            while (true);
        }
        public void CommentsSwitch()
        {
            Console.WriteLine();
            Console.WriteLine("Back(b)" + "   " + "Napis komentar(p)" + "   " + "Exit(e)");
            int znak = Console.ReadKey().KeyChar; 
            do
            {
                if (znak == 107 || znak == 112 || znak == 98 || znak == 101)
                {
                    switch (znak)
                    {
                        case 'b':
                            Console.Clear();
                            Menu();
                            ReadingUserInput();
                            break;
                        case 'p':
                            Console.Clear();
                            Console.Write("Zadaj svoje meno: ");
                            string playername = Console.ReadLine();
                            Console.Write("Komentar: ");
                            string comment = Console.ReadLine();
                            Comment commentOfPlayer = new Comment { PlayerName = playername, Commentary = comment};
                            commentsTable.CommentAdd(commentOfPlayer);
                         // commentsTable.Serialize();
                            Menu();
                            ReadingUserInput();
                            break;
                        case 'e':
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                znak = Console.ReadKey().KeyChar;
            }
            while (true);
        }
        public void RatesSwitch()
        {
            Console.WriteLine();
            Console.WriteLine("Back(b)" + "   " + "Zadaj hodnotenie(p)" + "   " + "Exit(e)");
            int znak = Console.ReadKey().KeyChar;
            do
            {
                if (znak == 107 || znak == 112 || znak == 98 || znak == 101)       //Nemam upravenu ascii
                {
                    switch (znak)
                    {
                        case 'b':
                            Console.Clear();
                            Menu();
                            ReadingUserInput();
                            break;
                        case 'p':
                            Console.Clear();
                            Console.Write("Zadaj svoje meno: ");
                            string playername = Console.ReadLine();
                            Console.Write("Hodnotenie: ");

                            znak = Console.ReadKey().KeyChar;
                            do
                            {
                                if (znak >= 48 && znak <= 53)
                                {
                                    znak = znak - 48;
                                    Rate rate = new Rate{ PlayerName = playername, Rating = znak };
                                    rating.RattingAdd(rate);
                                  //  commentsTable.Serialize();
                                    break;
                                    /*
                                    Menu();
                                    ReadingUserInput();
                                    */
                                }
                                Console.Clear();
                                Console.Write("Zadaj svoje meno: ");
                                Console.Write(playername);
                                Console.Write("Hodnotenie: ");
                                znak = Console.ReadKey().KeyChar;
                            }
                            while (true);

                            Menu();
                            ReadingUserInput();
                            break;
                        case 'e':
                            Environment.Exit(0);
                            break;
                        default:
                            break;
                    }
                }
                znak = Console.ReadKey().KeyChar;
            }
            while (true);
        }
        public void GameMod()
        {
            int znak = Console.ReadKey().KeyChar;
            do
            {
                if (znak == 109 || znak == 98)
                {
                    switch (znak)
                    {
                        case 'm':
                            ChosePlayers(2,0);  //lvl no bot
                            break;
                        case 'b':
                            LevelOfBot();
                            break;
                        default:
                            break;
                    }
                }
                znak = Console.ReadKey().KeyChar;
            }
            while (true);
        }
        public void LevelOfBot()
        {
            Console.Clear();
            Console.WriteLine("Akú chceš náročnosť: ");
            Console.WriteLine("Easy(e)" + "   " + "Medium(m)");

            int znak = Console.ReadKey().KeyChar;
            do
            {
                if (znak == 109 || znak == 101)
                {
                    switch (znak)
                    {
                        case 'e':
                            ChosePlayers(1,1);  //lvl 1
                            break;
                        case 'm':
                            ChosePlayers(1,2); //lvl 2
                            break;
                        default:
                            break;
                    }
                }
                znak = Console.ReadKey().KeyChar;
            }
            while (true);
        }

        public void ChoseGameMode()
        {
            Console.Clear();
            Console.WriteLine("Aký mód chceš hrať?: ");
            Console.WriteLine("Player vs Player(m)" + "      " + "Player vs Bot(b)");
            GameMod();
        }

        private void BotRun(Bot bot, int mod)
        {
                        
            _field.GenerateField();
            _field.PrintField();
            while (true)
            {
                PlayerMove(player1, 1);

                //------------------------------------------------------------------------------------
                int columnInt2 = 0;
                if (mod == 2)
                {
                    if (bot.BotTryWin() != 10)
                    {
                        columnInt2 = bot.BotTryWin();
                    }
                    else
                    {
                        if (bot.BotContraPlayer() == 10)
                        {
                            columnInt2 = bot.RandomNumberForBot();
                        }
                        else
                        {
                            columnInt2 = bot.BotContraPlayer();
                        }
                    }
                }
                if (mod == 1)
                {
                    columnInt2 = bot.RandomNumberForBot();
                }
                int g = _field.SetToken(columnInt2, 2);
                while (g == 1)
                {
                    Console.WriteLine(name2 + "stlpec je plny: ");
                    columnInt2 = bot.RandomNumberForBot();
                    g = _field.SetToken(columnInt2, 2);
                }
                _field.PrintField();

                if (_field.IsFinnished() == true)
                {
                    Console.WriteLine("Vyhral hrac BOT");
                    Menu();
                    ReadingUserInput();
                    return;
                }
            }
        }
        private void PlayerMove(Player player, int num)
        {
            Console.Write("Na tahu je " + player.Name + " , vyber si stlpec: ");
            int columnInt = ProcessInput();
            while (columnInt < 0 || columnInt > 8)
            {
                Console.Write("Cislo stlpca mimo hranice, zadaj nove: ");
                columnInt = ProcessInput();
            }
            int h = _field.SetToken(columnInt, num);
            while (h == 1)
            {
                Console.WriteLine(player.Name + " stlpec je plny: ");
                columnInt = ProcessInput();
                h = _field.SetToken(columnInt, num);
            }
            _field.PrintField();
            ScoreMinus(player);

            if (_field.IsFinnished() == true)
            {
                Console.WriteLine("Vyhral hrac " + player.Name + "!!!! s " + player.Score + "bodami");
                Scoreboard.PlayerAdd(player);
              //  Scoreboard.Serialize();
                Menu();
                ReadingUserInput();
                return;
            }
        }
            
    }
}
