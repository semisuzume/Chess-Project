using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    private BoardManagement boardManagement;
    private Vector2Int pieceIndex = new Vector2Int(-1, -1);
    private Vector2Int choicedIndex = new Vector2Int(-1, -1);
    private int player = 0;

    // Start is called before the first frame update
    void Start()
    {
        boardManagement = GetComponent<BoardManagement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            GameObject selectPiece = null;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
            {
                selectPiece = hit.collider.gameObject;
                //Debug.Log(selectPiece);
                if (pieceIndex.x < 0 || pieceIndex.y < 0)
                {
                    pieceIndex = selectPiece.GetComponent<Piece>().Select();
                    if (!boardManagement.CheckTurn(player, pieceIndex))
                    {
                        ResetIndex(0);
                    }
                    //Debug.Log(pieceIndex);
                    //Debug.Log(choicedIndex);
                }
                else if (choicedIndex.x < 0 || choicedIndex.y < 0)
                {
                    choicedIndex = selectPiece.GetComponent<Piece>().Select();
                    //Debug.Log(pieceIndex);
                    //Debug.Log(choicedIndex);
                    if (boardManagement.ChoicedCheck(player, choicedIndex))
                    {
                        if (boardManagement.CheckMovePoss(player, pieceIndex, choicedIndex))
                        {
                            Debug.Log("A");
                            boardManagement.MovePiece(pieceIndex, choicedIndex);
                            ResetIndex();
                            ChangePlayer();
                        }
                    }
                    else
                    {
                        ResetIndex(1);
                    }
                }
            }
        }
    }

    private void ChangePlayer()
    {
        if (player == 0)
        {
            player = 1;
        }
        else
        {
            player = 0;
        }

        /*
			player = 1 - player;
			player ^= 1
		*/
    }

    public void ResetIndex(int Case)
    {
        if (Case == 0)
        {
            pieceIndex = new Vector2Int(-1, -1);
        }
        if (Case == 1)
        {
            choicedIndex = new Vector2Int(-1, -1);
        }
    }
    private void ResetIndex()
    {
        ResetIndex(0);
        ResetIndex(1);
    }
}
