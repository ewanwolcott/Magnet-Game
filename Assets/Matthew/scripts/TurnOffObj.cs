using UnityEngine;

public class TurnOffObj : MonoBehaviour
{
    // put this script on a object to turn off the object on game start
    void Start()
    {
        gameObject.SetActive(false);
    }
}
