using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {


    public GameObject player;
    Vector3 targetPosition;




    void LateUpdate()
    {
        if (!LoseScript.isGameover)
        {
            targetPosition = new Vector3(Mathf.Clamp(player.transform.position.x, -12, 12),
                Mathf.Clamp(player.transform.position.y, -15, 15), transform.position.z);
            transform.position = targetPosition;
        }
    }
}

