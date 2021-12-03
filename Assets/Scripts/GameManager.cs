using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    
    int totalCount = 0;
    int areaCount = 0;

    private void Awake() {
        if(instance == null)
            instance = this;

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
