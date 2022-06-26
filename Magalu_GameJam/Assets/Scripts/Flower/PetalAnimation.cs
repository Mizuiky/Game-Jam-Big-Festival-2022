using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalAnimation : MonoBehaviour
{
    private Petal _petal;

    public void Start()
    {
        _petal = GetComponentInParent<Petal>();
    }

    public void DisablePetal()
    {
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        Shine();

        AudioController.Instance.Play("Brilhar");

        yield return new WaitForSeconds(_petal.timeToDesapear);

        ItemManager.Instance.ShowPetal();

        Deactivate();
    }

    private void Shine()
    {
        //particulas brilhantes
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
