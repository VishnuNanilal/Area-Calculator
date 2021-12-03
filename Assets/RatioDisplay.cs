using UnityEngine;
using UnityEngine.UI;

public class RatioDisplay : MonoBehaviour
{
    [SerializeField] Text text;

    private void Update() 
    {
        text.text = GameManager.instance.GetAreaCount() + " / "+ GameManager.instance.GetTotalCount();
    }
}