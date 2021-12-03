using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreaDisplay : MonoBehaviour
{
    [SerializeField] Text text;

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.instance.GetArea().ToString("#0.00");
    }
}
