using CollectFour;
using System;

namespace CollectFourCore
{
    [Serializable]
    public class Bot
    {
        private Field _field;

        public Bot(Field field)
        {
            _field = field;
        }
        public int RandomNumberForBot()
        {
            int month;
            do
            {
                Random rnd = new Random();
                month = rnd.Next(1, 8);
            } while (_field.GetTokenArray()[0, month - 1].ValueInt != 0);

            return month;
        }

        public void SetField(Field field)
        {
            _field = field;
        }

        public int BotContraPlayerMedium()
        {
            //Vertikalne riesenie -
            for (int a = 0; a < _field.ColumnCount; a++)
            {
                for (int i = 1; i <= (_field.RowCount - 3); i++)
                {
                    if (_field.GetTokenArray()[i, a].ValueInt == 1 && _field.GetTokenArray()[i + 1, a].ValueInt == 1 && _field.GetTokenArray()[i + 2, a].ValueInt == 1 && _field.GetTokenArray()[i - 1, a].ValueInt == 0)
                    {
                        return a + 1;
                    }
                }
            }

            //Horizontalne riesenie |
            for (int a = 0; a < _field.RowCount; a++)
            {
                for (int i = 0; i <= (_field.ColumnCount - 3); i++)
                {
                    if (_field.GetTokenArray()[a, i].ValueInt == 1 && _field.GetTokenArray()[a, i + 1].ValueInt == 1 && _field.GetTokenArray()[a, i + 2].ValueInt == 1)
                    {
                        if (a == 5 && i <= 3)
                        {
                            if (_field.GetTokenArray()[a, i + 3].ValueInt == 0)
                            {
                                return i + 4;
                            }
                            if (i != 0 && _field.GetTokenArray()[a, i - 1].ValueInt == 0)
                            {
                                return i;
                            }
                        }

                        if (a == 5 && i == 4)
                        {
                            if (_field.GetTokenArray()[a, i - 1].ValueInt == 0)
                            {
                                return i;
                            }
                        }
                        if (a != 5 && i <= 3)
                        {
                            if (_field.GetTokenArray()[a, i + 3].ValueInt == 0 && _field.GetTokenArray()[a + 1, i + 3].ValueInt != 0)
                            {
                                return i + 4;
                            }
                            if (i != 0 && _field.GetTokenArray()[a, i - 1].ValueInt == 0 && _field.GetTokenArray()[a + 1, i - 1].ValueInt != 0)
                            {
                                return i;
                            }
                        }
                        if (a != 5 && i == 4)
                        {
                            if (_field.GetTokenArray()[a, i - 1].ValueInt == 0 && _field.GetTokenArray()[a + 1, i - 1].ValueInt != 0)
                            {
                                return i;
                            }
                        }
                    }
                }
            }
            return 10;
        }

