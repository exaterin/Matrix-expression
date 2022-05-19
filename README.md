# Matrix-expression
A class for evaluation of matrix expressions in postfix notation

**Input:** <br>
The first line of standard input contains integers N and M. After that, the input contains M matrices of size (N x N). Each matrix appears on N input lines, and is followed by a blank line.

The final input line contains a expression in postfix notation. Each expression token is either a positive integer or one of the operators '+', '-' or '*'.

Tokens are separated by a single space. In the expression, the integer K represents the Kth input matrix, where matrices are numbered starting from 1.

**Example of input:**

2 2 <br>
1 2 <br>
2 1 <br>

1 0 <br>
2 3 <br>

1 2 *

**Output:** <br>
The resulting (N x N) matrix to N output lines.
