using System.Collections;
using UnityEngine;

public class BallEmitter : MonoBehaviour
{
    [SerializeField] GameObject emitPrefab = null;
    [SerializeField] float emitArea = 0f;
    [SerializeField] float positionChangeSpeed = 0f;
    [SerializeField] float emitDelay = 0f;

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
            RandomX = Random.Range(-emitArea, emitArea);
            RandomZ = Random.Range(-emitArea, emitArea);
            Vector3 newPosition = new Vector3(RandomX, transform.position.y, RandomZ);

            yield return new WaitForSeconds(1/positionChangeSpeed); // As we increase speed, the time for the next position change decreases.
            transform.position = newPosition;
            yield return new WaitForSeconds(emitDelay);
            Instantiate(emitPrefab, newPosition, Quaternion.identity);
        }
    }
}
