using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Move : MonoBehaviour
{
    public Joystick joystick;
    public int speed;
    public Transform firePoint;
    public GameObject Bullet;
    public GameObject enemy;
    public Image healthBar;
    public int initHealth;
    public int health;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 2, 5);
        initHealth = health;
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

        healthBar.fillAmount = (float)health / (float)initHealth;
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            ShakeController sk = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ShakeController>();
            sk.isShake = true;

            health -= 1;
            if (health <= 0)
            {
                panel.SetActive(true);
                //panel.transform.GetChild(0).gameObject.SetActive(true);child varsa
                sk.isShake = false;
                Time.timeScale=0.0f;
            }
        }
    }
}
