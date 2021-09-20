using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBoomerang : MonoBehaviour
{
    [SerializeField] Transform thrower;
    public float duration;
    [Range(50, 500)]
    public float spinSpeed;
    Coroutine throwCoroutine;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ThrowBoomerang(Vector3 whereToGo)
    {
        throwCoroutine = StartCoroutine(Fly(whereToGo));
    }

    [ContextMenu("Throw To Origin")]
    void ThrowBoomerang()
    {
        throwCoroutine = StartCoroutine(Fly(Vector3.zero));
    }

    IEnumerator Fly(Vector3 whereToGo)
    {
        Vector3 startPos = transform.position;
        float startTime = Time.time;
        transform.LookAt(whereToGo);
        while(Time.time - startTime < duration)
        {
            transform.Rotate(Vector3.right, spinSpeed * Time.deltaTime, Space.Self);
            transform.position = Vector3.Lerp(startPos, whereToGo, (Time.time - startTime) / duration);
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            transform.Rotate(Vector3.left, spinSpeed * Time.deltaTime, Space.Self);
            transform.position = Vector3.Lerp(whereToGo, thrower.transform.position, (Time.time - startTime) / duration);
            yield return null;
        }
    }
}
