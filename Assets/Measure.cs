using UnityEngine;
using UnityEngine.UI;

public class Measure : MonoBehaviour
{
    [SerializeField] Text text;

    private void Update()
    {
        text.text = GetComponent<RectTransform>().sizeDelta.y.ToString();
    }
}
