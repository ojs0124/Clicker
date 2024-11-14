using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private Player _player;

    public Player Player
    {
        get { return _player; }
        set { _player = value; }
    }

    private void Awake()
    {
        AudioManager audioManager = AudioManager.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
