using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

public class Spotlight : MonoBehaviour
{
    [SerializeField] Light2D l2d;
    public int activated;
    public string type;

    public void Awake()
    {
        activated = -1;
    }
    public void Activate()
    {
        activated = -activated;
        if(activated == 1)
        {
            l2d.enabled = true;
        }
        else
        {
            l2d.enabled = false;
        }
        
    }
}
