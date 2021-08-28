using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverPull : MonoBehaviour
{
    public bool ready;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PullLever()
    {
        StartCoroutine("PullDown");
    }

    IEnumerator PullDown()
    {
        for(int i = 1; i<91;i++)
        {
            transform.localEulerAngles = Vector3.right * (340 - i);
            yield return null;
        }
        
        /*rb.angularVelocity = Vector3.left;
        while (transform.localEulerAngles.x > 270)
        {
            yield return null;
        }
        rb.angularVelocity = Vector3.zero;*/
        /*for(int i = 0; i< 100; i++)
        {
            transform.Rotate(Vector3.left*0.7f);
            //transform.Rotate(Vector3.down*0.15f);
            yield return new WaitForSeconds(0.015f);
        }*/
        //transform.localEulerAngles = Vector3.up * 5 + Vector3.right * 270;
        //transform.localEulerAngles = Vector3.right * 270;

        yield return new WaitForSeconds(0.25f);
        ready = true;
        for (int i = 1; i < 91; i++)
        {
            transform.localEulerAngles = Vector3.right * (250 + i);
            yield return null;
        }

        //rb.angularVelocity = Vector3.right;

        /*while (transform.localEulerAngles.x < 340)
        {
            yield return null;
        }
        rb.angularVelocity = Vector3.zero;*/
        /*for (int i = 0; i < 10; i++)
        {
            transform.Rotate(Vector3.right*7);
            //transform.Rotate(Vector3.down*0.15f);
            yield return new WaitForSeconds(0.1f);
        }*/
    }
}
