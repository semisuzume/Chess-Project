using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class Constants : MonoBehaviour
{
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

        public static readonly Dictionary<string, Material> COLOR = new Dictionary<string, Material>()
        {
            {Pieces.BLACK, PieceColor.BLACK},
            {Pieces.WHITE, PieceColor.WHITE},
        };
    }
}
