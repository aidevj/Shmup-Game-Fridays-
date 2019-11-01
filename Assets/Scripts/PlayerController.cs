using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//FRI 2pm Class
public class PlayerController : MonoBehaviour
{
    public float speed = 0.5f;
    public GameObject bulletPrefab;
    Vector3 bulletOffset = new Vector3(2f, 0, 0);
    float counter;

    float state = 0; // State 0 = fleeing; State 1 = attacking

    // For mouse follow
    float cameraDif;


    // Start is called before the first frame update
    void Start()
    {
        counter = 0.5f;

        cameraDif = Camera.main.transform.position.y - transform.position.y;

        // if (playerslevel > 3)
            // set state = 0

    }

    // Update is called once per frame
    void Update()
    {




        if (state == 0)
        {
            // dont fire bullets and walk away from player
            Debug.Log("in state 0");
        }
        if (state == 1)
        {
            // aim at player and fire bullets
        }

        if (counter <= 0)
        {
            counter = 1f;
        }
        counter -= Time.deltaTime;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, cameraDif));
        Vector3 lookDir = new Vector3(mousePos.x, transform.position.y, mousePos.z);

        transform.LookAt(lookDir);


        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, speed, Space.World);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -speed, Space.World);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-speed, 0, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(speed, 0, 0, Space.World);
        }
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if (counter < 0)
            {
                //GameObject currentBullet = Instantiate(bulletPrefab, transform.position + bulletOffset, transform.rotation);
                Instantiate(bulletPrefab, transform.position + bulletOffset, bulletPrefab.transform.rotation);
                //CapsuleCollider b = currentBullet.GetComponent<CapsuleCollider>();
                //b.enabled = false;
            }
            
        }
    }

    void OnCollisionEnter(Collision other)
    {
        //Debug.Log("hit testing");
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
        if (other.gameObject.name == "Bullet (clone)")
        {
            Destroy(gameObject);
        }
    }

}
