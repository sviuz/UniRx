using TMPro;
using UniRx;
using UnityEngine;

public class TextManager : MonoBehaviour {
  [SerializeField] private TMP_Text _text;
  [SerializeField] private int _targetCount = 100;
  private CompositeDisposable _disposable = new CompositeDisposable();
  private int _counter;
  
  private void Start() {
    Observable.EveryUpdate().Subscribe(_ => {
      _counter++;
      UpdateText();
      if (_counter == _targetCount) {
        _disposable.Clear();
      }
    }).AddTo(_disposable);
  }

  private void UpdateText() {
    _text.SetText(_counter.ToString());
  }
}