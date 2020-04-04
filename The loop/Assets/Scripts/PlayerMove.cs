using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private float speed = 10f;
    private int damage = 0;
    private Rigidbody2D rb;
    public Sprite spriteUp;
    public Sprite spriteDown;
    public Sprite spriteLeft;
    public int health =100;
    private SpriteRenderer currSprite;

    bool FaceLeft = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currSprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        rb.MovePosition(rb.position + Vector2.right * speed * moveX * Time.deltaTime + Vector2.up * speed * moveY * Time.deltaTime);

        content = new GUIContent(" " + health, BoxTexture, "");

        SetSprite(); //Як зделать шоби не було лунной походки (вопрос до Ігоря)

    }

    void SetSprite()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            currSprite.sprite = spriteLeft;
            if (!FaceLeft)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                FaceLeft = true;
            }
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            currSprite.sprite = spriteLeft;
            if (FaceLeft)
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                FaceLeft = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.W))
        {
            currSprite.sprite = spriteUp;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            currSprite.sprite = spriteDown;
        }
    }

    void SetDamage(int addDamage)
    {
        damage += addDamage;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            health -= 1;
            if (health == 0)
            {
                Invoke("Reload", 1);
            }
        }
    }
    void Reload()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    GUIContent content;
    public Texture BoxTexture;

    void OnGUI()
    {
        GUI.Box(new Rect(570 ,400, 70, 40),content);
    }

}
