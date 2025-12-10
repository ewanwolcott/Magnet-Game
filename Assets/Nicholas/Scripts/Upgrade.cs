using UnityEngine;

public class Upgrade : MonoBehaviour
{

    public string type;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Playermovement pm = collision.GetComponent<Playermovement>();
            if(type == "red")
                pm.hasRed = true;
            if (type == "blue")
                pm.hasBlue = true;
            Destroy(gameObject);
        }
    }
}
