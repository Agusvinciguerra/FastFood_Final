using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    void Update()
    {
        transform.position = Player.transform.position + new Vector3(0,9,-10);
    }
}
