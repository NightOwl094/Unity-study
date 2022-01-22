using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class ArrowController : MonoBehaviour
{
    public static float hitBox = 0.5f;

    float speed = 0.02f;
    GameObject player;

    void Start()
    {
        this.player = GameObject.Find("player");

        this.UpdateAsObservable()
            .Subscribe(_ => Move());

        this.UpdateAsObservable()
            .Subscribe(_ => HandleCollision());
    }

    void Move()
    {
        transform.Translate(0, -speed, 0);

        if (transform.position.y < -4.2f)
        {
            Destroy(gameObject);
        }
    }

    void HandleCollision()
    {
        Vector2 arrowVector = transform.position;
        float arrowHitBox = hitBox;

        Vector2 playerVector = this.player.transform.position;
        float playerHitBox = Player.PlayerController.hitBox;

        Vector2 dir = arrowVector - playerVector;
        float d = dir.magnitude;

        if (d < arrowHitBox + playerHitBox)
        {
            GameObject
                .Find("GameDirector")
                .GetComponent<GameDirector>()
                .DecreaseHp();

            Destroy(gameObject);
        }
    }
}
