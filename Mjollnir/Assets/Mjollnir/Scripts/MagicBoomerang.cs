using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBoomerang : MonoBehaviour
{
    [SerializeField] Transform thrower;
    public List<EnemyBase> targets = new List<EnemyBase>();
    public float duration;
    [Range(50, 500)]
    public float spinSpeed;
    Coroutine throwCoroutine;
    RaycastHit hit;
    Ray ray;
    public bool running = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            StartCoroutine(ChainAttack());
        }
    }

    IEnumerator ChainAttack()
    {
        while (Stamina.currentStamina > 0)
        {
            Stamina.ReduceStamina();
            ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            if (Physics.Raycast(ray, out hit, 50f))
            {
                if (hit.collider.gameObject.GetComponent<EnemyBase>() && !targets.Contains(hit.collider.gameObject.GetComponent<EnemyBase>()))
                {
                    Debug.Log("Enemy Found");
                    targets.Add(hit.collider.gameObject.GetComponent<EnemyBase>());
                }
            }
            yield return null;
        }
        if (targets.Count > 0)
        {
            Debug.Log("Throwing Hammer");
            StartCoroutine(ChainFly());
        }
    }

    IEnumerator ChainFly()
    {
        running = true;
        Vector3 startPos = transform.position;
        float startTime = Time.time;
        for (int i = 0; i < targets.Count; i++)
        {
            transform.LookAt(targets[i].transform.position);
            while (Time.time - startTime < duration)
            {
                transform.Rotate(Vector3.right, spinSpeed * Time.deltaTime, Space.Self);
                transform.position = Vector3.Lerp(startPos, targets[i].transform.position, (Time.time - startTime) / duration);
                yield return null;
            }
            startTime = Time.time;
            startPos = targets[i].transform.position;
        }
        
        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            transform.Rotate(Vector3.left, spinSpeed * Time.deltaTime, Space.Self);
            transform.position = Vector3.Lerp(startPos, thrower.transform.position, (Time.time - startTime) / duration);
            yield return null;
        }
        targets.Clear();
        running = false;
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
        running = true;
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
        running = false;
    }

    IEnumerator Fly(Transform target)
    {
        running = true;
        Vector3 startPos = transform.position;
        float startTime = Time.time;
        transform.LookAt(target.position);
        while (Time.time - startTime < duration)
        {
            transform.Rotate(Vector3.right, spinSpeed * Time.deltaTime, Space.Self);
            transform.position = Vector3.Lerp(startPos, target.position, (Time.time - startTime) / duration);
            yield return null;
        }
        startTime = Time.time;
        while (Time.time - startTime < duration)
        {
            transform.Rotate(Vector3.left, spinSpeed * Time.deltaTime, Space.Self);
            transform.position = Vector3.Lerp(target.position, thrower.transform.position, (Time.time - startTime) / duration);
            yield return null;
        }
        running = false;
    }
}
