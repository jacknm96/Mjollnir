using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunWithColor : MonoBehaviour
{
    [SerializeField] Color color;
    [SerializeField] int blue;
    [SerializeField] int green;
    [SerializeField] int red;
    [SerializeField] int alpha;

    // Start is called before the first frame update
    void Start()
    {
        color.r = red;
        color.b = blue;
        color.g = green;
        color.a = alpha;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
