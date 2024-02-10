using System.Collections.Generic;
using UnityEngine;
using TMPro;
using YG;

public class Jokes : MonoBehaviour
{
    [SerializeField] private TextAsset _asset;
    [SerializeField] private TMP_Text _banter;

    [SerializeField] private Advertisement _advertisement;
    [SerializeField] private Timer _timerPause;

    private List<string> _jokesList;
    private string[] _array;
    private string _current;

    private int _currentValueADS = 0;

    private int _timeToADS;

    private void OnEnable()
    {
        _advertisement.CommercialsAreOver += HideTimerPanel;
    }

    private void OnDisable()
    {
        _advertisement.CommercialsAreOver -= HideTimerPanel;
    }

    private void Awake()
    {
        _jokesList = new List<string>();
        FillListTasks();
        HideTimerPanel();
    }

    private void Start()
    {
        SetRundomJokes();
    }

    private void HideTimerPanel() =>
        _timerPause.gameObject.SetActive(false);

    public List<string> DeleteCurentJokes()
    {
        _jokesList.Remove(_current);
        return _jokesList;
    }

    public void ADSPlus() =>
        _currentValueADS++;

    public void SetRundomJokes()
    {
        if (_jokesList.Count > 0)
        {
            int random = Random.Range(0, _jokesList.Count);
            _current = _jokesList[random];
            _banter.text = _current;

            ShowAdvertisement();
        }
    }

    private void ShowAdvertisement()
    {
        int value = 11;

        if (_currentValueADS == value)
        {
            _timeToADS = YandexGame.Instance.infoYG.fullscreenAdInterval - (int)YandexGame.timerShowAd;

            if (_timeToADS <= 0)
            {
#if UNITY_EDITOR == false
            _timerPause.gameObject.SetActive(true);
#endif
            }

            _currentValueADS = 0;
        }
    }

    private void FillListTasks()
    {
        _array = _asset.text.Split('/');

        for (int i = 0; i < _array.Length; i++)
            _jokesList.Add(_array[i]);
    }
}
