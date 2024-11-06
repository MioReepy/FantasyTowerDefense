using UnityEngine;
using UnityEngine.UI;
using WaveSpawnerSpace;

namespace UISpace
{
    public class WaveCoolDown : MonoBehaviour
    {
        [SerializeField] private Image _counter;

        private void Update()
        {
            WaveSpawner.Instance.coolDownWaves -= Time.deltaTime;
            
            if (WaveSpawner.Instance.coolDownWaves < 0)
            {
                _counter.gameObject.SetActive(false);
            }
            else
            {
                _counter.gameObject.SetActive(true);
                _counter.fillAmount = WaveSpawner.Instance.coolDownWaves / WaveSpawner.Instance._timeBetweenWaves;
            }
        }
    }
}