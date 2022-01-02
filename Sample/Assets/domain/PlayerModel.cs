using UnityEngine;

public class PlayerModel
{
    private int hp = 100;
    private int power = 50;

    public void Attack()
    {
        Debug.Log($"{power} 데미지를 입혔다.");
    }

    public void Damage(int damage)
    {
        this.hp -= damage;
        Debug.Log($"{damage}를 입었다.");
    }
}