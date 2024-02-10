using UnityEngine;
using UnityEngine.UI;

public class NextClick : MonoBehaviour
{
    [SerializeField] private Button _buttonLike;
    [SerializeField] private Button _buttonLDis;

    [SerializeField] private Jokes _jokes;

    public void Click()
    {
        _jokes.DeleteCurentJokes();
        _jokes.SetRundomJokes();
        _jokes.ADSPlus();
    }
}
