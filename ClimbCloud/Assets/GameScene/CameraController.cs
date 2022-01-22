using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class CameraController : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        Screen.SetResolution(720, 1280, true);
    }

    void Start()
    {
        this.player = GameObject.Find("cat");
        this.UpdateAsObservable()
            .Subscribe(_ => TrackThePlayer());
    }

    void TrackThePlayer()
    {
        var playerPos = this.player.transform.position;
        transform.position = new Vector3(transform.position.x, playerPos.y, transform.position.z);
    }
}
