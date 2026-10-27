using System;
using System.Collections.Generic;
using UnityEngine;

public class tlight : MonoBehaviour
{

    public float repeating_time = 3f;
    private int current_light = 0;
    public GameObject[] tlights;
    static public Action<tlight> OnRed, OnYellow, OnGreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        InvokeRepeating(nameof(Illluminate), 0f, repeating_time);
    }

    private void Illluminate()
    {

        if (current_light == 0) // red -> yellow
        {
            tlights[0].GetComponent<Renderer>().material.color = Color.black;
            tlights[1].GetComponent<Renderer>().material.color = Color.yellow;
            tlights[2].GetComponent<Renderer>().material.color = Color.black;

            turnedYellow();
        }
        else if (current_light == 1) // yellow -> green
        {
            tlights[0].GetComponent<Renderer>().material.color = Color.black;
            tlights[1].GetComponent<Renderer>().material.color = Color.black;
            tlights[2].GetComponent<Renderer>().material.color = Color.green;

            turnedGreen();
        }
        else if (current_light == 2) // green -> red
        {
            tlights[0].GetComponent<Renderer>().material.color = Color.red;
            tlights[1].GetComponent<Renderer>().material.color = Color.black;
            tlights[2].GetComponent<Renderer>().material.color = Color.black;

            turnedRed();
        }

        current_light++;
        if (current_light > 2) current_light = 0;
    }

    private void turnedRed()
    {
        OnRed?.Invoke(this);
    }

    private void turnedYellow()
    {
        OnYellow?.Invoke(this);
    }

    private void turnedGreen()
    {
        OnGreen?.Invoke(this);
    }

}
