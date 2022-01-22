using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Player
{
    enum DIRECTION
    {
        LEFT,
        RIGHT
    }

    public class PlayerController : MonoBehaviour
    {
        public static float hitBox = 1f;

        DIRECTION direction = DIRECTION.LEFT;
        float speed = 0;

        private void Start()
        {
            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.LeftArrow))
                .Subscribe(_ =>
                {
                    direction = DIRECTION.LEFT;
                    speed = 1;
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.RightArrow))
                .Subscribe(_ =>
                {
                    direction = DIRECTION.RIGHT;
                    speed = 1;
                });

            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    if (speed > 0.99)
                    {
                        move();
                    }
                });
        }

        void move()
        {
            float x = (direction == DIRECTION.LEFT) ? -speed : speed;
            transform.Translate(x, 0, 0);
            speed *= 0.99f;
        }
    }

}
