using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FRI
public class Enemy : MonoBehaviour
{
    public GameObject bulletPrefab;
    Vector3 bulletOffset = new Vector3(1f, 0, 0);
    float counter;

    // setting up quaternion variables for the rotations
    Quaternion rotUp = Quaternion.identity;
    Quaternion rotDown = Quaternion.identity;
    Quaternion rotLeft = Quaternion.identity;
    Quaternion rotRight = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        counter = 1f;

        rotUp.eulerAngles = new Vector3(0, -90f, 0);
        rotDown.eulerAngles = new Vector3(0, 90f, 0);
        rotLeft.eulerAngles = new Vector3(0, 180f, 0);
        rotRight.eulerAngles = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void Update()
    {
        if (counter <= 0)
        {
            counter = 1f;
        }
        counter -= Time.deltaTime;

        if (counter < 0)
        {
            //top
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 0, 1f), rotUp);
            //rot.eulerAngles = rot.eulerAngles + new Vector3(0, -90, 0); // not redefining varible?
            //left
            Instantiate(bulletPrefab, transform.position + new Vector3(-1f, 0, 0), rotLeft);
            //rot.eulerAngles = rot.eulerAngles + new Vector3(0, -90, 0);
            //right 
            Instantiate(bulletPrefab, transform.position + new Vector3(1f, 0, 0), rotRight);
            //down
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 0, -1f), rotDown);
        }

    }
}
