using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class MagnetPlatform : MonoBehaviour
{
    public int polarity;
    public float attractionForce;
    private List<Playermovement> attractedObjects = new List<Playermovement>();

    public void FixedUpdate()
    {
        foreach (Playermovement pm in attractedObjects)
        {
            if (pm != null)
            {
                Rigidbody2D rb = pm.rb;
                Vector2 direction = (transform.position - rb.transform.position);
                float distance = Mathf.Sqrt( Mathf.Pow(2,transform.position.x - rb.transform.position.x) + Mathf.Pow(2, transform.position.y - rb.transform.position.y));
                if (distance >= 0 && distance <= 3) {
                    rb.AddForce(direction * attractionForce * 6 * pm.polarity);
                }
                else if (distance > 3 && distance <= 5)
                {
                    rb.AddForce(direction * attractionForce * 4 * pm.polarity);
                }
                else if (distance > 5 && distance <= 7)
                {
                    rb.AddForce(direction * attractionForce * 2 * pm.polarity);
                }
                else if (distance > 7 && distance <= 9)
                {
                    rb.AddForce(direction * attractionForce * pm.polarity);
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Playermovement pm = collision.GetComponent<Playermovement>();
        if (pm != null && !attractedObjects.Contains(pm))
        {
            attractedObjects.Add(pm);
        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Playermovement pm = collision.GetComponent<Playermovement>();
            if (pm != null)
            {
                attractedObjects.Remove(pm);
            }
        }
    }
}
