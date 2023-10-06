using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody rb;
    GameManager gameManager;
    public int pointValue;
    public ParticleSystem explostionParticle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(RandomForce(), ForceMode.Impulse);
        rb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explostionParticle, transform.position, explostionParticle.transform.rotation);
        gameManager.AddScore(pointValue);
    }

    void OnTriggerEnter()
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }

    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(12, 16);
    }

    float RandomTorque()
    {
        return Random.Range(-10, 10);
    }
}
