
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField]
    private Button _btnMute;
    [SerializeField]
    private Sprite _MuteActive;
    [SerializeField]
    private Sprite _MuteInActive;
    [SerializeField]
    private GameObject _PanelPausa;

    void Start()
    {
    }

    void Update()
    {

        
    }

    public void Pausar() 
    {
            Time.timeScale = 0;
          _PanelPausa.SetActive(true);
          gameObject.GetComponent<AudioSource>().Pause();
    }

    public void Renundar()
    {
        _PanelPausa.SetActive(false);
        Time.timeScale = 1;
        if(_btnMute.image.sprite != _MuteActive)
        gameObject.GetComponent<AudioSource>().Play();
        
    }

    public void Mute()
    {
     if(_btnMute.image.sprite == _MuteInActive)
        {
            _btnMute.image.sprite = _MuteActive;
           
        }
        else{
            _btnMute.image.sprite = _MuteInActive;
        }
    }

}
