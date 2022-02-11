using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ArithmeticExpressionParser
{

    public class Tokenizer
    {
        private StringReader _reader;

        public List<SyntaxToken> Scan(string expression)
        {
            _reader = new StringReader(expression);

            var tokens = new List<SyntaxToken>();
            while (_reader.Peek() != -1)
            {
                var c = (char)_reader.Peek();
                if (Char.IsWhiteSpace(c))
                {
                    _reader.Read();
                    continue;
                }

                if (Char.IsDigit(c) || c == '.')
                {
                    var nr = ParseNumber();
                    tokens.Add(new SyntaxToken(SyntaxKind.NumberToken, nr));
                }
                else if (c == '-')
                {
                    tokens.Add(new SyntaxToken(SyntaxKind.MinusToken, null));
                    _reader.Read();
                }
                else if (c == '+')
                {
                    tokens.Add(new SyntaxToken(SyntaxKind.PlusToken, null));
                    _reader.Read();
                }
                else if (c == '*')
                {
                    tokens.Add(new SyntaxToken(SyntaxKind.StarToken, null));
                    _reader.Read();
                }
                else if (c == '/')
                {
                    tokens.Add(new SyntaxToken(SyntaxKind.SlashToken, null));
                    _reader.Read();
                }
                else if (c == '(')
                {
                    tokens.Add(new SyntaxToken(SyntaxKind.OpenParenthesisToken, null));
                    _reader.Read();
                }
                else if (c == ')')
                {
                    tokens.Add(new SyntaxToken(SyntaxKind.CloseParenthesisToken, null));
                    _reader.Read();
                }
                else
                    throw new Exception("Unknown character in expression: " + c);
            }

            return tokens;
        }

        private double ParseNumber()
        {
            var sb = new StringBuilder();
            var decimalExists = false;
            while (Char.IsDigit((char)_reader.Peek()) || ((char) _reader.Peek() == '.'))
            {
                var digit = (char)_reader.Read();
                if (digit == '.')
                {
                    if (decimalExists) throw new Exception("Multiple dots in decimal number");
                    decimalExists = true;
                }
                sb.Append(digit);
            }

            double res;
            if (!double.TryParse(sb.ToString(), out res))
                throw new Exception("Could not parse number: " + sb);

           return res;
        }
    }
}
