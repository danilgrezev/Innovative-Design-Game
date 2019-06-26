using UnityEngine;
using System.Collections;

public class RealEnemy : MonoBehaviour
{

    public Transform player;
    public float move_speed;
    public float rotation_speed;
    public Transform enemy;
    public float height;

    void Update()
    {
        var look_dir = player.position - enemy.position;
        look_dir.y = 0;
        enemy.rotation = Quaternion.Slerp(enemy.rotation, Quaternion.LookRotation(look_dir), rotation_speed * Time.deltaTime);
        enemy.position += enemy.forward * move_speed * Time.deltaTime;
        enemy.position = new Vector3(enemy.position.x, height, enemy.position.z);
    }
}