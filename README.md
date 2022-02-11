# Simple Arithmatic Expression Evaluator
## Description
A arithmatic expression evaluator that uses recursive decent parser. 
Written in C# with .Net Framework 4.5.

### EBNF Grammar:
```
Expression := [ "-" ] Term { ("+" | "-") Term }
Term       := Factor { ( "*" | "/" ) Factor }
Factor     := RealNumber | "(" Expression ")"
RealNumber := Digit{Digit} | [Digit] "." {Digit}
Digit      := "0" | "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9" 
```

