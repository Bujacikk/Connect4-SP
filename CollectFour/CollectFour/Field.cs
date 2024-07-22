using System;
using System.Collections.Generic;
using System.Text;

namespace CollectFour
{
    class Field
    {
        private Token[,] tokens;
        public Field(int rowCount, int columnCount)
        {
            RowCount = rowCount;
            ColumnCount = columnCount;
            tokens = new Token[rowCount,columnCount];
            GenerateField();
        }

        private void GenerateField()
        {
            throw new NotImplementedException();
        }

        public int RowCount
        {
            get;
        }
        public int ColumnCount
        {
            get;
        }
    }
}
