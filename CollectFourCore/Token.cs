using System;

namespace CollectFour
{
    [Serializable]
    public class Token
    {
        public Token(int value)
        {
            ValueInt = value;
        }

        public int ValueInt { get; set; }
    }
}
