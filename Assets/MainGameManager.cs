using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager instance;

    public CameraFollowScript cameraFollow;

    public Transform StarPos;

    public GameObject PlayerObj;

    public GameObject DeathPanel;

    private PlayerInputAction inputActions;

    private bool IsPlayerDeath;

    private void Awake()
    {
        instance = this;
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


    private void Start()
    {
        IsPlayerDeath = true;
        SpawnPlayer();
        inputActions.PlayerInput.Retry.performed += _ => SpawnPlayer();
        this.DeathPanel.SetActive(false);
    }

    void SpawnPlayer()
    {
        if (!IsPlayerDeath) return;
        IsPlayerDeath = false;
        this.DeathPanel.SetActive(false);
        GameObject obj = Instantiate(PlayerObj, StarPos.position, Quaternion.identity);
        cameraFollow.TargetObj = obj.transform;
    }

    public void GameOver()
    {
        IsPlayerDeath = true;
        cameraFollow.TargetObj = null;
        this.DeathPanel.SetActive(true);
    }
}
