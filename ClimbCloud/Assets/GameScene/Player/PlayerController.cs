using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

namespace Player
{
    enum Direction
    {
        LEFT = -1,
        RIGHT = 1
    }

    public class PlayerController : MonoBehaviour
    {
        Animator animator;

        Rigidbody2D rigid2D;
        float jumpForce = 680.0f;
        float walkForce = 40.0f;
        float maxWlakSpeed = 2.0f;
        float threshold = 0.2f;
        Direction direction = Direction.RIGHT;
        int directionValue
        {
            get => (int)direction;
        }
        float speedx
        {
            get => Mathf.Abs(this.rigid2D.velocity.x);
        }


        void Start()
        {
            this.animator = GetComponent<Animator>();
            this.rigid2D = GetComponent<Rigidbody2D>();

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                .Subscribe(_ => Jump());

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.RightArrow) || Input.acceleration.x > this.threshold)
                .Subscribe(_ =>
                {
                    direction = Direction.RIGHT;
                    Move();
                });

            this.UpdateAsObservable()
                .Where(_ => Input.GetKeyDown(KeyCode.LeftArrow) || Input.acceleration.x < -this.threshold)
                .Subscribe(_ =>
                {
                    direction = Direction.LEFT;
                    Move();
                });

            this.UpdateAsObservable()
                .Subscribe(_ => UpdateChacaterDirection());

            this.UpdateAsObservable()
                .Subscribe(_ => UpdateAnimatorSpeed());
        }

        void Jump()
        {
            if (this.rigid2D.velocity.y == 0)
            {
                this.animator.SetTrigger("JumpTrigger");
                this.rigid2D.AddForce(transform.up * this.jumpForce);
            }
        }

        void Move()
        {
            if (this.speedx < this.maxWlakSpeed)
                this.rigid2D.AddForce(transform.right * this.directionValue * this.walkForce);
        }

        void UpdateChacaterDirection()
        {
            transform.localScale = new Vector3(this.directionValue, 1, 1);
        }

        void UpdateAnimatorSpeed()
        {
            if (this.rigid2D.velocity.y == 0)
                this.animator.speed = this.speedx / 2.0f;
            else
                this.animator.speed = 1.0f;
        }
    }
}
