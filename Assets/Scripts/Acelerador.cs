using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerador : MonoBehaviour
{
    public GameObject kart;
    Rigidbody krtdb;
    // Start is called before the first frame update
    void Start()
    {
        krtdb = kart.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (kart.CompareTag("kart"))
        {
            Vector3 direccion = krtdb.velocity.normalized;
            krtdb.AddForce(direccion *10, ForceMode.Impulse);
        }
        
    }
}
