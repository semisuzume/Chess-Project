using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Piece : MonoBehaviour
{
    static Vector2 indexNumber;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetPosition(string argCamp, Vector2Int argIndex)
    {
        transform.position = Utility.Index2Coordinate(argIndex);
        if(argCamp == "B")
        {
            transform.localEulerAngles = new Vector3(0,180,0);
        }
    }

    void SetPosition(Vector2Int argIndex)
    {
        transform.position = Utility.Index2Coordinate(argIndex);
    }

    public static void PieceMove(GameObject piece)
    {
        piece.transform.position += new Vector3(0, 1, 0);
    }

    public void Init(Material argColor, string argCamp, Vector2Int argIndex)
    {
        gameObject.transform.GetChild(0).GetComponent<Renderer>().material = Constants.PieceColor.GOLD;
        if (argCamp == "W")
        {
            gameObject.transform.GetChild(1).GetComponent<Renderer>().material = argColor;
            gameObject.transform.GetChild(2).GetComponent<Renderer>().material = Constants.PieceColor.GOLD;
        }
        else
        {
            gameObject.transform.GetChild(1).GetComponent<Renderer>().material = argColor;
            gameObject.transform.GetChild(2).GetComponent<Renderer>().material = argColor;
        }
        SetPosition(argCamp, argIndex);
    }

    public void Init(Vector2Int argIndex)
    {
        SetPosition(argIndex);
    }

    public Vector2Int Select()
    {
        return Utility.Coordinate2Index(transform.position);
    }
}
