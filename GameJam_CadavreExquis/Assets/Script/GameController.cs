using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    [Header("Main Component")]
    public GameObject player;
    public GameObject enemyPrefab;
    public GameObject enemySpawner;
    // private List<GameObject> enemiesOnScreen = new List<GameObject>;

    [Space]
    [Header("UI Design")]
    public Text score;
    private int _score;
    public Text maxScore;
    private int _maxScore;
    public Text deathCount;
    private int _deathCount;

    private float timerScore = 0;
    public float timerMax;
    private bool startTimer;

    public Text ready;
    public Text set;
    public Text go;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyPrefab.GetComponent<Obstacle>().speed = 25f;

        _score = 0;
        _maxScore = 0;
        _deathCount = 0;

        timerScore = 0;
        startTimer = true;

        ready.text = "";
        set.text = "";
        go.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (timerScore < timerMax && startTimer)
        {
            timerScore += Time.deltaTime;
        }
        else if (timerScore >= timerMax && startTimer)
        {
            timerScore = 0;
            _score += 5;
        }

        score.text = _score.ToString();
        maxScore.text = _maxScore.ToString();
        deathCount.text = _deathCount.ToString();
    }

    public void OnKill()
    {
        Debug.Log("Je réduis la vitesse globale du jeu");

        _deathCount += 1;
        if (_score > _maxScore)
            _maxScore = _score;
        _score = 0;

        foreach(GameObject enemiesOnScreen in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            Destroy(enemiesOnScreen);
        }

        player.GetComponent<CharacterController>().isDead = true;
        player.transform.position = new Vector2(player.transform.position.x, 0);
        player.SetActive(false);
        enemySpawner.GetComponent<Spawner>().isDead = true;

        enemyPrefab.GetComponent<Obstacle>().speed -= 2.5f;
        enemySpawner.GetComponent<Spawner>().spawnTimeMax += 0.1f;
        

        StartCoroutine(ResumeGame());
    }

    private IEnumerator ResumeGame()
    {
        //Aficher "Ready"
        Debug.Log("Ready?");
        ready.text = "READY?";
        yield return new WaitForSeconds(0.5f);
        ready.text = "";

        //Afficher "Set"
        Debug.Log("Set");
        set.text = "SET";
        player.SetActive(true);
        player.GetComponent<CharacterController>().isDead = false;
        yield return new WaitForSeconds(0.5f);
        set.text = "";

        //Afficher "Go!"
        Debug.Log("Go!");
        go.text = "GO!!!";
        yield return new WaitForSeconds(0.2f);
        enemySpawner.GetComponent<Spawner>().isDead = false;
        go.text = "";
    }
}
