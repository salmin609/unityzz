using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TimerBehavior : MonoBehaviour
{
    public static float timer = 0f;

    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        timer = 5f;
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        text.text = $"{(int)timer}";

        if (timer < 0f)
        {
            SceneManager.LoadScene("ScoreScene");
        }
    }
}
