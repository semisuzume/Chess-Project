using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Promotion : MonoBehaviour
{
    public BoardManagement boardManagement;
    public string rank;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ëIëÅ®
    public void PromotionButton()
    {
        boardManagement.Promotion(rank);
    }
}
