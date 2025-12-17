using System;
using UnityEngine;
using static UnityEngine.UI.Image;

public class Upgrade : MonoBehaviour
{

    public string type;
    public bool soundPlayed;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] Playermovement pm;
    [SerializeField] AudioSource au;
    public void Activate()
    {
        if (type == "red")
            pm.hasRed = true;
        if (type == "blue")
            pm.hasBlue = true;
        sr.color = new Color32(100, 100, 100, 255);
        if(!soundPlayed)
        {
            au.Play();
            soundPlayed = true;
        }
            
    }
}
