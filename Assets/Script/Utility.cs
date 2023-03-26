using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility : MonoBehaviour
{
    private static readonly float scale = 1.84f;
    private static readonly float coordinateY = 1.2f;

    /// <summary>
    /// �C���f�b�N�X������W�֕ϊ�
    /// </summary>
    /// <param name="index">�C���f�b�N�X</param>
    /// <returns>coordinate</returns>
    public static Vector3 Index2Coordinate(Vector2Int index)
    {
        float coordinateX = scale * (-3.5f + index.x);
        float coordinateZ = -scale * (-3.5f + index.y);
        return new Vector3(coordinateX, coordinateY, coordinateZ);
    }

    /// <summary>
    /// ���W����C���f�b�N�X�֕ϊ�
    /// </summary>
    /// <param name="coordinate">���W</param>
    /// <returns>index</returns>
    public static Vector2Int Coordinate2Index(Vector3 coordinate)
    {
        int indexX = (int)((3.5f + (coordinate.x / scale)) * 100 + 0.5f) / 100;
        int indexY = (int)((3.5f - (coordinate.z / scale)) * 100 + 0.5f) / 100;
        return new Vector2Int(indexX, indexY);
    }
}
