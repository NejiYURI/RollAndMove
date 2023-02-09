using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public Rigidbody2D LeftFoot;
    public Rigidbody2D RightFoot;

    private Rigidbody2D rg;

    public float Speed;
    public float BalanceSpeed;
    // Start is called before the first frame update
    void Start()
    {
        this.rg = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.A))
        //{
        //    LeftFoot.AddTorque(-1f * Speed * Time.deltaTime);
        //}
        if (Input.GetKey(KeyCode.D))
        {
            RightFoot.AddTorque(-1f * Speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.rg.AddTorque(BalanceSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.rg.AddTorque(-1f * BalanceSpeed * Time.deltaTime);
        }
    }
}
