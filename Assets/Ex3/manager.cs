using UnityEngine;

public class manager : MonoBehaviour
{

    public int num_of_boxes = 10;
    public float space_between = 1;
    public GameObject box;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < num_of_boxes / 2; i++)
        {
            for (int j = 0; j < num_of_boxes / 2; j++)
            {
                Vector3 pos = new Vector3(i * space_between, 1 + j * space_between, 0);
                Instantiate(box, pos, Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
