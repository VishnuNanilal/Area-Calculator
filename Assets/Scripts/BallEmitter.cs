using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallEmitter : MonoBehaviour
{
    [SerializeField] GameObject emitPrefab = null;
    [SerializeField] float emitArea = 0f;
    [SerializeField] float maxPositionChangeSpeed = 1f;
    [SerializeField] float emitDelay = 0f;

    float positionChangeSpeed = 0f;

    //UI
    [SerializeField] GameObject sliderPrefab;
    Slider speedSlider;

    private void Awake() {
        speedSlider = sliderPrefab.GetComponent<Slider>();  
    }

    private void Update() 
    {
        positionChangeSpeed = speedSlider.value * maxPositionChangeSpeed;
    }

    public void StartSystem()
    {
        StartCoroutine(StartEmission());
    }

    public void StopSystem()
    {
        StopAllCoroutines();
    }

    private IEnumerator StartEmission()
    {
        float RandomX;
        float RandomZ;

        while(true)
        {
            if(positionChangeSpeed == 0) yield return null;

            RandomX = Random.Range(-emitArea, emitArea);
            RandomZ = Random.Range(-emitArea, emitArea);
            Vector3 newPosition = new Vector3(RandomX, transform.position.y, RandomZ);
            

            yield return new WaitForSeconds(1/positionChangeSpeed); // As we increase speed, the time for the next position change decreases.
            transform.position = newPosition;
            yield return new WaitForSeconds(emitDelay);
            GameObject ball = Instantiate(emitPrefab, newPosition, Quaternion.identity);
            ball.GetComponent<Renderer>().material.color = Color.white;
            //ball.GetComponent<Renderer>().material.color = new Color(RandomX, Random.Range(-emitArea, emitArea), RandomZ);
        }
    }
}
