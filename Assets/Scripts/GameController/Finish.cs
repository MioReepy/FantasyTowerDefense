using PlayerSpace;
using UISpace;
using UnityEngine;

namespace GameController
{
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

            if (lifes.lifesCount > 0) return;
            
            UISystem.Instance.OpenWindow(WindowType.GameOver);
            Time.timeScale = 0;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Enemy")) return;
            
            other.gameObject.SetActive(false);
            PlayerStats.Instance.SetLifes();
            _enemyCount--;
            SoundManager.Instance.PlayerDamageSound();
            
            if (_enemyCount < 1 && _lifeCount > 0)
            {
                ShowCompleteLevel();
            }
        }

        internal void SetEnemy(int enemyCount)
        {
            _enemyCount += enemyCount;
        }

        internal void EnemyDied()
        {
            SoundManager.Instance.EnemyDieSound();
            _enemyCount--;

            if (_enemyCount >= 1 || _lifeCount <= 0) return;
            
            ShowCompleteLevel();
        }

        private void ShowCompleteLevel()
        {
            UISystem.Instance.OpenWindow(WindowType.CompleteLevel);
            Time.timeScale = 0;
        }
        
        private void OnDisable()
        {
            PlayerStats.Instance.OnChangeLifes -= PlayerStats_OnChangeLifes;
        }
    }
}