using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acelerador : MonoBehaviour
{
    public Rigidbody krtdb;
    // Start is called before the first frame update
    void Start()
    {
        krtdb = krtdb.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("kart")||other.CompareTag("kart2"))
        {
            Vector3 direccion = krtdb.velocity.normalized;
            krtdb.AddForce(direccion *5f, ForceMode.Impulse);
        }
        
    }
}
