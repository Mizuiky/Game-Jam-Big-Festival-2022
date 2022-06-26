using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public string _Cena;
    private Animator anim;

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
}
