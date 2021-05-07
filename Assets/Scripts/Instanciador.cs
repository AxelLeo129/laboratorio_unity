using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Instanciador : MonoBehaviour
{
    [SerializeField] private Object player_prefab;
    [SerializeField] private Text score_text;
    [SerializeField] private GameObject pause_menu;
    [SerializeField] private Slider slider;

    private bool is_paused = false;
    GameObject player;
    private int score = 0;

    public int Score
    {
        get { return this.score; }
        set { this.score = value; }
    }

    // Start is called before the first frame updates
    void Start()
    {
        this.player = Instantiate(player_prefab, new Vector3(2.76f, 0, 8.86f), Quaternion.identity) as GameObject;

        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player_prefab && !this.player && Input.GetKeyDown(KeyCode.Return))
            this.player = Instantiate(player_prefab, new Vector3(2.76f, 0, 8.86f), Quaternion.identity) as GameObject;

        this.score_text.text = "Score: " + this.score.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
            this.TogglePause();
    }

    public void TogglePause()
    {
        this.is_paused = !this.is_paused;
        this.pause_menu.SetActive(this.is_paused);

        Time.timeScale = this.is_paused ? 0.0f : 1.0f;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void modifyVolume()
    {
        GameObject.FindObjectOfType<Mover>().modifyVolume(this.slider.value);
    }

}
