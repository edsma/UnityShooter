using UnityEngine;
using UnityEngine.SceneManagement;

public class GameModeWaves : MonoBehaviour
{

    [SerializeField]
    private Life playerLife;
    [SerializeField]
    private Life baseLife;

    private void Awake()
    {
        playerLife.onDeath.AddListener(CheckLoseCondition);
        baseLife.onDeath.AddListener(CheckLoseCondition);
        EnemyManager.SharedInstance.onEnemyChange.AddListener(CheckWinCondition);
        WaveManager.SharedInstance.OnWaveChange.AddListener(CheckWinCondition);
    }

    void CheckLoseCondition()
    {
        if (playerLife.Amount <= 0)
        {
            SceneManager.LoadScene(Constantes.Scenes.loseScene, LoadSceneMode.Single);
        }
    }

    void CheckWinCondition()
    {
        //GANAR
        if (EnemyManager.SharedInstance.Enemies <= 0 && WaveManager.SharedInstance.Waves <= 0)
        {
            SceneManager.LoadScene(Constantes.Scenes.winScene, LoadSceneMode.Additive);
        }
    }


}
