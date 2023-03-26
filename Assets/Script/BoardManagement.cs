using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardManagement : MonoBehaviour
{
    public static string[,] board = new string[8, 8];
    GameObject piece;
    Constants.PieceRangeV PieceRangeV = new Constants.PieceRangeV();
    bool y;
    bool x;

    // Start is called before the first frame update
    void Start()
    {
        Init();
        GeneratePiece();
        //Debug.Log(" ");
        //BoardPrint();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// 盤面の配置の状況を初期状態に戻す
    /// </summary>
    void Init()
    {
        for (int Y = 0; Y < board.GetLength(0); Y++)
        {
            for (int X = 0; X < board.GetLength(1); X++)
            {
                if((Y == 7) && (X == 0))
                {
                    board[Y, X] = "L1W";
                }
                else if ((Y == 7) && (X == 7))
                {
                    board[Y, X] = "L2W";
                }
                else if((Y == 7) && (X == 1))
                {
                    board[Y, X] = "N1W";
                }
                else if ((Y == 7) && (X == 6))
                {
                    board[Y, X] = "N2W";
                }
                else if((Y == 7) && (X == 2))
                {
                    board[Y, X] = "B1W";
                }
                else if ((Y == 7) && (X == 5))
                {
                    board[Y, X] = "B2W";
                }
                else if((Y == 7) && (X == 3))
                {
                    board[Y, X] = "K1W";
                }
                else if ((Y == 7) && (X == 4))
                {
                    board[Y, X] = "Q2W";
                }
                //ここからBlack
                else if ((Y == 0) && (X == 0))
                {
                    board[Y, X] = "L1B";
                }
                else if ((Y == 0) && (X == 7))
                {
                    board[Y, X] = "L2B";
                }
                else if ((Y == 0) && (X == 1))
                {
                    board[Y, X] = "N1B";
                }
                else if ((Y == 0) && (X == 6))
                {
                    board[Y, X] = "N2B";
                }
                else if ((Y == 0) && (X == 2))
                {
                    board[Y, X] = "B1B";
                }
                else if ((Y == 0) && (X == 5))
                {
                    board[Y, X] = "B2B";
                }
                else if ((Y == 0) && (X == 3))
                {
                    board[Y, X] = "Q1B";
                }
                else if ((Y == 0) && (X == 4))
                {
                    board[Y, X] = "K2B";
                }
                else if(Y == 6)
                {
                    board[Y, X] = "P" + (X + 1).ToString() + "W";
                }
                else if(Y == 1)
                {
                    board[Y, X] = "P" + (X + 1).ToString() + "B";
                }
                else
                {
                    board[Y, X] = "SS";
                }
            }
        }
    }

    void GeneratePiece()
    {
        foreach(GameObject destroyPiece in GameObject.FindGameObjectsWithTag("chesspiece"))
        {
            Destroy(destroyPiece);
        }
        for (int y = 0; y < board.GetLength(0); y++)
        {
            for (int x = 0; x < board.GetLength(1); x++)
            {
                if (board[y, x] != Constants.Pieces.SPACE + Constants.Pieces.SPACE)
                {
                    piece = Instantiate(Constants.PieceDictionary.RANK[board[y, x].Substring(0, 1)]);
                    piece.AddComponent<Piece>();
                    piece.tag = "chesspiece";
                    ColliderSettings();
                    piece.GetComponent<Piece>().Init(Constants.PieceDictionary.COLOR[board[y, x].Substring(2, 1)], board[y, x].Substring(2, 1), new Vector2Int(x, y));
                }
                if (board[y, x] == Constants.Pieces.SPACE + Constants.Pieces.SPACE)
                {
                    piece = Instantiate(Constants.PieceDictionary.RANK[board[y, x].Substring(0, 1)]);
                    piece.AddComponent<Piece>();
                    ColliderSettings();
                    piece.GetComponent<Piece>().Init(new Vector2Int(x, y));
                }
            }
        }
        //Debug.Log("実行されました3");
    }

    void ColliderSettings()
    {
        BoxCollider pieceCollider = piece.AddComponent<BoxCollider>();
        if (piece.name.Contains("chesspiece"))
        {
            pieceCollider.center = new Vector3(0, -0.25f, 0);
            pieceCollider.size = new Vector3(1, 1.5f, 1);
        }
        if (piece.name.Contains("SS"))
        {
            pieceCollider.center = new Vector3(0, -0.9f, 0);
            pieceCollider.size = new Vector3(1, 0.2f, 1);
        }
    }

    /// <summary>
    /// Logに表示
    /// </summary>
    void BoardPrint()
    {
        for(int Y= 0; Y < board.GetLength(0); Y++)
        {
            string printString = "";
            for (int X = 0; X < board.GetLength(1); X++)
            {
                printString += board[Y, X] + ",";
            }
            Debug.Log(printString);
        }
    }

    public bool CheckTurn(int player, Vector2Int index)
    {
        string piece = board[index.y, index.x];
        if(piece == "SS")
        {
            return false;
        }
        if (player == 0 && piece.Substring(2, 1) == Constants.Pieces.WHITE)
        {
            return true;
        }
        else if (player == 1 && piece.Substring(2, 1) == Constants.Pieces.BLACK)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool ChoicedCheck(int player, Vector2Int choicedIndex)
    {
        string piece = board[choicedIndex.y, choicedIndex.x];
        if (piece == "SSO")
        {
            return true;
        }
        else if(piece == "SS")
        {
            return true;
        }
        else if (player == 0 && piece.Substring(2, 1) == Constants.Pieces.WHITE)
        {
            return false;
        }
        else if (player == 1 && piece.Substring(2, 1) == Constants.Pieces.BLACK)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public void Check(Vector2Int pieceIndex)
    {
        PieceRangeV = Constants.PieceDictionary.MovingRange[board[pieceIndex.y, pieceIndex.x].Substring(0, 1)];
        foreach (Vector2Int vector2Int in PieceRangeV.vector2Ints)
        {
            Debug.Log(board[pieceIndex.y, Math.Abs(vector2Int.y)]);
            if (vector2Int.x == 0)
            {
                if(board[pieceIndex.y, Math.Abs(vector2Int.y)] == Constants.Pieces.SPACE + Constants.Pieces.SPACE)
                {
                    board[pieceIndex.y, vector2Int.y] += "O";
                }
            }
            if (vector2Int.y == 0)
            {
                if (board[pieceIndex.y, Math.Abs(vector2Int.y)] == Constants.Pieces.SPACE + Constants.Pieces.SPACE)
                {
                    board[pieceIndex.y, vector2Int.y] += "O";
                }
            }
        }
    }

    public void MovePiece(Vector2Int pieceIndex,Vector2Int choicedIndex)
    {
        string selectedPieceString = board[pieceIndex.y, pieceIndex.x];
        board[pieceIndex.y, pieceIndex.x] = "SS";
        board.SetValue(selectedPieceString, choicedIndex.y, choicedIndex.x);
        //BoardPrint();
        GeneratePiece();
    }
}
