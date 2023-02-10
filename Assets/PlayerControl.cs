using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public GameObject LegObj;
    public Vector3 LegOffset;
    public Rigidbody2D PlayerLeg;

   

    private Rigidbody2D rg;

    public float MaxSpeed;
    [SerializeField]
    private float CurSpeed;
    [SerializeField]
    private float BalanceValue;
    public float BalanceSpeed;

    public float LegSpeedLimit;

    public float JumpForce;

    [SerializeField]
    private string StepStr;

    private bool IsDead;

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
        GameObject leg_tmp = Instantiate(LegObj, this.transform.position + LegOffset, Quaternion.identity);
        if (leg_tmp.GetComponent<Rigidbody2D>() != null) PlayerLeg = leg_tmp.GetComponent<Rigidbody2D>();
        if (leg_tmp.GetComponent<HingeJoint2D>() != null) leg_tmp.GetComponent<HingeJoint2D>().connectedBody = this.rg;
        inputActions.PlayerInput.Move_L.performed += _ => LeftPress();
        inputActions.PlayerInput.Move_R.performed += _ => RightPress();
        inputActions.PlayerInput.Jump.performed += _ => JumpFunc();
    }

    // Update is called once per frame
    void Update()
    {

        BalanceValue = inputActions.PlayerInput.Balance.ReadValue<float>();

        CurSpeed = Mathf.Clamp(CurSpeed - Time.deltaTime * 20f, 0f, MaxSpeed);
        //if (GameEventManager.instance != null) GameEventManager.instance.ChargeLeg.Invoke(Input.GetKey(KeyCode.Space));
    }

    private void FixedUpdate()
    {
        PlayerLeg.angularVelocity = Mathf.Clamp(PlayerLeg.angularVelocity, -LegSpeedLimit, LegSpeedLimit);
        if (BalanceValue!=0)
        {
            this.rg.AddTorque(BalanceValue*BalanceSpeed * Time.deltaTime);
        }
    }

    void LeftPress()
    {
        if (!StepStr.Equals("L"))
        {
            CurSpeed = Mathf.Clamp(CurSpeed + MaxSpeed / 10f, 0f, MaxSpeed);
            PlayerLeg.AddTorque(-1f * CurSpeed);
            StepStr = "L";
        }
        else
        {
            CurSpeed = Mathf.Clamp(CurSpeed - MaxSpeed / 5f, 0f, MaxSpeed);
            PlayerLeg.angularVelocity = Mathf.Clamp(PlayerLeg.angularVelocity + LegSpeedLimit / 10f, -LegSpeedLimit, 0);
        }
    }

    void RightPress()
    {
        if (!StepStr.Equals("R"))
        {
            CurSpeed = Mathf.Clamp(CurSpeed + MaxSpeed / 10f, 0f, MaxSpeed);
            PlayerLeg.AddTorque(-1f * CurSpeed);
            StepStr = "R";
        }
        else
        {
            CurSpeed = Mathf.Clamp(CurSpeed - MaxSpeed / 5f, 0f, MaxSpeed);
            PlayerLeg.angularVelocity = Mathf.Clamp(PlayerLeg.angularVelocity + LegSpeedLimit / 10f, -LegSpeedLimit, 0);
        }
    }

    void JumpFunc()
    {
        Debug.Log("Wee");
        this.rg.AddForce(new Vector2(0, JumpForce));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (IsDead) return;
        IsDead = true;
        inputActions.Disable();
        if (MainGameManager.instance != null) MainGameManager.instance.GameOver();
    }
}
