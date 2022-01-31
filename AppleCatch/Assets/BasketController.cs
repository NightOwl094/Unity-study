using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class BasketController : MonoBehaviour
{
    void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => Move());
    }

    void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            float x = Mathf.RoundToInt(hit.point.x);
            float z = Mathf.RoundToInt(hit.point.z);
            transform.position = new Vector3(x, 0, z);
        }
    }

}
