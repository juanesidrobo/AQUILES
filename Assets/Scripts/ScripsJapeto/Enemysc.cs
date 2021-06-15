using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemysc : MonoBehaviour
{
    public GameObject Zeus;
    public GameObject SkullAPrefab;
    private float LastShoot;
    public float Speed;
    public Transform Player;
    public Rigidbody2D rb2D;
    public Animator animator;
    public float DistancePlayer;
    public float RangeVision;
    public float ReverseSpeed;
    public float RangeReverse;
    public float RangeShoot;
    public float AttackSpeed = 7f;
    bool Attacking;
    private void Start()
    {
        SkullAPrefab = null;
    }
    void Update()
    {
        if (Zeus == null) return;
        Vector3 direction = Zeus.transform.position - transform.position;
        if (direction.x >= 0.0f) transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        else transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);

        float distance = Mathf.Abs(Zeus.transform.position.x - transform.position.x);

        /*if (distance < 40.0f && Time.time > LastShoot + 0.25f )
        {
            Shoot();
            LastShoot = Time.time;
        }*/

        DistancePlayer = Vector2.Distance(Player.position, rb2D.position);
        if (DistancePlayer < RangeVision && DistancePlayer > RangeReverse && DistancePlayer > RangeShoot)
        {
            Vector2 objective = new Vector2(Player.position.x, Player.position.y);
            Vector2 NewPos = Vector2.MoveTowards(rb2D.position, objective, Speed * Time.deltaTime);
            rb2D.MovePosition(NewPos);
            animator.SetBool("Run", true);
        }

        else if (DistancePlayer < RangeVision && DistancePlayer > RangeReverse && DistancePlayer <= RangeShoot) 
        {
            Vector2 objective = new Vector2(Player.position.x, Player.position.y);
            Vector2 NewPos = Vector2.MoveTowards(rb2D.position, objective, 0 * Time.deltaTime);
            rb2D.MovePosition(NewPos);
            if(!Attacking) StartCoroutine(Attack(AttackSpeed));
        }

        else if (DistancePlayer < RangeReverse)
        {
            Vector2 objective = new Vector2(Player.position.x, Player.position.y);
            Vector2 NewPos = Vector2.MoveTowards(rb2D.position, objective, ReverseSpeed * Time.deltaTime);
            rb2D.MovePosition(NewPos);
            animator.SetBool("Run", true);
        }

    } 

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, RangeVision);
        Gizmos.DrawWireSphere(transform.position, RangeShoot);
        Gizmos.DrawWireSphere(transform.position, RangeReverse);
    }

    IEnumerator Attack (float seconds= 2f){
        Attacking = true;
        if (DistancePlayer == RangeShoot && SkullAPrefab != null)
        {
            Instantiate(SkullAPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(seconds);
        }
        Attacking = false;
    }

    /*private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x == 0.5f) direction = Vector3.right;
        else direction = Vector3.left;
        GameObject SkullA = Instantiate(SkullAPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        SkullA.GetComponent<skullsc>().SetDirection(direction);
    }*/


}
