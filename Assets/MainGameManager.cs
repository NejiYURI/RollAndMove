using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameManager : MonoBehaviour
{
    public static MainGameManager instance;

    public CameraFollowScript cameraFollow;

    public Transform StarPos;

    public GameObject PlayerObj;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        GameObject obj = Instantiate(PlayerObj, StarPos.position, Quaternion.identity);
        cameraFollow.TargetObj = obj.transform;
    }

    public void GameOver()
    {
        SpawnPlayer();
    }
}
