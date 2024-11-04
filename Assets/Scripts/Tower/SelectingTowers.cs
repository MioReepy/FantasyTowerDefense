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

        private bool _isTowerSelected;

        public static event EventHandler<OnSelected> OnTowerSelected;
        public static event EventHandler<OnSelected> OnTowerUnselected;
        
        public class OnSelected : EventArgs
        {
            public GameObject TowerSelected;
        }
        
        private void Start()
        {
            InputPlayerController.Instance.OnClick += InputPlayerController_OnClick;
            InputPlayerController.Instance.OnUnselect += InputPlayerController_OnUnselect;

            _timeLight = _light.GetComponent<ParticleSystem>().main.duration / 2;
            _timeLightClick = _lightClick.GetComponent<ParticleSystem>().main.duration / 2;
        }

        private void InputPlayerController_OnClick(object sender, EventArgs e)
        {
            if (_lightClick.GetComponent<ParticleSystem>().isPlaying ||
                _lightClick.GetComponent<ParticleSystem>().isPaused)
            {
                OnEscapeDown();
            }
        }

        private void InputPlayerController_OnUnselect(object sender, EventArgs e)
        {
            OnEscapeDown();
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
            if (_lightClick.GetComponent<ParticleSystem>().isStopped && !_isTowerSelected)
            {
                _isTowerSelected = true;
                StartCoroutine(OnMouseClick());
                
                OnTowerSelected?.Invoke(this, new OnSelected
                {
                    TowerSelected = gameObject
                });
            }
        }

        private void OnEscapeDown()
        {
            StartCoroutine(OnEscapeClick());
            _isTowerSelected = false;
            
            OnTowerUnselected?.Invoke(this, new OnSelected
            {
                TowerSelected = gameObject
            });
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