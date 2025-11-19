using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagnetPlatform : MonoBehaviour
{
    public int polarity;
    public float attractionForce;
    private List<Rigidbody2D> attractedObjects = new List<Rigidbody2D>();

    public void FixedUpdate()
    {
        foreach (Rigidbody2D rb in attractedObjects)
        {
            if (rb != null)
            {
                Vector2 direction = (transform.position - rb.transform.position);
                float distance = Mathf.Sqrt( Mathf.Pow(2,transform.position.x - rb.transform.position.x) + Mathf.Pow(2, transform.position.y - rb.transform.position.y));
                if (distance >= 0 && distance <= 3) {
                    rb.AddForce(direction * attractionForce * 6);
                }
                else if (distance > 3 && distance <= 5)
                {
                    rb.AddForce(direction * attractionForce * 4);
                }
                else if (distance > 5 && distance <= 7)
                {
                    rb.AddForce(direction * attractionForce * 2);
                }
                else if (distance > 7 && distance <= 9)
                {
                    rb.AddForce(direction * attractionForce);
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb != null && !attractedObjects.Contains(rb))
        {
            attractedObjects.Add(rb);
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                attractedObjects.Remove(rb);
            }
        }
    }
}
