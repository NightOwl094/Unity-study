using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ItemController : MonoBehaviour
{
    public float dropSpeed = -0.03f;

    void Start()
    {
        this.UpdateAsObservable()
        .Subscribe(_ => MoveAndDestroy());
    }

    void MoveAndDestroy()
    {
        transform.Translate(0, this.dropSpeed, 0);

        if (transform.position.y < -1.0f)
        {
            Destroy(gameObject);
        }
    }

}
