using System;
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                OnEscapeDown();
            }
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
            StartCoroutine(OnMouseClick());
        }

        private void OnEscapeDown()
        {
            StartCoroutine(OnEscapeClick());
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

        private IEnumerator OnMouseClick()
        {
            _lightClick.SetActive(true);
            _lightClick.GetComponent<ParticleSystem>().Play();
            _light.SetActive(false);
            yield return new WaitForSeconds(_timeLightClick);
            _lightClick.GetComponent<ParticleSystem>().Pause();
        }

        private IEnumerator OnEscapeClick()
        {
            if (!_lightClick.GetComponent<ParticleSystem>().isPlaying)
            {
                _lightClick.GetComponent<ParticleSystem>().Play();
            }
            
            yield return new WaitForSeconds(_timeLightClick);
            _lightClick.GetComponent<ParticleSystem>().Stop();
            _lightClick.SetActive(false);
        }
    }
}