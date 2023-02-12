using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCharacter : MonoBehaviour
{
    public Rigidbody2D Head;

    public Rigidbody2D Sholder_1;

    public Rigidbody2D Sholder_2;

    private void FixedUpdate()
    {
        if (Head != null)
        {
            Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector3 lookAt = mouseScreenPosition;

            float AngleRad = Mathf.Atan2(lookAt.y - Head.position.y, lookAt.x - Head.position.x);

            float AngleDeg = (180 / Mathf.PI) * AngleRad;

            Head.MoveRotation(AngleDeg);
        }
    }

    public void ClickExplosion()
    {
        if (Sholder_1 != null) Sholder_1.AddTorque(-1000f);
        if (Sholder_2 != null) Sholder_2.AddTorque(1000f);
    }
}
