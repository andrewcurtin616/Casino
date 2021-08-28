using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelReaderTest : MonoBehaviour
{
    string panel1;
    string panel2;
    string panel3;
    RollTest2[] rollers;

    // Start is called before the first frame update
    void Start()
    {
        panel1 = "";
        panel2 = "";
        panel3 = "";
        rollers = FindObjectsOfType<RollTest2>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space) & panel1=="")
        {
            StartCoroutine("MoveReader");
        }*/
        if (rollers[0].stop && rollers[1].stop && rollers[2].stop)
        {
            rollers[0].stop = false;//prevents repeat fires
            StartRead();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (panel1 == "")
            panel1 = other.gameObject.GetComponent<MeshRenderer>().material.name;
        else if (panel2 == "")
            panel2 = other.gameObject.GetComponent<MeshRenderer>().material.name;
        else
        {
            panel3 = other.gameObject.GetComponent<MeshRenderer>().material.name;
            Debug.Log(panel1 + ":" + panel2 + ":" + panel3);
        }
    }

    IEnumerator MoveReader()
    {
        while(transform.position.z < -1)
        {
            transform.position += Vector3.forward * 0.1f;
            yield return null;
        }
        transform.position = Vector3.up + Vector3.back * 5;
        panel1 = "";
        panel2 = "";
        panel3 = "";
    }
    void StartRead()
    {
        StartCoroutine("MoveReader");
    }
}
