using ChessChallenge.API;

public class MyBot : IChessBot
{
    /* Rough overview of what the Bot is doing..

    First idea:
    - Starts with some 'book' opening
    - Once out of the 'opening', determine the best move!
        - Minmax with Alpha-Beta pruning? Monte Carlo Tree Search? Stochastic Gradient Descent?
        - We will need to define some cost function to minimise?
    - Once queens are off the board, enter 'end game' mode..?
    */

    // Piece values: null, pawn, knight, bishop, rook, queen, king
    int[] pieceValues = { 0, 100, 300, 300, 500, 900, 10000 };

    public Move Think(Board board, Timer timer)
    {
       Move[] allMoves = board.GetLegalMoves();

        // Pick a random move to play if nothing better is found
        Random rng = new();
        Move moveToPlay = allMoves[rng.Next(allMoves.Length)];
        int highestValueCapture = 0;

        foreach (Move move in allMoves)
        {
            // Find highest value capture
            Piece capturedPiece = board.GetPiece(move.TargetSquare);
            int capturedPieceValue = pieceValues[(int)capturedPiece.PieceType];

            if (capturedPieceValue > highestValueCapture)
            {
                moveToPlay = move;
                highestValueCapture = capturedPieceValue;
            }
        }
        return moveToPlay;
    }
}
