using System.Collections.Generic;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MagnetPlatform : MonoBehaviour
{
    [SerializeField] Tilemap tm;

    public int polarity;
    public float attractionForce;
    private Color32 polarityColor;

    public int distance1;
    public int distance2;
    public int distance3;
    public int distance4;
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
                if (distance >= 0 && distance <= distance1) {
                    rb.AddForce(direction * attractionForce * 6 * pm.polarity);
                }
                else if (distance > distance1 && distance <= distance2)
                {
                    rb.AddForce(direction * attractionForce * 4 * pm.polarity);
                }
                else if (distance > distance2 && distance <= distance3)
                {
                    rb.AddForce(direction * attractionForce * 2 * pm.polarity);
                }
                else if (distance > distance3 && distance <= distance4)
                {
                    rb.AddForce(direction * attractionForce * pm.polarity);
                }
            }
        }
    }
    public void Update()
    {
        if(polarity == 1)
        {
            attractionForce  = Mathf.Abs(attractionForce);
            polarityColor = new Color32(0, 130, 255, 255);
        }
        else if(polarity == -1)
        {
            attractionForce = -Mathf.Abs(attractionForce);
            polarityColor = new Color32(255, 0, 0, 255);
        }
        else
        {
            attractionForce = 0;
            polarityColor = new Color32(255, 0, 255, 255);
        }
        tm.color = polarityColor;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Playermovement pm = collision.GetComponent<Playermovement>();
        if (pm != null && !attractedObjects.Contains(pm))
        {
            attractedObjects.Add(pm);
            if(polarity == 0)
            {
                pm.rb.gravityScale = 0;
            }
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
            pm.rb.gravityScale = 0.8f;
        }
    }
}
