using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//FRI
public class EnemyAimBot : MonoBehaviour
{
    public GameObject bulletPrefab;
    Vector3 bulletOffset = new Vector3(1f, 0, 0);
    float counter;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        counter = 1f;

    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player.transform.position, Vector3.up);

        if (counter <= 0)
        {
            counter = 1f;
        }
        counter -= Time.deltaTime;

        if (counter < 0)
        {
            Instantiate(bulletPrefab, transform.position + bulletOffset, transform.rotation);
        }

    }
}
