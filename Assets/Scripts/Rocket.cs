using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 20;
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime ;

    }

     void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        var health = collision.gameObject.GetComponent<Healt>();
        if (health != null)
        {
            health.Damage(10);
        }

        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
}
