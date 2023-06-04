using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BoardManagement : MonoBehaviour
{
    /// <summary>
    /// 順番:RNC
    /// </summary>
    public static string[,] board = new string[8, 8];
    GameObject piece;
    GameObject image;
    GameManagement gameManagement;
    Vector2Int topFloorTo;

    // Start is called before the first frame update
    void Start()
    {
        image = GameObject.Find("Image");
        gameManagement = gameObject.GetComponent<GameManagement>();
        Init();
        GeneratePiece();
        image.SetActive(false);
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
                if ((Y == 7) && (X == 0))
                {
                    board[Y, X] = "L1W";
                }
                else if ((Y == 7) && (X == 7))
                {
                    board[Y, X] = "L2W";
                }
                else if ((Y == 7) && (X == 1))
                {
                    board[Y, X] = "N1W";
                }
                else if ((Y == 7) && (X == 6))
                {
                    board[Y, X] = "N2W";
                }
                else if ((Y == 7) && (X == 2))
                {
                    board[Y, X] = "B1W";
                }
                else if ((Y == 7) && (X == 5))
                {
                    board[Y, X] = "B2W";
                }
                else if ((Y == 7) && (X == 3))
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
                else if (Y == 6)
                {
                    board[Y, X] = "P" + (X + 1).ToString() + "W" + 1;
                }
                else if (Y == 1)
                {
                    board[Y, X] = "P" + (X + 1).ToString() + "B" + 1;
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
        foreach (GameObject destroyPiece in GameObject.FindGameObjectsWithTag("chesspiece"))
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
        for (int Y = 0; Y < board.GetLength(0); Y++)
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
        if (piece == "SS")
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

    public bool ChoicedCheck(int player, int Case, Vector2Int choicedIndex)
    {
        switch (Case)
        {
            case 0:
                string piece = board[choicedIndex.y, choicedIndex.x];
                if (piece == "SS")
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
            //pownが前進するとき相手の駒が取れないようにする
            case 1:
                piece = board[choicedIndex.y, choicedIndex.x];
                if (!(piece == "SS"))
                {
                    if (player == 0 && piece.Substring(2, 1) != Constants.Pieces.WHITE)
                    {
                        if (player == 1 && piece.Substring(2, 1) != Constants.Pieces.BLACK)
                        {
                            return false;
                        }
                    }
                }
                else if (piece == "SS")
                {
                    return true;
                }
                break;
            //pownが斜め移動するときに呼び出す
            case 2:
                piece = board[choicedIndex.y, choicedIndex.x];
                //選択先が空白で
                if (!(piece == "SS"))
                {　　
                    //白のターンで選択しているのが白の駒じゃない時
                    if (player == 0 && piece.Substring(2, 1) != Constants.Pieces.WHITE)
                    {
                        return true;
                    }
                    //黒のターンで選択しているのが黒の駒じゃない時
                    if (player == 1 && piece.Substring(2, 1) != Constants.Pieces.BLACK)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
                break;
        }
        return false;
    }

    public bool CheckMovePoss(int player, Vector2Int frm, Vector2Int to)
    {
        switch (board[frm.y, frm.x].Substring(0, 1))
        {
            case "K":
                Debug.Log(CheckKing(frm, to));
                return CheckKing(frm, to);
            case "Q":
                Debug.Log(CheckQueen(frm, to));
                return CheckQueen(frm, to);
            case "L":
                Debug.Log(CheckLuke(frm, to));
                return CheckLuke(frm, to);
            case "B":
                Debug.Log(CheckBishop(frm, to));
                return CheckBishop(frm, to);
            case "N":
                Debug.Log(CheckKnight(frm, to));
                return CheckKnight(frm, to);
            case "P":
                return CheckPawn(player, frm, to);
        }
        return false;
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
        for (int d = 1; d < 8; d++)
        {
            Vector2Int movePos = frm + new Vector2Int(sign_x * d, sign_y * d);
            //Debug.Log(movePos.x + "|" + movePos.y);
            if (!(0 <= movePos.x && movePos.x < 8 && 0 <= movePos.y && movePos.y < 8))
            {
                Debug.Log("配列外です");
                return false;
            }

            string rangeRank = board[movePos.y, movePos.x];
            if (movePos == to)
            {
                return true;
            }
            else if (rangeRank != "SS")
            {
                Debug.Log("妨害されました");
                return false;
            }
        }
        return false;
    }

    private bool CheckQueen(Vector2Int frm, Vector2Int to)
    {
        bool flg = false;

        for (int direct = 0; direct < 8; direct++)
        {
            //direct 0~7
            int radian = direct * 45;
            //Debug.Log(radian);
            int sign_x = (int)Math.Round(Math.Cos(radian * (Math.PI / 180)));
            int sign_y = (int)Math.Round(Math.Sin(radian * (Math.PI / 180)));
            Debug.Log(sign_x.ToString() + ", " + sign_y.ToString());
            flg |= Direct(sign_x, sign_y, frm, to);
        }

        return flg;
    }

    private bool CheckLuke(Vector2Int frm, Vector2Int to)
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

    private bool CheckBishop(Vector2Int frm, Vector2Int to)
    {
        bool flg = false;

        for (int direct = 1; direct < 8; direct += 2)
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
                Debug.Log(di + "," + dj);
                //ナイトの移動範囲は縦と横の移動数が同じになる事が無く
                if (!(Math.Abs(di) == Math.Abs(dj)))
                {
                    //ｘ、ｙ共に一マス以上動く
                    if (!(di == 0 || dj == 0))
                    {
                        if (frm + new Vector2Int(di, dj) == to)
                        {
                            return true;
                        }
                    }
                }
            }
        }
        return false;
    }

    /// <summary>
    /// Debugで呼び出しちゃダメ
    /// </summary>
    /// <param name="player"></param>
    /// <param name="frm"></param>
    /// <param name="to"></param>
    /// <returns></returns>
    private bool CheckPawn(int player, Vector2Int frm, Vector2Int to)
    {
    　　//白ならば-1黒ならば1
        int direct = 1;
        if (player == 0)
        {
            direct = -1;
        }

        //配列のデータが４文字どうかで一度も動いていないかを判別する
        if (board[frm.y, frm.x].Length == 4)
        {
            //二マス動かす時
            if (frm + new Vector2Int(0, 2 * direct) == to)
            {
                if (ChoicedCheck(player, 1, to))
                {
                    Debug.Log("true");
                    board[frm.y, frm.x] = board[frm.y, frm.x].Substring(0, 3);
                    return true;
                }
            }
        }
        //一マス動く時
        if (frm + new Vector2Int(0, 1 * direct) == to)
        {
            if (ChoicedCheck(player, 1, to))
            {
                Debug.Log("true");
                board[frm.y, frm.x] = board[frm.y, frm.x].Substring(0, 3);
                return true;
            }
        }
        //斜めに移動する時
        else
        {
            //1 ~ -1
            for (int di = -1; di <= 1; di += 2)
            {
                if (frm + new Vector2Int(di, 1 * direct) == to)
                {
                    Debug.Log("成功");
                    if (ChoicedCheck(player, 2, to))
                    {
                        Debug.Log("true");
                        CheckPromotion(player, to);
                        return true;
                    }
                }
                else
                {
                    //1 ~ -1
                    for (int di = -1; di <= 1; di += 2)
                    {
                        if (frm + new Vector2Int(di, 1) == to)
                        {
                            Debug.Log("true");
                            CheckPromotion(player, to);
                            return true;
                        }
                    }
                }
                return false;
        }

        Debug.Log("false");
        return false;
    }
    //CheckPawn関数から呼び出す
    private void CheckPromotion(int player, Vector2Int to)
    {
        //ポーンが盤面の端に到達したとき
        if (to.y == 7 || to.y == 0)
        {
            image.SetActive(true);
            topFloorTo = to;
            gameManagement.F = true;
            Debug.Log("Promotion");
        }
    }
    public void Promotion(string rank)
    {
        image.SetActive(false);
        int player = gameManagement.player;
        string color = null;
        if (player == 0)
        {
            color = "W";
        }
        else if(player == 1)
        {
            color = "B";
        }
        board[topFloorTo.y, topFloorTo.x] = rank + "0" + color;
        Debug.Log(board[topFloorTo.y, topFloorTo.x]);
        GeneratePiece();
        gameManagement.F = false;
    }

    public void MovePiece(Vector2Int pieceIndex, Vector2Int choicedIndex)
    {
        string selectedPieceString = board[pieceIndex.y, pieceIndex.x];
        board[pieceIndex.y, pieceIndex.x] = "SS";
        board.SetValue(selectedPieceString, choicedIndex.y, choicedIndex.x);
        //BoardPrint();
        GeneratePiece();
    }
}
