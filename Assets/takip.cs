using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takip : MonoBehaviour
{
    public Transform kameraTakip;
    Vector3 fark;
    // Start is called before the first frame update
    void Start()
    {
        fark=transform.position - kameraTakip.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, kameraTakip.position+fark, Time.deltaTime * 3.0f);   
    }
}
