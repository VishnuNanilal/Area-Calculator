using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] protected GameObject[] shapes;
    [SerializeField] float baseBoxSize = 2f;
    
    private int totalCount;
    private int areaCount;

    float baseBoxArea;

    private void Awake() {
        if(instance!= null) 
        {
            print("trying multiple instantiation");
            return;
        }
        else
        {
            instance = this;
        }
        totalCount = 0;
        areaCount = 0;
        baseBoxArea = baseBoxSize*baseBoxSize;

        DontDestroyOnLoad(gameObject);
    }

    public void AddToTotalCount()
    {
        totalCount = totalCount + 1;
    }

    public void AddToAreaCount()
    {
        areaCount = areaCount + 1;
    }

    public void ResetCount()
    {
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");

        foreach(GameObject ball in balls)
            Destroy(ball.gameObject);

        totalCount = 0;
        areaCount = 0;
        FindObjectOfType<BallEmitter>().StopSystem();
    }

    public int GetTotalCount()
    {
        return totalCount;
    }

    public int GetAreaCount()
    {
        return areaCount;
    }

    public double GetArea()
    {
        if(totalCount == 0) return 0f;

        float ratio = (float)areaCount / totalCount;
        return ratio*baseBoxArea;
    }
    
    private void Update() 
    {
        //print(areaCount);
        //print(totalCount);
    }
}
