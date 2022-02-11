using System;
using System.Collections.Generic;
using System.Linq;

namespace ArithmeticExpressionParser
{
    public class TokensWalker
    {
        private readonly List<SyntaxToken> _tokens = new List<SyntaxToken>();
        private int _currentIndex = -1;

        public bool ThereAreMoreTokens
        {
            get { return _currentIndex < _tokens.Count - 1; }
        }

        public TokensWalker(List<SyntaxToken> tokens)
        {
            _tokens = tokens.ToList();
        }

        public SyntaxToken GetNext()
        {
            MakeSureWeDontGoPastTheEnd();
            return _tokens[++_currentIndex];
        }

        private void MakeSureWeDontGoPastTheEnd()
        {
            if (!ThereAreMoreTokens)
                throw new Exception("Cannot read pass the end of tokens list");
        }

        public SyntaxToken PeekNext()
        {
            MakeSureWeDontPeekPastTheEnd();
            return _tokens[_currentIndex + 1];
        }

        private void MakeSureWeDontPeekPastTheEnd()
        {
            var weCanPeek = (_currentIndex + 1 < _tokens.Count);
            if (!weCanPeek)
                throw new Exception("Cannot peek pass the end of tokens list");
        }

        public bool IsNextOfType(SyntaxKind type)
        {
            return PeekNext().Kind == type;
        }
    }
}