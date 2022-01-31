using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class TimerDirector : MonoBehaviour
{
    GameObject timerText;
    public float time = 30.0f;

    GameObject generator;

    void Start()
    {
        this.timerText = GameObject.Find("Time");
        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                RunTimer();
                DesignLevel();
            });

        this.generator = GameObject.Find("ItemGenerator");
    }

    void RunTimer()
    {
        this.time -= Time.deltaTime;
        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");
    }

    void DesignLevel()
    {
        ItemGenerator itemGenerator = this.generator.GetComponent<ItemGenerator>();

        if (this.time < 0)
        {
            this.time = 0;
            itemGenerator.Setparameter(10000.0f, 0, 0);
        }
        else if (0 <= this.time && this.time < 5)
        {
            itemGenerator.Setparameter(0.7f, -0.04f, 3);
        }
        else if (5 <= this.time && this.time < 12)
        {
            itemGenerator.Setparameter(0.5f, -0.05f, 6);
        }
        else if (12 <= this.time && this.time < 23)
        {
            itemGenerator.Setparameter(0.8f, -0.04f, 4);
        }
        else if (23 <= this.time && this.time < 30)
        {
            itemGenerator.Setparameter(1.0f, -0.03f, 2);
        }
    }

}
