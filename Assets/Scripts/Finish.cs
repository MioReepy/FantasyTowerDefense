using PlayerSpace;
using UISpace;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private int _enemyCount;
    private int _lifeCount;
    
    public static Finish Instance;
    private void Awake() => Instance = this;

    private void Start()
    {
        PlayerStats.Instance.OnChangeLifes += PlayerStats_OnChangeLifes;
        _lifeCount = PlayerStats.Instance.lifes;
    }

    private void PlayerStats_OnChangeLifes(object sender, PlayerStats.OnLifes lifes)
    {
        _lifeCount = lifes.lifesCount;
        
        if (lifes.lifesCount <= 0)
        {
            UISystem.Instance.OpenWindow(WindowType.GameOver);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            PlayerStats.Instance.SetLifes();
            _enemyCount--;

            if (_enemyCount < 1 && _lifeCount > 0)
            {
                ShowCompleteLevel();
            }
        }
    }

    internal void SetEnemy(int enemyCount)
    {
        _enemyCount += enemyCount;
    }

    internal void EnemyDied()
    {
        _enemyCount--;
        Debug.Log(_lifeCount);

        if (_enemyCount <= 1 && _lifeCount > 0)
        {
            ShowCompleteLevel();
        }
    }

    private void ShowCompleteLevel()
    {
        UISystem.Instance.OpenWindow(WindowType.CompleteLevel);
        Time.timeScale = 0;
    }
}
