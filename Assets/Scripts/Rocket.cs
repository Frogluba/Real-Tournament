using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public float speed = 20;
    public GameObject explosionPrefab;
    public GameObject hitPrefab;
    public int bounces;
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
        //Destroy(gameObject);
        if (bounces == 0)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.forward = collision.contacts[0].normal;
        }
        if (!collision.gameObject.CompareTag("Enemy"))
        {
            var obj = Instantiate(hitPrefab, transform.position, transform.rotation);
            obj.transform.forward = collision.contacts[0].normal;
            obj.transform.position = collision.contacts[0].point + transform.forward * 0.05f;
           
        }
        bounces--;

        var health = collision.gameObject.GetComponent<Healt>();
        if (health != null)
        {
            health.Damage(10);
        }

        Instantiate(explosionPrefab, transform.position, transform.rotation);
    }
}
