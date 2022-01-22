using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ArrowGenerator : MonoBehaviour
{
    public GameObject arrowPrefab;
    float span = 1.0f;
    float delta = 0;

    void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => GenerateArrow());
    }

    void GenerateArrow()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;

            int px = Random.Range(-6, 7);
            (Instantiate(arrowPrefab) as GameObject)
                .transform
                .position = new Vector3(px, 7, 0);
        }
    }

}
