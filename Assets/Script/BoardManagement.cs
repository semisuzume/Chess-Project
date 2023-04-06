using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardManagement : MonoBehaviour
{
    public static string[,] board = new string[8, 8];
    GameObject piece;

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
        if(piece == "SS")
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

    private bool CheckKing(Vector2Int frm, Vector2Int to)
    {
        /*
			###
			#@#
			###
		*/
        for (int di = -1; di <= 1; di++)
        {
            for (int dj = -1; dj <= 1; dj++)
            {
                if (frm + new Vector2Int(di, dj) == to)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool Direct(int sign_x, int sign_y, Vector2Int frm, Vector2Int to)
    {
        for (int d = 0; d < 8; d++)
        {
            Vector2Int movePos = frm + new Vector2Int(sign_x * d, sign_y * d);
            if (!(0 <= movePos.x && movePos.x < 8 && 0 <= movePos.y && movePos.y < 8))
            {
                break;
            }

            if (movePos == to)
            {
                return true;
            }
        }
        return false;
    }

    private bool CheckQueen(Vector2Int frm,Vector2Int to)
    {
        bool flg = false;

        for (int direct = 0; direct < 8; direct++)
        {
            //direct 0~7
            int radian = direct * 45;
            //Debug.Log(radian);
            int sign_x = (int)Math.Round(Math.Cos(radian * (Math.PI / 180)));
            int sign_y = (int)Math.Round(Math.Sin(radian * (Math.PI / 180)));
            //Debug.Log(sign_x.ToString() + ", " + sign_y.ToString());
            flg |= Direct(sign_x, sign_y, frm, to);
        }

        return flg;
    }

    private bool CheckLuek(Vector2Int frm, Vector2Int to)
    {
        bool flg = false;

        for (int direct = 0; direct < 4; direct++)
        {
            int radian = direct * 90;
            int sign_x = (int)Math.Round(Math.Cos(radian * (Math.PI / 180)));
            int sign_y = (int)Math.Round(Math.Sin(radian * (Math.PI / 180)));
            flg |= Direct(sign_x, sign_y, frm, to);
        }

        return flg;
    }

    private bool CheckBISHOP(Vector2Int frm,Vector2Int to)
    {
        bool flg = false;

        for(int direct = 1;direct < 8;direct+= 2)
        {
            int radian = direct * 45;
            int sign_x = (int)Math.Round(Math.Cos(radian * (Math.PI / 180)));
            int sign_y = (int)Math.Round(Math.Sin(radian * (Math.PI / 180)));
            flg |= Direct(sign_x, sign_y, frm, to);
        }

        return flg;
    }

    private bool CheckKnight(Vector2Int frm, Vector2Int to)
    {
        for (int di = -2; di <= 2; di++)
        {
            for (int dj = -2; dj <= 2; dj++)
            {
                if(Math.Abs(di) == Math.Abs(dj))
                {
                    Debug.Log(Math.Abs(di) == Math.Abs(dj));
                    break;
                }
                else if (frm + new Vector2Int(di, dj) == to)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private bool CheckPawn(Vector2Int frm, Vector2Int to)
    {
        if(frm + new Vector2Int(0,1) == to)
        {
            return true;
        }
        return false;
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
