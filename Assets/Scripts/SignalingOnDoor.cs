using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalingOnDoor : MonoBehaviour
{
    [SerializeField] private Signaling _signaling;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Thief>())
        {
            _signaling.TurnOnAlarm();
        }
    }
}
