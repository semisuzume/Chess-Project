using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    private BoardManagement boardManagement;
    private Vector2Int pieceIndex = new Vector2Int(-1, -1);
    private Vector2Int choicedIndex = new Vector2Int(-1, -1);
    public int player = 0;
    bool F;

    // Start is called before the first frame update
    void Start()
    {
        boardManagement = GetComponent<BoardManagement>();
        StartCoroutine("Select");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            F = false;
        }
    }

    private IEnumerator Select()
    {
        while(true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                GameObject selectPiece = null;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit))
                {
                    //取得
                    selectPiece = hit.collider.gameObject;
                    //まだ移動させる駒を選択していないなら
                    if (pieceIndex.x < 0 || pieceIndex.y < 0)
                    {
                        pieceIndex = selectPiece.GetComponent<Piece>().Select();
                        //選択したものが"SS"だったのならリセット
                        if (!boardManagement.CheckTurn(player, pieceIndex))
                        {
                            ResetIndex(0);
                        }
                    }
                    else if (choicedIndex.x < 0 || choicedIndex.y < 0)
                    {
                        choicedIndex = selectPiece.GetComponent<Piece>().Select();
                        //Debug.Log(pieceIndex);
                        //Debug.Log(choicedIndex);
                        if (boardManagement.ChoicedCheck(player, 0, choicedIndex))
                        {
                            //checkPown等
                            if (boardManagement.CheckMovePoss(player, pieceIndex, choicedIndex))
                            {
                                Debug.Log("A");
                                F = true;
                                boardManagement.MovePiece(pieceIndex, choicedIndex);
                                while (F == true)
                                {
                                    Debug.Log("while");
                                    yield return null;
                                }
                                ResetIndex();
                                ChangePlayer();
                            }
                            else
                            {
                                ResetIndex(1);
                            }
                        }
                        else
                        {
                            ResetIndex();
                        }
                    }
                }
            }
            yield return null;
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
