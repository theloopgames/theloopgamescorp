using System;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    private float speed = 5f;
    public GameObject player;
    private PolygonCollider2D pcMonster;
    private Rigidbody2D rbMonster;
    private PolygonCollider2D pcPlayer;
    private Rigidbody2D rbPlayer;
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    private SpriteRenderer currSprite;


    bool FaceLeft = true;

    void Start()
    {
        pcMonster = GetComponent<PolygonCollider2D>();
        rbMonster = GetComponent<Rigidbody2D>();
        currSprite = GetComponent<SpriteRenderer>();
        pcPlayer = player.GetComponent<PolygonCollider2D>();
        rbPlayer = player.GetComponent<Rigidbody2D>();
        
    }

    void Update()
    {
        if(pcMonster.Distance(pcPlayer).distance <= 15f && pcMonster.Distance(pcPlayer).distance > 0f)
        {
            float moveX = 0f, moveY = 0f;

            if(Math.Round(rbMonster.position.x, 1) > Math.Round(rbPlayer.position.x, 1))
            {
                moveX = -1f;
                currSprite.sprite = spriteLeft;
                if (!FaceLeft)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    FaceLeft = true;
                }
            }
            else if(Math.Round(rbMonster.position.x, 1) < Math.Round(rbPlayer.position.x, 1))
            {
                moveX = 1f;
                currSprite.sprite = spriteLeft;
                if (FaceLeft)
                {
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                    FaceLeft = false;
                }
            }
            if (Math.Round(rbMonster.position.y, 1) > Math.Round(rbPlayer.position.y, 1))
            {
                moveY = -1f;
                currSprite.sprite = spriteDown;
            }
            else if (Math.Round(rbMonster.position.y, 1) < Math.Round(rbPlayer.position.y, 1))
            {
                moveY = 1f;
                currSprite.sprite = spriteUp;
            }
 
            rbMonster.MovePosition(rbMonster.position + Vector2.right * speed * moveX * Time.deltaTime + Vector2.up * speed * moveY * Time.deltaTime);

        }
        else
        {
            rbMonster.MovePosition(rbMonster.position + Vector2.right * 0);
        }
    }

}
