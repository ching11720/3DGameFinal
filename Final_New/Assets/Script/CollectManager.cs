using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectManager : MonoBehaviour
{
    private GameObject[] stars;

    // Start is called before the first frame update
    void Start()
    {
        countStar();
    }

    // Update is called once per frame
    void Update()
    {
        countStar();
    }

    private void countStar()
    {
        stars = GameObject.FindGameObjectsWithTag("Star");
        Debug.Log("Current Star Count: " + stars.Length);
    }

    public int GetStarCount()
    {
        return stars.Length;
    }
}
