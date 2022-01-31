using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using UniRx.Triggers;

public class GameDirector : MonoBehaviour
{
    public AudioClip appleSE;
    public AudioClip bombSE;
    AudioSource aud;
    GameObject basket;

    GameObject pointText;
    int point = 0;

    void Start()
    {
        this.pointText = GameObject.Find("Point");
        this.UpdateAsObservable()
            .Subscribe(_ =>
            {
                this.pointText.GetComponent<Text>().text = this.point.ToString() + " point";
            });

        this.basket = GameObject.Find("basket");
        this.aud = this.GetComponent<AudioSource>();
        this.basket
            .OnTriggerEnterAsObservable()
            .Subscribe(other => handleTriggerEnterBasket(other));
    }

    void handleTriggerEnterBasket(Collider other)
    {
        if (other.gameObject.tag == "Apple")
        {
            handleGetApple();
            this.aud.PlayOneShot(this.appleSE);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.tag == "Bomb")
        {
            HandleGetBomb();
            this.aud.PlayOneShot(this.bombSE);
            Destroy(other.gameObject);
        }
    }

    void handleGetApple()
    {
        this.point += 100;
    }

    void HandleGetBomb()
    {
        this.point /= 2;
    }

}
