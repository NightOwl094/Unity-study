using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UniRx;
using UniRx.Triggers;

public class ClearDirector : MonoBehaviour
{
    void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => SceneManager.LoadScene("GameScene"));
    }
}
