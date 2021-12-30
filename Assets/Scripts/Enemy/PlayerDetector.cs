using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    private bool _isSeePlayer;

    private void Start()
    {
        StartCoroutine(ScanPlayer(0.3f));
    }

    IEnumerator ScanPlayer(float time)
    {
        while (true)
        {
            RaycastHit hit;
            Physics.Linecast(transform.position, GameManager.Instance.GetPlayer().transform.position, out hit);
            //Physics.Linecast(transform.position,-(transform.position - GameManager.Instance.GetPlayer().transform.position), out hit);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.Equals(GameManager.Instance.GetPlayer()))
                {
                    _isSeePlayer = true;
                    Debug.DrawRay(transform.position, -(transform.position - GameManager.Instance.GetPlayer().transform.position), Color.green,1);
                }
                else
                {
                    _isSeePlayer = false; 
                    Debug.DrawRay(transform.position, -(transform.position - GameManager.Instance.GetPlayer().transform.position), Color.red,1);

                }
            }

            yield return new WaitForSecondsRealtime(time);
        }
    }

    public bool IsPlayerSeen()
    {
        return _isSeePlayer;
    }
}
