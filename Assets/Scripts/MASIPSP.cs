using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MASIPSP : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kart")) {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            print("si reconozco");
            for (int i = 0; i <= 15; i++) { 
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }
            Destroy(gameObject);
        }
    }
}
