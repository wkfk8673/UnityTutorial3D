
using UnityEngine;
using System.Collections.Generic;

public class Single_BoardTicTacToe
{
    public int[,] board;
    private const int ROWS = 3, COLS = 3;

    public int player;

    public Single_BoardTicTacToe()
    {
        player = 1;
        board = new int[ROWS, COLS];
    }

    // 갈 수 있는 칸
    public List<Single_Move> GetMoves()
    {
        var moves = new List<Single_Move>();
        for (int i = 0; i < COLS; i++)
        {
            for (int j = 0; j < ROWS; j++)
            {
                if (board[i, j] == 0)
                {
                    moves.Add(new Single_Move(j, i, player));
                }
            }
        }

        return moves;
    }

    public void MakeMove(Single_Move move)
    {
        if (board[move.y, move.x] != 0) return;
        board[move.y, move.x] = move.player;
        this.player = (move.player) == 1 ? 2 : 1; // 플레이어 토글 
    }


    // 0 : 진행중, 1: Player 1 승리, 2: Player 2 승리, 3: 무승부
    public int CheckWinner()
    {
        // 가로 확인
        for (int i = 0; i < ROWS; i++)
        {
            if (board[i, 0] != 0 && board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
            {
                return board[i, 0];
            }
        }
        // 세로 확인
        for (int j = 0; j < ROWS; j++)
        {
            if (board[0, j] != 0 && board[0, j] == board[1, j] && board[1, j] == board[2, j])
            {
                return board[0, j];
            }
        }

        // 대각선 확인

        if (board[0, 0] != 0 && board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
        {
            return board[0, 0];
        }



        if (board[0, 2] != 0 && board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
        {
            return board[0, 2];
        }

        // 무승부
        if (GetMoves().Count == 0)
        {
            return 3;
        }

        // 진행중
        return 0;
    }

    public bool IsGameOver()
    {
        return CheckWinner() != 0;
    }
}
