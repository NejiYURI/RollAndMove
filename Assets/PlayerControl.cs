using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D PlayerLeg;

    private Rigidbody2D rg;

    public float Speed;
    public float BalanceSpeed;

    [SerializeField]
    private string StepStr;

    private PlayerInputAction inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputAction();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    void Start()
    {
        this.rg = GetComponent<Rigidbody2D>();
        inputActions.PlayerInput.Move_L.performed += _ => LeftPress();
        inputActions.PlayerInput.Move_R.performed += _ => RightPress();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.rg.AddTorque(BalanceSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.rg.AddTorque(-1f * BalanceSpeed * Time.deltaTime);
        }

        //if (GameEventManager.instance != null) GameEventManager.instance.ChargeLeg.Invoke(Input.GetKey(KeyCode.Space));
    }

    void LeftPress()
    {
        if (!StepStr.Equals("L"))
        {
            PlayerLeg.AddTorque(-1f * Speed);
            StepStr = "L";
        }
    }

    void RightPress()
    {
        if (!StepStr.Equals("R"))
        {
            PlayerLeg.AddTorque(-1f*Speed);
            StepStr = "R";
        }
    }
}
