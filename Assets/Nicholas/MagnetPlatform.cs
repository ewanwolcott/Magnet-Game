using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagnetPlatform : MonoBehaviour
{
    public int polarity;
    public float attractionForce = 2f;
    private List<Rigidbody2D> attractedObjects = new List<Rigidbody2D>();

    public void FixedUpdate()
    {
        foreach (Rigidbody2D rb in attractedObjects)
        {
            if (rb != null)
            {
                Vector2 direction = (transform.position - rb.transform.position).normalized;
                rb.AddForce(direction * attractionForce);
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
