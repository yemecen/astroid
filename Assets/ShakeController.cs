using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeController : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float shakePower;
    [SerializeField] private float shakeDuration;
    [SerializeField] private float downAmount;
    [SerializeField] public bool isShake = false;

    private Vector3 startPos;
    private float initialDuration;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform;
        startPos = cam.localPosition;
        initialDuration = shakeDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (isShake)
        {
            if (shakeDuration > 0)
            {
                cam.localPosition = new Vector3(cam.localPosition.x + Random.onUnitSphere.x * shakePower, Camera.main.transform.position.y, Camera.main.transform.position.z);// startPos + Random.onUnitSphere * shakePower;
                shakeDuration -= downAmount * Time.deltaTime;

            }
            else
            {
                isShake = false;
                cam.localPosition = cam.localPosition;
                shakeDuration = initialDuration;
            }
        }
    }
}
