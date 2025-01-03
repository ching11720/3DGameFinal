using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isWin = false;
    public CollectManager collectManager;

    // Start is called before the first frame update
    void Start()
    {
        collectManager = FindObjectOfType<CollectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckWinCondition(int score)
    {
        if (score == collectManager.GetStarCount() && !isWin)
        {
            isWin = true;
        }
    }
}
