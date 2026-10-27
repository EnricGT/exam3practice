using TMPro;
using UnityEngine;

public class water_detection : MonoBehaviour
{

    public TextMeshProUGUI text;
    int water_fallen = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        water_fallen++;
        text.text = water_fallen.ToString();
        Destroy(other.gameObject);
    }

}
