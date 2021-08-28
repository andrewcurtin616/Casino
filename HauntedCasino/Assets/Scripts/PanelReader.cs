using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelReader : MonoBehaviour
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
        while (transform.position.z < -1)
        {
            transform.position += Vector3.forward * 0.1f;
            yield return null;
        }
        transform.position = Vector3.up + Vector3.back * 5;
    }
    public void StartRead()
    {
        panel1 = "";
        panel2 = "";
        panel3 = "";
        StartCoroutine("MoveReader");
    }
}
