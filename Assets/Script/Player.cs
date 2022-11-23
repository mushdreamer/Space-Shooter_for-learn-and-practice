using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3.5f;
    float getHorizontal;
    float getVertical;
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        getHorizontal = Input.GetAxis("Horizontal");
        getVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * getHorizontal);
        transform.Translate(Vector3.up * Time.deltaTime * speed * getVertical);
    }
}
