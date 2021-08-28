using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotMachine1 : MonoBehaviour
{
    bool readyToPlay;
    bool readyToStop;
    LeverPull lever;
    SlotWheel wheel1;
    SlotWheel wheel2;
    SlotWheel wheel3;
    PanelReader panelReader;
    GameObject readyButton;

    // Start is called before the first frame update
    void Start()
    {
        lever = FindObjectOfType<LeverPull>();
        wheel1 = GameObject.Find("Wheel1").GetComponent<SlotWheel>();
        wheel2 = GameObject.Find("Wheel2").GetComponent<SlotWheel>();
        wheel3 = GameObject.Find("Wheel3").GetComponent<SlotWheel>();
        panelReader = FindObjectOfType<PanelReader>();
        readyToPlay = true;
        readyButton = GameObject.Find("ReadyButton");
        readyButton.transform.position = Vector3.down * 5.5f + Vector3.back * 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (readyToPlay)
            {
                lever.PullLever();
                readyToPlay = false;
                StartCoroutine("SpinReady");
            }

            if (readyToStop)
            {
                readyButton.transform.position = Vector3.down * 5.5f + Vector3.back * 1.5f;
                readyToStop = false;
                StartCoroutine("StopWheels");
            }
        }
    }

    IEnumerator SpinReady()
    {
        while (!lever.ready)
        {
            yield return null;
        }
        lever.ready = false;
        wheel1.SpinWheel();
        yield return new WaitForSeconds(0.5f);//wheel2delay time
        wheel2.SpinWheel();
        yield return new WaitForSeconds(0.5f);//wheel3delay time
        wheel3.SpinWheel();
        yield return new WaitForSeconds(2.5f);//time for spin
        readyButton.transform.position = Vector3.down * 5 + Vector3.back * 2;
        //make noise
        yield return new WaitForSeconds(0.5f);
        readyToStop = true;
    }

    IEnumerator StopWheels()
    {
        wheel1.set = true;
        while (!wheel1.stop)
        {
            yield return null;
        }
        yield return new WaitForSeconds(0.3f);
        wheel2.set = true;
        while (!wheel2.stop)
        {
            yield return null;//wheel2
        }
        yield return new WaitForSeconds(0.3f);
        wheel3.set = true;
        while (!wheel3.stop)
        {
            yield return null;//wheel3
        }
        yield return new WaitForSeconds(0.1f);
        panelReader.StartRead();

        yield return new WaitForSeconds(1f);
        readyToPlay = true;
    }
}
