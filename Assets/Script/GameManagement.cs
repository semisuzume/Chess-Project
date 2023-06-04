using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagement : MonoBehaviour
{
    private BoardManagement boardManagement;
    private Vector2Int pieceIndex = new Vector2Int(-1, -1);
    private Vector2Int choicedIndex = new Vector2Int(-1, -1);
    public int player = 0;
    public bool F;

    // Start is called before the first frame update
    void Start()
    {
        boardManagement = GetComponent<BoardManagement>();
        StartCoroutine("Select");
        F = false;
    }

    // Update is called once per frame
    void Update()
    {
        
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
                    //�擾
                    selectPiece = hit.collider.gameObject;
                    //�܂��ړ���������I��Ă��Ȃ��Ȃ�
                    if (pieceIndex.x < 0 || pieceIndex.y < 0)
                    {
                        pieceIndex = selectPiece.GetComponent<Piece>().Select();
                        //�I�����̂�"SS"������̂Ȃ烊�Z�b�g
                        if (!boardManagement.CheckTurn(player, pieceIndex))
                        {
                            ResetIndex(0);
                        }
                    }
                    else if (choicedIndex.x < 0 || choicedIndex.y < 0)
                    {
                        choicedIndex = selectPiece.GetComponent<Piece>().Select();
                        if (boardManagement.ChoicedCheck(player, 0, choicedIndex))
                        {
                            //checkPown��
                            if (boardManagement.CheckMovePoss(player, pieceIndex, choicedIndex))
                            {
                                boardManagement.MovePiece(pieceIndex, choicedIndex);
                                while (F == true)
                                {
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
