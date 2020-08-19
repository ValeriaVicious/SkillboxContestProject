using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;


public class GameController : MonoBehaviour
{
    #region Fields

    [SerializeField] private Text _scoreLabel;
    [SerializeField] private Image _menu;
    [SerializeField] private Button _startButton;

    public bool IsStarted = false;

    public int Score = 0;

    public static GameController Instance;

    #endregion


    #region UnityMethods

    private void Start()
    {
        Instance = this;
        _startButton.onClick.AddListener(delegate
        {
            _menu.gameObject.SetActive(false);
            IsStarted = true;
        });
    }

    private void Update()
    {
        _scoreLabel.text = "Score: " + Score;
    }

    #endregion
}
