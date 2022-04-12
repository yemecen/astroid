using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Joystick joystick;
    public int speed;
    public Transform firePoint;
    public GameObject Bullet;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 2, 5);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(string.Format("Horizantal: {0} - Vertical: {1}", joystick.Horizontal, joystick.Vertical));

        transform.Translate(new Vector3(joystick.Horizontal * speed * Time.deltaTime, joystick.Vertical * speed * Time.deltaTime, speed * Time.deltaTime));

        if (Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(Bullet, firePoint.position, firePoint.rotation);
    }

    void CreateEnemy()
    {
        int rnd = Random.Range(5, 10);
        Instantiate(enemy, new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z + rnd), firePoint.rotation);
    }
}