        public int BotContraPlayerHard()
        {
            if(BotContraPlayerMedium() != 10)
            {
                return BotContraPlayerMedium();
            }

            //Diagonalne riesenie horny fix /
            for (int a = 3; a < _field.RowCount; a++)
            {
                for (int i = 0; i < (_field.ColumnCount - 3); i++)
                {
                    if (_field.GetTokenArray()[a, i].ValueInt == 1 && _field.GetTokenArray()[a - 1, i + 1].ValueInt == 1 && _field.GetTokenArray()[a - 2, i + 2].ValueInt == 1)    //checkucjem 3 diagonalne
                    {
                        if ((_field.GetTokenArray()[a - 3, i + 3].ValueInt == 0) && (_field.GetTokenArray()[a - 2, i + 3].ValueInt != 0))
                        {
                            return i + 4;
                        }
                    }
                }
            }
            
            //Diagonalne riesenie dolny fix /
            for (int a = 3; a < _field.RowCount - 1; a++)
            {
                for (int i = 1; i < (_field.ColumnCount - 2); i++)
                {
                    if (_field.GetTokenArray()[a, i].ValueInt == 1 && _field.GetTokenArray()[a - 1, i + 1].ValueInt == 1 && _field.GetTokenArray()[a - 2, i + 2].ValueInt == 1)    //checkucjem 3 diagonalne
                    {
                        if ((a == 4) && (_field.GetTokenArray()[a + 1, i - 1].ValueInt == 0))
                        {
                            return i;
                        }
                        if ((a == 3) && (_field.GetTokenArray()[a + 1, i - 1].ValueInt == 0) && ((_field.GetTokenArray()[a + 2, i - 1].ValueInt != 0)))
                        {
                            return i;
                        }
                    }
                }
            }
            
            //Diagonalne riesenie horny fix \
            for (int a = 3; a < _field.RowCount; a++)
            {
                for (int i = 3; i < (_field.ColumnCount); i++)
                {
                    if (_field.GetTokenArray()[a, i].ValueInt == 1 && _field.GetTokenArray()[a - 1, i - 1].ValueInt == 1 && _field.GetTokenArray()[a - 2, i - 2].ValueInt == 1)    //checkucjem 3 diagonalne
                    {
                        if ((_field.GetTokenArray()[a - 3, i - 3].ValueInt == 0) && (_field.GetTokenArray()[a - 2, i - 3].ValueInt != 0))
                        {
                            return i - 2;
                        }
                    }
                }
            }
            //Diagonalne riesenie dolny fix \
            for (int a = 0; a < (_field.RowCount - 3); a++)
            {
                for (int i = 0; i < (_field.ColumnCount - 3); i++)
                {
                    if (_field.GetTokenArray()[a, i].ValueInt == 1 && _field.GetTokenArray()[a + 1, i + 1].ValueInt == 1 && _field.GetTokenArray()[a + 2, i + 2].ValueInt == 1)    //checkucjem 3 diagonalne
                    {
                        if(a == 2 && (_field.GetTokenArray()[a + 3, i + 3].ValueInt == 0))
                        {
                            return i + 4;
                        }
                        if(a != 2 && (_field.GetTokenArray()[a + 3, i + 3].ValueInt == 0) && (_field.GetTokenArray()[a + 4, i + 3].ValueInt != 0))
                        {
                            return i + 4;
                        }
                    }
                }
            }
            return 10;
        }

