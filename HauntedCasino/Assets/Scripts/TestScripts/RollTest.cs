using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTest : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    bool set;
    bool stop;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(100, 300);
        Invoke("LevelSpeed", 0.5f);
        Invoke("AutoStop", 5.25f);
    }

    void FixedUpdate()
    {
        if (!set)
        {
            rb.AddTorque(Vector3.left * Time.deltaTime * speed);
            //Debug.Log(rb.angularVelocity);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                set = true;
                rb.angularDrag *= 5;
                //Debug.Log("set");
            }
        }
        else
        {
            if (rb.angularVelocity.x >= -1f && !stop)
            {
                //Debug.Log("here");
                rb.angularDrag *= 0;
                rb.angularVelocity = Vector3.left;
                stop = true;
                StartCoroutine("SetPanel2");
            }
        }
    }
    void LevelSpeed()
    {
        speed = 100;
    }
    void AutoStop()
    {
        set = true;
        rb.angularDrag *= 5;
        //Debug.Log("AutoStop");
    }
    IEnumerator SetPanel()
    {
        //Debug.Log(transform.localEulerAngles.x);
        float stopAngle = transform.localEulerAngles.x;
        if (stopAngle < 0)
            stopAngle += 360;
        if (stopAngle > 360)
            stopAngle -= 360;
        int whereToStop = (int)(stopAngle + 45 - (stopAngle % 45));
        //Debug.Log("Stop is at:" + whereToStop);
        if (whereToStop >= 360)
            whereToStop = 0;
        

        while (true)
        {
            /*if (transform.localEulerAngles.x >= whereToStop)
            {
                rb.angularVelocity = Vector3.zero;
                break;
            }*/

            if (Mathf.Abs(transform.localEulerAngles.x - whereToStop) < 5)
            {
                rb.angularVelocity = Vector3.zero;
                transform.localEulerAngles = Vector3.right * whereToStop;
                break;
            }

            yield return null;
        }
        Debug.Log("got it");
    }
    IEnumerator SetPanel2()
    {
        float stopAngle = transform.localEulerAngles.x;
        if (stopAngle < 0)
            stopAngle = 360 + stopAngle;
        if (stopAngle > 360)
            stopAngle -= 360;
        bool temp = true;
        while (temp)
        {
            for (float i = 0; i<360; i += 45)
            {
                if (Mathf.Abs(transform.localEulerAngles.x-i) < 1)
                {
                    rb.angularVelocity = Vector3.zero;
                    //transform.localEulerAngles = Vector3.right * i;
                    temp = false;
                    break;
                }
                yield return null;
            }
            yield return null;
        }
        Debug.Log("got it");
    }
    IEnumerator SetPanel3()
    {
        //Debug.Log(transform.localEulerAngles.x);
        float stopAngle = transform.localEulerAngles.x;
        if (stopAngle < 0)
            stopAngle += 360;
        if (stopAngle > 360)
            stopAngle -= 360;
        int whereToStop = (int)(stopAngle + 45 - (stopAngle % 45));
        //Debug.Log("Stop is at:" + whereToStop);
        if (whereToStop >= 360)
            whereToStop = 0;
        if (whereToStop == 0)
            whereToStop = 1;

        Debug.Log(whereToStop);
        rb.angularVelocity = Vector3.zero;
        transform.localEulerAngles = Vector3.left * (int)transform.localEulerAngles.x;
        while (true)
        {
            transform.Rotate(Vector3.left);

            if (Mathf.Abs(transform.localEulerAngles.x) == whereToStop)
            {
                break;
            }

            yield return null;
        }
        Debug.Log("got it");
    }
}
