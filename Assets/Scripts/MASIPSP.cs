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
        karControllerv2 kart = other.GetComponent<karControllerv2>();
        karControllerv3 kart2 = other.GetComponent<karControllerv3>();
        if ((other.CompareTag("kart") || other.CompareTag("kart2")) && (!kart.invulnerable || !kart2.invulnerable)) {
            
            print("si reconozco");
            Rigidbody rb = other.GetComponent<Rigidbody>();
            StartCoroutine(Mas(rb));
            Destroy(gameObject);
        }
    }
    IEnumerator Mas(Rigidbody rb) { 
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.isKinematic = true;

        yield return new WaitForSeconds(10f);

        rb.isKinematic = false;
    }
}
