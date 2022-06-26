using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour


{
    public string _NovaCena;
    private Animator anim;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        anim.SetBool("isIniciate", true);
    }
    void FixedUpdate()
    {
        anim.SetBool("isIniciate", false);
    }
    public void NovoJogo()
    {
        SceneManager.LoadScene(_NovaCena);
    }
}
