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
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (other.CompareTag("kart") || other.CompareTag("kart2")) {
            
            print("si reconozco");
            StartCoroutine(Mas(rb));
            rb.isKinematic = false;
            Destroy(gameObject);
        }
    }
    IEnumerator Mas(Rigidbody rb) { 
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;
        yield return new WaitForSeconds(7);
    }
}
