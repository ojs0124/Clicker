using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Game Data")]
    [SerializeField] private GameData _gameData;
    public GameData GameData { get { return _gameData; } set { GameData = value; } }

    [Header("UI References")]
    [SerializeField] private TMP_Text energyPossessedText;
    [SerializeField] private TMP_Text spiritPossessedText;
    [SerializeField] private TMP_Text spiritSpawnedCountText;
    [SerializeField] private TMP_Text spiritSpawnLimitCountText;

    [SerializeField] private Button upgradeButton;
    [SerializeField] private int upgradeCost = 10;

    public GameObject spirit;

    private Coroutine _autoClickCoroutine;

    void Awake()
    {
        GameManager.Instance.Player = this;
        _gameData = new GameData();
    }

    void Start()
    {
        StartAutoClick();
    }

    void Update()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        energyPossessedText.text = _gameData.energyPossessed.ToString();
        spiritPossessedText.text = _gameData.spiritPossessed.ToString();
        spiritSpawnedCountText.text = _gameData.spiritSpawnedCount.ToString();
        spiritSpawnLimitCountText.text = _gameData.spiritSpawnLimitCount.ToString();

        upgradeButton.interactable = _gameData.energyPossessed >= upgradeCost;
    }

    private void StartAutoClick()
    {
        if (_autoClickCoroutine != null)
        {
            StopCoroutine(_autoClickCoroutine);
        }

        _autoClickCoroutine = StartCoroutine(AutoClickCoroutine());
    }

    private IEnumerator AutoClickCoroutine()
    {
        while (true)
        {
            _gameData.energyPossessed += _gameData.autoClickPerSecond * _gameData.energyPerClick;
            _gameData.spiritPossessed += 1;
            yield return new WaitForSeconds(1f);
        }
    }

    public void OnClick(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started){
            _gameData.energyPossessed += _gameData.energyPerClick;
            Debug.Log(_gameData.energyPossessed);
        }
    }

    public void UpdateUpgrade()
    {
        _gameData.energyPossessed -= upgradeCost;
        upgradeCost *= 2;

        _gameData.energyLevel += 1;
        _gameData.spiritLevel += 1;
        _gameData.celestialTreeLevel += 1;
        _gameData.energyPerClick += 3;
        _gameData.spiritSpawnLimitCount += 1;
        _gameData.spritEnergyPerSecond += 2;
    }
    
    public void SpawnSpirit()
    {
        if(_gameData.spiritSpawnedCount < _gameData.spiritSpawnLimitCount)
        {
            _gameData.spiritPossessed -= 1;
            _gameData.spiritSpawnedCount += 1;

            float posX = UnityEngine.Random.Range(-8.0f, 8.0f);
            float posY = UnityEngine.Random.Range(-2.0f, 4.0f);
            Vector3 spawnPos = new Vector3(posX, posY, 0);
            Instantiate(spirit, spawnPos, Quaternion.identity);
        }
    }
}
