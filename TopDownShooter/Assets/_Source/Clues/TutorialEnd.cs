using UI;
using UnityEngine;
using Zenject;

public class TutorialEnd : MonoBehaviour
{
    private WinView _winView;
    private int _helper;

    void Update()
    {
        _helper = 0;
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            if (!gameObject.transform.GetChild(i).gameObject.activeInHierarchy)
                _helper++;
        }

        if (_helper == gameObject.transform.childCount)
            _winView.DrawWinPanel();
    }

    [Inject]
    public void Construct(WinView winView)
    {
        _winView = winView;
    }
}
