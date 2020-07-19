using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public float timer;
    public float max_time;
    public float height;
    public GameObject pipe;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if ( timer > max_time )
        {
            GameObject new_pipe = Instantiate(pipe);
            new_pipe.transform.position += new Vector3(0, Random.Range( -height , height));
            Destroy(new_pipe, 3);
            timer = 0;
        }
        timer += Time.deltaTime;
    }
}
