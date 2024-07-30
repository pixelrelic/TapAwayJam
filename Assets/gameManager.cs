using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    public int moves;
    public GameObject levels;
    public TextMeshProUGUI moves_UI;
    public TextMeshProUGUI level_UI;
    public GameObject levelCompleted;
    public GameObject levelRestarted;
    public AudioSource rocketLaunch;
    public AudioSource rocketCollide;
    int level;
    private void Awake()
    {
        level = PlayerPrefs.GetInt("level");
        if(level<9)
        {
            levels.transform.GetChild(level).gameObject.SetActive(true);
        }
        else
        {
            int r = Random.Range(2, 9);
            levels.transform.GetChild(r).gameObject.SetActive(true);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        moves = GameObject.Find("LevelManager").GetComponent<levelManager>().moves;
        moves_UI.text = moves.ToString() + " " + "Moves";
        level_UI.text = "Level" + " " + (level + 1).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene()
    {
        SceneManager.LoadScene(0);
    }
}
