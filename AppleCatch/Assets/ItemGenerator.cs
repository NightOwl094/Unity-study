using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ItemGenerator : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;
    float span = 1.0f;
    float delta = 0;
    int ratio = 2;
    float speed = -0.03f;

    void Start()
    {
        this.UpdateAsObservable()
            .Subscribe(_ => GenerateItem());
    }

    public void Setparameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;
    }

    private void GenerateItem()
    {
        this.delta += Time.deltaTime;

        if (this.delta > this.span)
        {
            this.delta = 0;

            GameObject item = SelectItem();
            item.transform.position = SelectItemPosition();
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }

    }

    private GameObject SelectItem()
    {
        GameObject item;
        int dice = Random.Range(1, 11);

        if (dice <= this.ratio)
        {
            item = Instantiate(bombPrefab) as GameObject;
        }
        else
        {
            item = Instantiate(applePrefab) as GameObject;
        }

        return item;
    }

    private Vector3 SelectItemPosition()
    {
        float x = Random.Range(-1, 2);
        float z = Random.Range(-1, 2);

        return new Vector3(x, 4, z);
    }
}
