using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform cameraFollow;
    Vector3 distant;
    // Start is called before the first frame update
    void Start()
    {
        distant = transform.position - cameraFollow.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cameraFollow.position+ distant, Time.deltaTime * 3.0f);   
    }
}
