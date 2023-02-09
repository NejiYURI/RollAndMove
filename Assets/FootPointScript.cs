using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootPointScript : MonoBehaviour
{
    public Vector2 StartPos;
    public Vector2 EndPos;

    private bool Charging;

    private void Start()
    {
        if (GameEventManager.instance != null) GameEventManager.instance.ChargeLeg.AddListener(SetLeg);
    }

    void SetLeg(bool i_Ischarge)
    {
        if (i_Ischarge)
        {
            if (!Charging)
            {
                Charging = true;
                transform.LeanMoveLocalY(EndPos.y, 0.1f);
            }
        }
        else
        {
            if (Charging)
            {
                Charging = false;
                transform.LeanMoveLocalY(StartPos.y, 0.1f);
            }
        }

    }
}
