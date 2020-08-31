using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ConsentBehavior : MonoBehaviour
{
    private SpriteRenderer sprite;
    public Sprite leftCon;
    public Sprite rightCon;
    public Sprite midCon;
    public Sprite nope;
    public Sprite downCon;
    private ConsentHoleBehavior holeInfo;
    private Transform transform;
    private float speed = 20f;
    private bool isHoleMatch = false;
    private Vector3 originPos;
    private bool isFreeze = false;
    private float freezeTimeCheck = 1f;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        GameObject consent = GameObject.Find("ConsentHole");
        holeInfo = consent.GetComponent<ConsentHoleBehavior>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        if (!isHoleMatch && !isFreeze)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                sprite.sprite = rightCon;
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                sprite.sprite = leftCon;
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                sprite.sprite = midCon;
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                sprite.sprite = downCon;
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                if (holeInfo.currSprite == sprite.sprite)
                {
                    isHoleMatch = true;
                    originPos = transform.position;
                }
                else
                {
                    sprite.sprite = nope;
                    isFreeze = true;
                    ComboObj.combo = 0;
                }
            }
        }
        else if(isHoleMatch)
        {
            GoUp();
        }
        else if (isFreeze)
        {
            if (freezeTimeCheck > 0f)
            {
                freezeTimeCheck -= Time.deltaTime;
            }
            else
            {
                freezeTimeCheck = 1f;
                isFreeze = false;
                sprite.sprite = midCon;
            }
        }
    }

    void GoUp()
    {
        transform.position += (Vector3.up * Time.deltaTime * speed);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log(other.gameObject.tag);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hole")
        {
            Reset();
            ScoreComboTimeIncre();
        }
    }

    void ScoreComboTimeIncre()
    {
        ComboObj.timeCheck = 2f;
        TimerBehavior.timer++;
        ScoreBehavior.score++;
        ScoreBehavior.score += ComboObj.combo;
        ComboObj.combo++;
    }

    void Reset()
    {
        transform.position = originPos;
        isHoleMatch = false;
    }
}
