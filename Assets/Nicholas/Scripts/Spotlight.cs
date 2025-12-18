using System.Collections;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class Spotlight : MonoBehaviour
{
    [SerializeField] Light2D l2d;
    [SerializeField] MagnetPlatform mp;
    [SerializeField] AudioSource au;
    public int activated;
    public string type;
    public bool timed;
    public float switchTime;

    //for magnets
    private int originPolarity;
    private float originAF;

    public void Awake()
    {
        originPolarity = mp.polarity;
        originAF = mp.attractionForce;
        if (timed)
        {
            StartCoroutine(SwitchTimeCount(switchTime));
        }
    }
    public void Activate()
    {
        activated = -activated;
        au.Play();
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
    private IEnumerator SwitchTimeCount(float seconds)
    {
        while (true)
        {
            Debug.Log("switch");
            Activate();
            yield return new WaitForSeconds(seconds);
        }
        
    }
}
