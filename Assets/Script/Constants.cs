using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class Constants : MonoBehaviour
{
    public class PieceRangeV
    {
        public List<Vector2Int> vector2Ints;
        public int Case;
    }

    public void Start()
    {
        SetPieceRangeV.RangeSetKING.vector2Ints = PieceRange.KING;
        SetPieceRangeV.RangeSetKING.Case = PieceRange.CaseKING;
        SetPieceRangeV.RangeSetQUEEN.vector2Ints = PieceRange.QUEEN;
        SetPieceRangeV.RangeSetQUEEN.Case = PieceRange.CaseQUEEN;
        SetPieceRangeV.RangeSetLUKE.vector2Ints = PieceRange.LUKE;
        SetPieceRangeV.RangeSetLUKE.Case = PieceRange.CaseLUKE;
        SetPieceRangeV.RangeSetBISHOP.vector2Ints = PieceRange.BISHOP;
        SetPieceRangeV.RangeSetBISHOP.Case = PieceRange.CaseBISHOP;
        SetPieceRangeV.RangeSetKNIGHT.vector2Ints = PieceRange.KNIGHT;
        SetPieceRangeV.RangeSetKNIGHT.Case = PieceRange.CaseKNIGHT;
        SetPieceRangeV.RangeSetPAWN.vector2Ints = PieceRange.PAWN;
        SetPieceRangeV.RangeSetPAWN.Case = PieceRange.CasePAWN;
    }

    private void Update()
    {
        //Debug.Log(SetPieceRangeV.RangeSetPAWN.Case);
    }
    public static class Pieces
    {
        public static readonly string SPACE = "S";

        //K キング
        public static readonly string KING = "K";
        //Q クイーン
        public static readonly string QUEEN = "Q";
        //R ルーク
        public static readonly string LUKE = "L";
        //B ビショップ
        public static readonly string BISHOP = "B";
        //N ナイト
        public static readonly string KNIGHT = "N";
        //P ポーン
        public static readonly string PAWN = "P";

        //黒
        public static readonly string BLACK = "B";
        //白
        public static readonly string WHITE = "W";
    }

    /// <summary>
    /// 生成するためのObject情報を格納しておく場所
    /// </summary>
    public static class PieceObject
    {
        //K キング
        public static readonly GameObject KING = Resources.Load("chesspiece_king") as GameObject;
        //Q クイーン
        public static readonly GameObject QUEEN = Resources.Load("chesspiece_queen") as GameObject;
        //R ルーク
        public static readonly GameObject LUKE = Resources.Load("chesspiece_luke") as GameObject;
        //B ビショップ
        public static readonly GameObject BISHOP = Resources.Load("chesspiece_bishop") as GameObject;
        //N ナイト
        public static readonly GameObject KNIGHT = Resources.Load("chesspiece_knight") as GameObject;
        //P ポーン
        public static readonly GameObject PAWN = Resources.Load("chesspiece_pawn") as GameObject;
        //S 空白
        public static readonly GameObject SPACE = Resources.Load("SS") as GameObject;
    }

    public static class PieceColor
    {
        //黒
        public static readonly Material BLACK = Resources.Load("PieceBlack") as Material;
        //白
        public static readonly Material WHITE = Resources.Load("PieceWhite") as Material;
        //金
        public static readonly Material GOLD = Resources.Load("PieceGold") as Material;
    }

    public static class SetPieceRangeV
    {
        public static PieceRangeV RangeSetKING = new PieceRangeV();
        public static PieceRangeV RangeSetQUEEN = new PieceRangeV();
        public static PieceRangeV RangeSetLUKE = new PieceRangeV();
        public static PieceRangeV RangeSetBISHOP = new PieceRangeV();
        public static PieceRangeV RangeSetKNIGHT = new PieceRangeV();
        public static PieceRangeV RangeSetPAWN = new PieceRangeV();
    }

    public static class PieceRange
    {
        public static readonly List<Vector2Int> KING = new List<Vector2Int> { new Vector2Int(0, 1), new Vector2Int(1, 1), new Vector2Int(1, 0), new Vector2Int(1, -1), new Vector2Int(0, -1), new Vector2Int(-1, -1), new Vector2Int(-1, 0), new Vector2Int(-1, 1) };
        public static readonly List<Vector2Int> QUEEN = new List<Vector2Int> { new Vector2Int(0, 7), new Vector2Int(7, 7), new Vector2Int(7, 0), new Vector2Int(7, -7), new Vector2Int(0, -7), new Vector2Int(-7, -7), new Vector2Int(-7, 0), new Vector2Int(-7, 7) };
        public static readonly List<Vector2Int> LUKE = new List<Vector2Int> { new Vector2Int(0, 7), new Vector2Int(7, 0), new Vector2Int(0, -7), new Vector2Int(-7, 0) };
        public static readonly List<Vector2Int> BISHOP = new List<Vector2Int> { new Vector2Int(7, 7), new Vector2Int(7, -7), new Vector2Int(-7, -7), new Vector2Int(-7, 7) };
        public static readonly List<Vector2Int> KNIGHT = new List<Vector2Int> { new Vector2Int(1, 2), new Vector2Int(2, 1), new Vector2Int(2, -1), new Vector2Int(1, -2), new Vector2Int(-1, -2), new Vector2Int(-2, -1), new Vector2Int(-2, 1), new Vector2Int(-1, 2) };
        public static readonly List<Vector2Int> PAWN = new List<Vector2Int> { new Vector2Int(0, 2), new Vector2Int(0, 1) };
        public static readonly int CaseKING = 0;
        public static readonly int CaseQUEEN = 1;
        public static readonly int CaseLUKE = 1;
        public static readonly int CaseBISHOP = 1;
        public static readonly int CaseKNIGHT = 3;
        public static readonly int CasePAWN = 2;
    }

    public static class PieceDictionary
    {
        public static readonly Dictionary<string, GameObject> RANK = new Dictionary<string, GameObject>()
        {
            {Pieces.KING, PieceObject.KING},
            {Pieces.QUEEN, PieceObject.QUEEN},
            {Pieces.LUKE, PieceObject.LUKE},
            {Pieces.BISHOP, PieceObject.BISHOP},
            {Pieces.KNIGHT, PieceObject.KNIGHT},
            {Pieces.PAWN, PieceObject.PAWN},
            {Pieces.SPACE,PieceObject.SPACE},
        };

        public static readonly Dictionary<string, PieceRangeV> MovingRange = new Dictionary<string, PieceRangeV>()
        {
            {Pieces.KING, SetPieceRangeV.RangeSetKING},
            {Pieces.QUEEN, SetPieceRangeV.RangeSetQUEEN},
            {Pieces.LUKE, SetPieceRangeV.RangeSetLUKE},
            {Pieces.BISHOP, SetPieceRangeV.RangeSetBISHOP},
            {Pieces.KNIGHT, SetPieceRangeV.RangeSetKNIGHT},
            {Pieces.PAWN, SetPieceRangeV.RangeSetPAWN},
        };

        public static readonly Dictionary<string, Material> COLOR = new Dictionary<string, Material>()
        {
            {Pieces.BLACK, PieceColor.BLACK},
            {Pieces.WHITE, PieceColor.WHITE},
        };
    }
}
