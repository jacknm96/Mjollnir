using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavyBullet : MonoBehaviour
{
    Vector3 startPoint;
    Vector3 startDirection;
    float speed = 20;
    public bool con = true;
    [SerializeField] CurveReference curveRef;

    
    // Start is called before the first frame update
    void Start()
    {
        startPoint = transform.position;
        startDirection = transform.forward;
        StartCoroutine(BulletWave());
    }

    IEnumerator BulletWave()
    {
        float startTime = Time.time;
        while(con)
        {
            transform.position = startPoint + (startDirection * (Time.time - startTime)) * speed;
            transform.position += transform.right * curveRef.curve.Evaluate(Time.time - startTime);
            yield return null;
        }
    }
}
