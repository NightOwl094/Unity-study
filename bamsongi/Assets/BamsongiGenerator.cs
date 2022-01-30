using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class BamsongiGenerator : MonoBehaviour
{
    public GameObject bamsongiPrefab;

    void Start()
    {
        this.UpdateAsObservable()
            .Where(_ => Input.GetMouseButtonDown(0))
            .Subscribe(_ => createAndShootBamsongi());
    }

    private void createAndShootBamsongi()
    {
        GameObject bamsongi = Instantiate(bamsongiPrefab) as GameObject;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 worldDir = ray.direction;
        bamsongi.GetComponent<BamsongiController>().Shoot(worldDir.normalized * 2000);
    }
}
