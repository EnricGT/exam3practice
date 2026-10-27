using UnityEngine;

public class game_manager : MonoBehaviour
{

    public GameObject water;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InvokeRepeating("spawnWater", 0f, 2f);
    }

    void spawnWater()
    {
        Vector3 posicio_water = new Vector3(Random.Range(-10, 10), 10, Random.Range(-10, 10));
        GameObject new_instance = Instantiate(water, posicio_water, Quaternion.identity);
    }
}
