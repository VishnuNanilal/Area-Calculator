using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    
    public int totalCount{get; private set;}
    public int areaCount{get; private set;}

    private void Awake() {
        if(instance == null)
            instance = this;

        totalCount = 0;
        areaCount = 0;
        
        DontDestroyOnLoad(gameObject);
    }

    public void AddToTotal()
    {
        totalCount++;
    }

    public void AddToArea()
    {
        areaCount++;
    }

    public void ResetCount()
    {
        totalCount = 0;
        areaCount = 0;
    }
}
