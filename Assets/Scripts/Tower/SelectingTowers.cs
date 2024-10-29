using System;
using System.Collections;
using PlayerSpace;
using UnityEngine;

namespace TowerSpace
{
    public class SelectingTowers : MonoBehaviour
    {
        [SerializeField] private GameObject _light;
        [SerializeField] private GameObject _lightClick;
        private float _timeLight;
        private float _timeLightClick;

        internal bool isTowerSelected;
        
        public event EventHandler OnTowerSelected;

        private void Start()
        {
            InputPlayerController.Instance.OnClick += InputPlayerController_OnClick;
            
            _timeLight = _light.GetComponent<ParticleSystem>().main.duration / 2;
            _timeLightClick = _lightClick.GetComponent<ParticleSystem>().main.duration / 2;
        }

        private void InputPlayerController_OnClick(object sender, EventArgs e)
        {
            if (_lightClick.GetComponent<ParticleSystem>().isPlaying || _lightClick.GetComponent<ParticleSystem>().isPaused)
            {
                OnEscapeDown();
            }
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
            if (_lightClick.GetComponent<ParticleSystem>().isStopped && !isTowerSelected)
            {
                isTowerSelected = true;
                StartCoroutine(OnMouseClick());
                OnTowerSelected?.Invoke(this, EventArgs.Empty);
            }
        }

        private void OnEscapeDown()
        {
            StartCoroutine(OnEscapeClick());
            isTowerSelected = false;
        }

        private IEnumerator OnEnter()
        {
            if (_lightClick.GetComponent<ParticleSystem>().isStopped)
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

        private void OnDisable()
        {
            InputPlayerController.Instance.OnClick -= InputPlayerController_OnClick;

        }
    }
}