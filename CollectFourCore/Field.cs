using System;

namespace CollectFour
{
    [Serializable]
    public class Field
    {
        private Token[,] _tokens;

        public Field(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            _tokens = new Token[rowCount, columnCount];
            GenerateField();
        }

        public void GenerateField()
        {
            for (var row = 0; row < RowCount; row++)
            {
                for (var column = 0; column < ColumnCount; column++)
                {
                    _tokens[row, column] = new Token(0);
                }
            }
        }
        public Token[,] GetTokenArray()
        {
            return _tokens;
        }
        public Token GetToken(int row, int column)
        {
            return _tokens[row, column];
        }

        public int SetToken(int column, int value)
        {
            for (int a = RowCount - 1; a >= 0; a--)
            {
                if(GetToken(a,column-1).ValueInt == 0)
                {
                    _tokens[a, column-1] = new Token(value);
                    return 0;
                }
            }
            return 1;
        }

        public int RowCount
        {
            get;
        }
        public int ColumnCount
        {
            get;
        }
        
        public int IsFinnished()
        {
            int remiza = 42;
            //Vertikalne riesenie - malo by ist
            for (int a = 0; a < ColumnCount; a++)
            {
                for(int i = 0; i < (RowCount - 3); i++)
                {
                    if(_tokens[i, a].ValueInt == 1 && _tokens[i + 1, a].ValueInt == 1 && _tokens[i + 2, a].ValueInt == 1 && _tokens[i + 3, a].ValueInt == 1)
                    {
                        return 1;
                    }
                    if (_tokens[i, a].ValueInt == 2 && _tokens[i + 1, a].ValueInt == 2 && _tokens[i + 2, a].ValueInt == 2 && _tokens[i + 3, a].ValueInt == 2)
                    {
                        return 1;
                    }
                }
            }
            //Horizontalne riesenie - malo by ist
            for (int a = 0; a < RowCount; a++)
            {
                for (int i = 0; i < (ColumnCount - 3); i++)
                {
                    if (_tokens[a, i].ValueInt == 1 && _tokens[a , i + 1].ValueInt == 1 && _tokens[a, i + 2].ValueInt == 1 && _tokens[a, i + 3].ValueInt == 1)
                    {
                        return 1;
                    }
                    if (_tokens[a, i].ValueInt == 2 && _tokens[a , i + 1].ValueInt == 2 && _tokens[a, i + 2].ValueInt == 2 && _tokens[a, i + 3].ValueInt == 2)
                    {
                        return 1;
                    }
                }
            }
            //Diagonalne riesenie \ - malo by ist
            for (int i = 0; i < (ColumnCount - 3); i++)
            {
                for (int a = 0; a < (RowCount - 3); a++)
                {
                    if (_tokens[a ,i ].ValueInt == 1 && _tokens[a + 1, i + 1].ValueInt == 1 && _tokens[a + 2, i + 2].ValueInt == 1 && _tokens[a + 3, i + 3].ValueInt == 1)
                    {
                        return 1;
                    }
                    if (_tokens[a, i].ValueInt == 2 && _tokens[a + 1, i + 1].ValueInt == 2 && _tokens[a + 2, i + 2].ValueInt == 2 && _tokens[a + 3, i + 3].ValueInt == 2)
                    {
                        return 1;
                    }
                }
            }
            //Diagonalne riesenie / - malo by ist
            for (int a = 0; a < (RowCount - 3); a++)  
            {
                for (int i = ColumnCount - 1; i > (ColumnCount - 5); i--)
                {
                    if (_tokens[a, i].ValueInt == 1 && _tokens[a + 1, i - 1].ValueInt == 1 && _tokens[a + 2, i - 2].ValueInt == 1 && _tokens[a + 3, i - 3].ValueInt == 1)
                    {
                        return 1;
                    }
                    if (_tokens[a, i].ValueInt == 2 && _tokens[a + 1, i - 1].ValueInt == 2 && _tokens[a + 2, i - 2].ValueInt == 2 && _tokens[a + 3, i - 3].ValueInt == 2)
                    {
                        return 1;
                    }
                }
            }
                
                for (var row = 0; row < RowCount; row++)
                {
                    for (var column = 0; column < ColumnCount; column++)
                    {
                        if(GetToken(row, column).ValueInt != 0)
                        {
                        remiza--;
                        }
                    }
                }
                if(remiza == 0)
                {
                     return 2;
                }
            return 0;
        }

        public void PrintField()
        {
            Console.Clear();
            Console.WriteLine();
            for (var row = 0; row < RowCount; row++)
            {
                for (var column = 0; column < ColumnCount; column++)
                {
                    Console.Write(GetToken(row, column).ValueInt + " ");
                }
                Console.Write(System.Environment.NewLine);
            }
        }
        public void PlayerMove(Player player, int columnInt, int num)
        {
            columnInt = columnInt + 1;
            int h = SetToken(columnInt, num);
            while (h == 1)
            {
                h = SetToken(columnInt, num);
            }
            player.ScoreMinus();

        }
        
    }
}
