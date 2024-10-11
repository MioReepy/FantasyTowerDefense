using TMPro;
using UnityEngine;
using WaveSpawnerSpace;

namespace UISpace
{
    public class WaveCoolDown : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _counter;
        private void Update()
        {
            if (WaveSpawner.Instance.coolDownWaves < 0)
            {
                _counter.gameObject.SetActive(false);
            }
            else
            {
                _counter.gameObject.SetActive(true);
                _counter.text = Mathf.Round(WaveSpawner.Instance.coolDownWaves).ToString();
            }
            
            WaveSpawner.Instance.coolDownWaves -= Time.deltaTime;
        }
    }
}