using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollTest2 : MonoBehaviour
{
    bool set;
    [HideInInspector]
    public bool stop;
    public float delay;

    // Start is called before the first frame update
    void Start()
    {
        //Invoke("SetPanel",5f);
        //StartCoroutine("Roll");
        InvokeRepeating("RollAgain", 1,15f);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SetPanel()
    {
        set = true;
    }

    IEnumerator Roll()
    {
        yield return new WaitForSeconds(delay);
        Invoke("SetPanel", 8f);
        for (float i = 0; i < 3; i += 0.1f)
        {
            transform.Rotate(Vector3.left * i);
            yield return new WaitForSeconds(0.05f);
        }

        while (!set)
        {
            transform.Rotate(Vector3.left * 3);
            yield return null;
        }

        for (float i = 3; i > 1; i -= 0.1f)
        {
            transform.Rotate(Vector3.left * i);
            yield return new WaitForSeconds(0.025f);
        }

        //Debug.Log("Angel: "+transform.localEulerAngles.x);
        //int temp = transform.localEulerAngles.x >= 0 ? (int)transform.localEulerAngles.x : 360+(int)transform.localEulerAngles.x;
        //transform.localEulerAngles = Vector3.right * (int)transform.localEulerAngles.x;
        //Debug.Log("New: " + temp);
        //transform.localEulerAngles = Vector3.right * temp;
        for(int i = 0; i< 50; i++)
        {
            transform.Rotate(Vector3.left);
            yield return new WaitForSeconds(0.01f);
        }
        while (!stop)
        {
            transform.Rotate(Vector3.left);
            for (int i = 0; i < 360; i += 45)
            {
                if((int)transform.localEulerAngles.x == i)
                {
                    stop = true;
                    break;
                }
            }
            yield return null;
        }
    }
    void RollAgain()
    {
        set = false;
        stop = false;
        StartCoroutine("Roll");
    }
}
