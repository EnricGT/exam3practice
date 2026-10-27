using System;
using TMPro;
using UnityEngine;

public class car : MonoBehaviour
{

    public TextMeshProUGUI displayed_text;
    Vector3 speed = Vector3.zero;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        tlight.OnGreen += CarGo;
        tlight.OnYellow += CarPrepare;
        tlight.OnRed += CarStop;
    }

    private void OnDisable()
    {
        tlight.OnGreen -= CarGo;
        tlight.OnYellow -= CarPrepare;
        tlight.OnRed -= CarStop;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime);
    }

    private void CarGo(tlight tlight)
    {
        speed = Vector3.left * 5;
        displayed_text.text = "Go!";
    }

    private void CarPrepare(tlight tlight)
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * 10, ForceMode.Impulse);
        displayed_text.text = "Prepare to go...";
    }

    private void CarStop(tlight tlight)
    {
        speed = Vector3.zero;
        displayed_text.text = "Stop!";
    }

}
