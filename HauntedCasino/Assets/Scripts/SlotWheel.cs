using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotWheel : MonoBehaviour
{
    [HideInInspector]
    public bool set;
    [HideInInspector]
    public bool stop;
    public float delay;

    public void SpinWheel()
    {
        set = false;
        stop = false;
        StartCoroutine("Roll");
    }
    
    IEnumerator Roll()
    {
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
        
        for (int i = 0; i < 50; i++)
        {
            transform.Rotate(Vector3.left);
            yield return new WaitForSeconds(0.01f);
        }
        while (!stop)
        {
            transform.Rotate(Vector3.left);
            for (int i = 0; i < 360; i += 45)
            {
                if ((int)transform.localEulerAngles.x == i)
                {
                    stop = true;
                    break;
                }
            }
            yield return null;
        }
    }

}
