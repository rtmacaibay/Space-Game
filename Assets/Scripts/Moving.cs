using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed = 5f;
    private float y;
    private Quaternion q;
    // Start is called before the first frame update
    void Start()
    {
        y = transform.position.y;
        q = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    { 
        transform.rotation = q;
        Vector3 v = transform.position;
        v.y = y;
        transform.position = v;
        if (gameObject.tag.Equals("Player1"))
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Joystick1Button4))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Joystick1Button5))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }
        if (gameObject.tag.Equals("Player2"))
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Joystick2Button5))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Joystick2Button4))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
        }
    }
}
