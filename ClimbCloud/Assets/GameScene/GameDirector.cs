using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;

public class GameDirector : MonoBehaviour
{
    GameObject player;
    GameObject flag;
    void Start()
    {
        this.player = GameObject.Find("cat");
        this.flag = GameObject.Find("flag");

        this.player
            .OnTriggerEnter2DAsObservable()
            .Subscribe(_ => GameOver());

        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                if (isOutPlayer) GameOver();
            });
    }

    bool isOutPlayer => this.player.transform.position.y < -10;

    void GameOver()
    {
        Debug.Log("Goal");
        SceneManager.LoadScene("ClearScene");
    }
}
