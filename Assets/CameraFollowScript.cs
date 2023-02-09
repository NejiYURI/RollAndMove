using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public Vector3 Offset;
    public Transform TargetObj;

    private void FixedUpdate()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, TargetObj.position + Offset, 1.2f);
    }
}
