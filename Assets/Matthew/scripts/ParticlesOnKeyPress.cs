using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticlesOnKeyPress : MonoBehaviour
{
    private float DashTime = .5f;
    [SerializeField] private TrailRenderer tr;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Dashtrail;
        }
    }

    private IEnumerator Dashtrail()
    {
        tr.emitting = true;
        yield return new WaitForSeconds(DashTime);
        tr.emitting = false;
    }
}
