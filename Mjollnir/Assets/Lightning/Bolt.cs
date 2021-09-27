using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    [SerializeField] LineRenderer line;
    RaycastHit hit;
    public float maxDistance = 100f;
    [SerializeField] Vector3 errorRange;
    [SerializeField] float segmentLength = 2f;
    [SerializeField] int segments = 13;
    [SerializeField] float closeEnough = 0.1f;
    [SerializeField] Bolt boltSplinter;
    [SerializeField] [Range(0, 100)] float splinterProbability;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    [ContextMenu("Zap")]
    void Zap()
    {
        line.positionCount = segments;
        Vector3 pos = transform.position;
        Vector3 endPoint;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, maxDistance))
        {
            endPoint = hit.point;
        }
        else
        {
            endPoint = transform.up * maxDistance;
        }
        line.SetPosition(0, pos);
        for (int i = 1; i < segments; i++)
        {
            pos += (Vector3.down + new Vector3(Random.Range(-errorRange.x, errorRange.x), Random.Range(-errorRange.y, errorRange.y), Random.Range(-errorRange.z, errorRange.z))) * segmentLength;
            if (Vector3.Distance(pos, endPoint) <= closeEnough)
            {
                pos = endPoint;
                line.SetPosition(i, pos);
                line.positionCount = i;
                break;
            }
            line.SetPosition(i, pos);
            if (Random.Range(0, 100) <= splinterProbability)
            {
                Splinter(pos, pos + Vector3.down * maxDistance * Random.Range(.1f, 1f));
            }
        }
        line.SetPosition(segments, endPoint);
        StartCoroutine(BoltFadeOut(this));
    }

    void Splinter(Vector3 splinterPoint, Vector3 endSplinter)
    {
        Instantiate(boltSplinter).SplinterZap(splinterPoint, endSplinter);
    }

    public void SplinterZap(Vector3 startPoint, Vector3 finalPoint)
    {
        line.positionCount = segments;
        Vector3 pos = startPoint;
        line.SetPosition(0, pos);
        for (int i = 1; i < segments; i++)
        {
            pos += (Vector3.down + new Vector3(Random.Range(-errorRange.x, errorRange.x), Random.Range(-errorRange.y, errorRange.y), Random.Range(-errorRange.z, errorRange.z))) * segmentLength;
            if (Vector3.Distance(pos, finalPoint) <= closeEnough)
            {
                pos = finalPoint;
                line.SetPosition(i, pos);
                line.positionCount = i;
                break;
            }
            line.SetPosition(i, pos);
        }
        line.SetPosition(segments, finalPoint);
        StartCoroutine(BoltFadeOut(boltSplinter));
    }

    IEnumerator BoltFadeOut(Bolt bolt)
    {
        yield return new WaitForSeconds(2f);
        float startTime = Time.time;
        Renderer r = bolt.GetComponent<Renderer>();
        Color transparency = r.material.color;
        while (Time.time - startTime < 2f)
        {
            transparency.a = Mathf.Lerp(1, 0, (Time.time - startTime) / 2);
            yield return null;
        }
        gameObject.SetActive(false);
    }
}
