using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BallEmitter : MonoBehaviour
{
    [SerializeField] GameObject emitPrefab = null;
    [SerializeField] float emitArea = 0f;
    [SerializeField] float maxPositionChangeSpeed = 1f;
    [SerializeField] float emitDelay = 0f;
    float maxAllowedBalls = 1500;

    bool isRunning = false;
    float positionChangeSpeed = 0f;
    AudioSource audioSource;

    //UI
    [SerializeField] GameObject sliderPrefab;
    Slider speedSlider;

    private void Awake() {
        speedSlider = sliderPrefab.GetComponent<Slider>();  
        audioSource = GetComponent<AudioSource>();
    }

    private void Update() {
        if(GameManager.instance.GetTotalCount() > maxAllowedBalls)
            StopSystem();
    }

    private void FixedUpdate() 
    {
        positionChangeSpeed = speedSlider.value * maxPositionChangeSpeed;
    }

    public void StartSystem()
    {
        if(isRunning) return;
        StartCoroutine(StartEmission());
        isRunning = true;
    }

    public void StopSystem()
    {
        StopAllCoroutines();
        isRunning = false;
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
            audioSource.Play();
            ball.GetComponent<Renderer>().material.color = Color.white;
            //ball.GetComponent<Renderer>().material.color = new Color(RandomX, Random.Range(-emitArea, emitArea), RandomZ);
        }
    }
}