        public int BotTryWinMedium()
        {
            //Vertikalne riesenie - malo by ist
            for (int a = 0; a < _field.ColumnCount; a++)
            {
                for (int i = 1; i <= (_field.RowCount - 3); i++)
                {

                    if (_field.GetTokenArray()[i, a].ValueInt == 2 && _field.GetTokenArray()[i + 1, a].ValueInt == 2 && _field.GetTokenArray()[i + 2, a].ValueInt == 2 && _field.GetTokenArray()[i - 1, a].ValueInt == 0)
                    {
                        return a + 1;
                    }
                }
            }
            //Horizontalne riesenie - malo by ist
            for (int a = 0; a < _field.RowCount; a++)
            {
                for (int i = 0; i <= (_field.ColumnCount - 3); i++)
                {
                    if (_field.GetTokenArray()[a, i].ValueInt == 2 && _field.GetTokenArray()[a, i + 1].ValueInt == 2 && _field.GetTokenArray()[a, i + 2].ValueInt == 2)
                    {
                        if (a == 5 && i <= 3)
                        {
                            if (_field.GetTokenArray()[a, i + 3].ValueInt == 0)
                            {
                                return i + 4;
                            }
                            if (i != 0 && _field.GetTokenArray()[a, i - 1].ValueInt == 0)
                            {
                                return i;
                            }
                        }
                        if (a == 5 && i == 4)
                        {
                            if (_field.GetTokenArray()[a, i - 1].ValueInt == 0)
                            {
                                return i;
                            }
                        }
                        if (a != 5 && i <= 3)
                        {
                            if (_field.GetTokenArray()[a, i + 3].ValueInt == 0 && _field.GetTokenArray()[a + 1, i + 3].ValueInt != 0)
                            {
                                return i + 4;
                            }
                            if (i != 0 && _field.GetTokenArray()[a, i - 1].ValueInt == 0 && _field.GetTokenArray()[a + 1, i - 1].ValueInt != 0)
                            {
                                return i;
                            }
                        }
                        if (a != 5 && i == 4)
                        {
                            if (_field.GetTokenArray()[a, i - 1].ValueInt == 0 && _field.GetTokenArray()[a + 1, i - 1].ValueInt != 0)
                            {
                                return i;
                            }
                        }
                    }
                }
            }
            return 10;
        }
        public int BotTryWinHard()
        {
            if (BotTryWinMedium()!= 10)
            {
                return BotTryWinMedium();
            }
            //Diagonalne riesenie horny fix /
            for (int a = 3; a < _field.RowCount; a++)
            {
                for (int i = 0; i < (_field.ColumnCount - 3); i++)
                {
                    if (_field.GetTokenArray()[a, i].ValueInt == 2 && _field.GetTokenArray()[a - 1, i + 1].ValueInt == 2 && _field.GetTokenArray()[a - 2, i + 2].ValueInt == 2)    //checkucjem 3 diagonalne
                    {
                        if ((_field.GetTokenArray()[a - 3, i + 3].ValueInt == 0) && (_field.GetTokenArray()[a - 2, i + 3].ValueInt != 0))
                        {
                            return i + 4;
                        }
                    }
                }
            }

            //Diagonalne riesenie dolny fix /
            for (int a = 3; a < _field.RowCount - 1; a++)
            {
                for (int i = 1; i < (_field.ColumnCount - 2); i++)
                {
                    if (_field.GetTokenArray()[a, i].ValueInt == 2 && _field.GetTokenArray()[a - 1, i + 1].ValueInt == 2 && _field.GetTokenArray()[a - 2, i + 2].ValueInt == 2)    //checkucjem 3 diagonalne
                    {
                        if ((a == 4) && (_field.GetTokenArray()[a + 1, i - 1].ValueInt == 0))
                        {
                            return i;
                        }
                        if ((a == 3) && (_field.GetTokenArray()[a + 1, i - 1].ValueInt == 0) && ((_field.GetTokenArray()[a + 2, i - 1].ValueInt != 0)))
                        {
                            return i;
                        }
                    }
                }
            }

            //Diagonalne riesenie horny fix \
            for (int a = 3; a < _field.RowCount; a++)
            {
                for (int i = 3; i < (_field.ColumnCount); i++)
                {
                    if (_field.GetTokenArray()[a, i].ValueInt == 2 && _field.GetTokenArray()[a - 1, i - 1].ValueInt == 2 && _field.GetTokenArray()[a - 2, i - 2].ValueInt == 2)    //checkucjem 3 diagonalne
                    {
                        if ((_field.GetTokenArray()[a - 3, i - 3].ValueInt == 0) && (_field.GetTokenArray()[a - 2, i - 3].ValueInt != 0))
                        {
                            return i - 2;
                        }
                    }
                }
            }
            //Diagonalne riesenie dolny fix \
            for (int a = 0; a < (_field.RowCount - 3); a++)
            {
                for (int i = 0; i < (_field.ColumnCount - 3); i++)
                {
                    if (_field.GetTokenArray()[a, i].ValueInt == 2 && _field.GetTokenArray()[a + 1, i + 1].ValueInt == 2 && _field.GetTokenArray()[a + 2, i + 2].ValueInt == 2)    //checkucjem 3 diagonalne
                    {
                        if (a == 2 && (_field.GetTokenArray()[a + 3, i + 3].ValueInt == 0))
                        {
                            return i + 4;
                        }
                        if (a != 2 && (_field.GetTokenArray()[a + 3, i + 3].ValueInt == 0) && (_field.GetTokenArray()[a + 4, i + 3].ValueInt != 0))
                        {
                            return i + 4;
                        }
                    }
                }
            }
            return 10;
        }
    }
}
