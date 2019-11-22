using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject orig_bullet;
    public GameObject player1;
    public GameObject player2;
    private int direction;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag.Equals("Player1"))
        {
            direction = 1;
        }
        if (gameObject.tag.Equals("Player2"))
        {
            direction = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag.Equals("Player1"))
        {
            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                GameObject bullet = CreateBullet();
                bullet.GetComponent<Bullet>().shooter = "Player1";
            }
        }
        if (gameObject.tag.Equals("Player2"))
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Joystick2Button1))
            {
                GameObject bullet = CreateBullet();
                bullet.GetComponent<Bullet>().shooter = "Player2";
            }
        }
    }

    private GameObject CreateBullet()
    {
        GameObject bullet = Instantiate(orig_bullet);
        bullet.transform.position = new Vector3(transform.position.x, transform.position.y + (1 * direction), transform.position.z);
        if (direction == 1)
        {
            bullet.transform.LookAt(Vector2.up);
            bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x, 0, 0); // lock x and z axis to zero
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward * 400);
        } else
        {
            bullet.transform.LookAt(Vector2.down);
            bullet.transform.eulerAngles = new Vector3(bullet.transform.eulerAngles.x, 0, 0); // lock x and z axis to zero
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.forward * 400);
        }
        return bullet;
    }
}
