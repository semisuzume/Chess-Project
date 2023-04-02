using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class Constants : MonoBehaviour
{
    public static class Pieces
    {
        public static readonly string SPACE = "S";

        //K �L���O
        public static readonly string KING = "K";
        //Q �N�C�[��
        public static readonly string QUEEN = "Q";
        //R ���[�N
        public static readonly string LUKE = "L";
        //B �r�V���b�v
        public static readonly string BISHOP = "B";
        //N �i�C�g
        public static readonly string KNIGHT = "N";
        //P �|�[��
        public static readonly string PAWN = "P";

        //��
        public static readonly string BLACK = "B";
        //��
        public static readonly string WHITE = "W";
    }

    /// <summary>
    /// �������邽�߂�Object�����i�[���Ă����ꏊ
    /// </summary>
    public static class PieceObject
    {
        //K �L���O
        public static readonly GameObject KING = Resources.Load("chesspiece_king") as GameObject;
        //Q �N�C�[��
        public static readonly GameObject QUEEN = Resources.Load("chesspiece_queen") as GameObject;
        //R ���[�N
        public static readonly GameObject LUKE = Resources.Load("chesspiece_luke") as GameObject;
        //B �r�V���b�v
        public static readonly GameObject BISHOP = Resources.Load("chesspiece_bishop") as GameObject;
        //N �i�C�g
        public static readonly GameObject KNIGHT = Resources.Load("chesspiece_knight") as GameObject;
        //P �|�[��
        public static readonly GameObject PAWN = Resources.Load("chesspiece_pawn") as GameObject;
        //S ��
        public static readonly GameObject SPACE = Resources.Load("SS") as GameObject;
    }

    public static class PieceColor
    {
        //��
        public static readonly Material BLACK = Resources.Load("PieceBlack") as Material;
        //��
        public static readonly Material WHITE = Resources.Load("PieceWhite") as Material;
        //��
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
