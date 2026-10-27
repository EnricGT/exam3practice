using UnityEngine;

public class game_manager : MonoBehaviour
{

    public GameObject water;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("spawnWater", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnWater()
    {
        Vector3 posicio_water = new Vector3(Random.Range(-20, 20), 30, Random.Range(-20, 20));
        GameObject new_instance = Instantiate(water, posicio_water, Quaternion.identity);
        Destroy(new_instance, 4f);
    }

}
