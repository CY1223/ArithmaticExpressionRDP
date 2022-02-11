using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticExpressionParser
{
    public enum SyntaxKind
    {
        NumberToken,
        WhitespaceToken,
        PlusToken,
        MinusToken,
        StarToken,
        SlashToken,
        OpenParenthesisToken,
        CloseParenthesisToken,
        BadToken,
        EndOfFileToken
    }
    public class SyntaxToken
    {

        public SyntaxKind Kind { get; }
        //public int Position { get; }
        //public string Text { get; }
        public object Value { get; }

        public SyntaxToken(SyntaxKind kind, object value)
        {
            Kind = kind;
            /*Position = position;
            Text = text;*/
            Value = value;
        }
    }
}
