using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelController : MonoBehaviour
{
    [Header("Object settings")]
    public GameObject Player;
    public GameObject Camera;
    public GameObject PlayButton;

    [Header("Player settings")]
    public List<Sprite> characters = new List<Sprite>();

    [Header("UI settings")]
    public Canvas game_canvas;
    public GameObject start_canvas;

    public Text counter;

    public Text highscore;
    public Text title;

    private float lev;
    private double newlev;

    private bool playing = false;


    void Start()
    {
        Player.transform.position = new Vector3(0, 1, 0);

        highscore.text = PlayerPrefs.GetFloat("highscore").ToString();

        Player.GetComponent<SpriteRenderer>().sprite = characters[PlayerPrefs.GetInt("character_active")];
    }

    void Update()
    {
        newlev = Math.Round(Player.transform.position.y * 10);
        if (newlev > lev)
        {
            lev = Convert.ToSingle(newlev);
            counter.text = lev.ToString();
        }

        if (Player.transform.position.y < Camera.transform.position.y - 5.5f)
        {
            Death();
        }
        if (!playing && Input.GetAxis("Jump") == 1) PlayButton.GetComponent<Button>().onClick.Invoke();
    }

    public void Play()
    {
        playing = true;
        lev = 0;
        newlev = 0;
        counter.text = lev.ToString();
        Player.GetComponent<Player>().enabled = true;
        GetComponent<LevelGenerator>().Play();
    }

    public void Death()
    {
        if (lev > PlayerPrefs.GetFloat("highscore"))
        {
            PlayerPrefs.SetFloat("highscore", lev);
            highscore.text = PlayerPrefs.GetFloat("highscore").ToString();
        }

        lev = 0;
        newlev = 0;
        counter.text = lev.ToString();

        title.text = "You Died!";

        game_canvas.gameObject.SetActive(false);
        start_canvas.gameObject.SetActive(true);

        Player.transform.position = new Vector3(0, 2.8f, 0);
        Camera.transform.position = new Vector3(0, 4, -10);
        GetComponent<LevelGenerator>().Reset();
        playing = false;
    }
}