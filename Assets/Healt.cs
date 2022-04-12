using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Healt : MonoBehaviour
{
    public int hp;

    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        hp -= 2;

        if (hp <= 0)
        {
            Destroy(gameObject);
            gm.score += 10;

        }
    }
}
