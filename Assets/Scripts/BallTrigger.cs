using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrigger : MonoBehaviour
{
    [SerializeField] GameObject containerPrefab;

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag != "Ball") return;

        if(containerPrefab != null)
            GameManager.instance.AddToTotalCount();
        else
            GameManager.instance.AddToAreaCount();
    }
}
