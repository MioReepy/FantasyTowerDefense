using TMPro;
using UnityEngine;
using UnityEngine.UI;
using WaveSpawnerSpace;

namespace UISpace
{
    public class WaveCoolDown : MonoBehaviour
    {
        [SerializeField] private Image _timer;
        [SerializeField] private TextMeshProUGUI _counter;

        private void Update()
        {
            WaveSpawner.Instance.coolDownWaves -= Time.deltaTime;

            if (WaveSpawner.Instance._currentWave <= WaveSpawner.Instance.waves.Length - 1)
            {
                _counter.text = $"Waves: {WaveSpawner.Instance._currentWave + 1}/{WaveSpawner.Instance.waves.Length}";
            }
            else
            {
                _counter.text = $"Waves: {WaveSpawner.Instance._currentWave}/{WaveSpawner.Instance.waves.Length}";
            }
            
            if (WaveSpawner.Instance.coolDownWaves < 0)
            {
                _timer.gameObject.SetActive(false);
            }
            else
            {
                _timer.gameObject.SetActive(true);
                _timer.fillAmount = WaveSpawner.Instance.coolDownWaves / WaveSpawner.Instance._timeBetweenWaves;
            }
        }
    }
}