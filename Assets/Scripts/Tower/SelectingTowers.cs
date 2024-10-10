using System.Collections;
using UnityEngine;

namespace TowerSpace
{
    public class SelectingTowers : MonoBehaviour
    {
        [SerializeField] private GameObject _light;
        [SerializeField] private GameObject _lightClick;
        private float _timeLight;
        private float _timeLightClick;

        private void Start()
        {
            _timeLight = _light.GetComponent<ParticleSystem>().main.duration / 2;
            _timeLightClick = _lightClick.GetComponent<ParticleSystem>().main.duration / 2;
        }

        private void OnMouseEnter()
        {
            StartCoroutine(OnEnter());
        }

        private void OnMouseExit()
        {
            StartCoroutine(OnExit());
        }
        
        private void OnMouseDown()
        {
            StartCoroutine(OnClick());
        }

        private IEnumerator OnClick()
        {
            _lightClick.SetActive(true);
            _lightClick.GetComponent<ParticleSystem>().Play();
            _light.SetActive(false);
            yield return new WaitForSeconds(_timeLight);
            _lightClick.GetComponent<ParticleSystem>().Pause();
        }

        private IEnumerator OnEnter()
        {
            if (!_lightClick.GetComponent<ParticleSystem>().isPaused)
            {
                _light.SetActive(true);
                _light.GetComponent<ParticleSystem>().Play();
                yield return new WaitForSeconds(_timeLight);
                _light.GetComponent<ParticleSystem>().Pause();   
            }
        }
        
        private IEnumerator OnExit()
        {
            if (!_light.GetComponent<ParticleSystem>().isPlaying)
            {
                _light.GetComponent<ParticleSystem>().Play();
            }
            
            yield return new WaitForSeconds(_timeLight);
            _light.GetComponent<ParticleSystem>().Stop();
            _light.SetActive(false);
        }
    }
}