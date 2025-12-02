using System.Net.Mail;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class Spotlight : MonoBehaviour
{
    [SerializeField] Light2D l2d;
    [SerializeField] MagnetPlatform mp;
    public int activated;
    public string type;

    private int originPolarity;
    private float originAF;

    public void Awake()
    {
        activated = -1;
        originPolarity = mp.polarity;
        originAF = mp.attractionForce;
    }
    public void Activate()
    {
        activated = -activated;
        if(activated == 1)
        {
            l2d.enabled = true;
            if(type == "switch")
            {
                mp.polarity *= -1;
            }
            if(type == "zerog")
            {
                mp.polarity = 0;
            }
        }
        if(activated == -1)
        {
            l2d.enabled = false;
            if(type == "switch")
            {
                mp.polarity *= -1;
            }
            if(type == "zerog")
            {
                mp.polarity = originPolarity;
                mp.attractionForce = originAF;
            }
        }
        
    }
}
