using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComboObj : MonoBehaviour
{
    public static float timeCheck;
    private Text text;
    public static int combo;
    private bool isReachFullSize;
    private float sizechangeTimer;

    void Start()
    {
        timeCheck = 1f;
        text = GetComponent<Text>();
        combo = 0;
        isReachFullSize = false;
        sizechangeTimer = 0.05f;
    }

    void Update()
    {
        if (timeCheck > 0f)
        {
            timeCheck -= Time.deltaTime;
        }
        else
        {
            combo = 0;
        }

        if (combo > 0)
        {
            text.text = $"X{combo}";

            if (sizechangeTimer < 0f)
            {
                int fontSize = text.fontSize;

                if (isReachFullSize == false)
                {
                    if (fontSize < 100)
                    {
                        fontSize++;
                    }
                    else
                    {
                        isReachFullSize = true;
                    }
                }
                else
                {
                    if (fontSize > 40)
                    {
                        fontSize--;
                    }
                    else
                    {
                        isReachFullSize = false;
                    }
                }

                text.fontSize = fontSize;
                sizechangeTimer = 0.001f;
            }
            else
            {
                sizechangeTimer -= Time.deltaTime;
            }

        }
        else
        {
            text.text = "";
        }
    }
}
