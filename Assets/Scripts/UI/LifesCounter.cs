using PlayerSpace;
using TMPro;
using UnityEngine;

namespace UISpace
{
    public class LifesCounter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _lifesCounter;

        private void Start()
        {
            PlayerStats.Instance.OnChangeLifes += PlayerStats_OnChangeLifes;
        }

        private void PlayerStats_OnChangeLifes(object sender, PlayerStats.OnLifes moneyArgs)
        {
            _lifesCounter.text = moneyArgs.lifesCount.ToString();
        }
        
        private void OnDisable()
        {
            PlayerStats.Instance.OnChangeLifes -= PlayerStats_OnChangeLifes;
        }
    }
}