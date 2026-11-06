using TMPro;
using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public static UIHandler Instance { get; private set; }
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text LivesText;
    [SerializeField] private TMP_Text GameOverText;
    private bool changed = true;
    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one UIHandler! " + transform + " - " + Instance);
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        GameHandler.Instance.ScoreChanged += GameHandler_ScoreChanged;
        GameHandler.Instance.LivesChanged += GameHandler_LivesChanged;
    }

    // Update is called once per frame
    void Update()
    {
        if (changed)
        {
            ScoreChange();
            LivesChange();
            changed = false;
        }
    }

    public void ScoreChange()
    {
        scoreText.text = "Score: " + GameHandler.Instance.GetScore();
    }

    public void LivesChange()
    {
        LivesText.text = "Lives: " + GameHandler.Instance.GetLives();
    }

    private void GameHandler_ScoreChanged(object sender, System.EventArgs e)
    {
        ScoreChange();
        changed = true;
    }
    private void GameHandler_LivesChanged(object sender, System.EventArgs e)
    {
        LivesChange();
        changed = true;
    }

    public void GameOver()
    {
        GameOverText.gameObject.SetActive(true);
    }
}
