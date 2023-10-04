using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        //transform.position = SpawnPos();
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter()
    {
        Destroy(gameObject);
    }

    Vector3 RandomForce()
    {
        return Vector3.up* Random.Range(12, 16);
    }

    float RandomTorque()
    {
        return Random.Range(-10, 10);
    }
}
