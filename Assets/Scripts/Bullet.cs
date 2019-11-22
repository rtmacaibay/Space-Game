using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string shooter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion q = new Quaternion(0, 0, 0, 0);
        transform.rotation = q;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals(shooter))
        {
            Physics2D.IgnoreCollision(collision.collider, collision.otherCollider);
        }
        else if (collision.gameObject.tag.Equals("Wall"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.tag.Equals("Bullet"))
        {
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
        else
        {
            if (collision.gameObject.GetComponent<Ship>().canDie)
            {
                collision.gameObject.GetComponent<Ship>().canDie = false;
                collision.gameObject.SetActive(false);
            }
            Destroy(this.gameObject);
        }
    }
}
