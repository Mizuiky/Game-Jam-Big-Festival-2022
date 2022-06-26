using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public string _Cena;
    private Animator anim;
    [SerializeField] private TMP_Text volumeTextoValor = null;
    [SerializeField] private Slider volumeSlider = null;

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isIniciate", true);
    }

    void FixedUpdate()
    {
        anim.SetBool("isIniciate", false);
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene(_Cena);
    }

    public void AjustarVolume(float volume)
    {
        AudioListener.volume = volume;
        volumeTextoValor.text = volume.ToString("0%");
    }
    public void VolumeSet()
    {
        PlayerPrefs.SetFloat("VolumeGeral", AudioListener.volume);
    }
}
