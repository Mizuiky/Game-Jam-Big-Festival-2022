using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> petals;

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        petals.ForEach(petals => petals.gameObject.SetActive(false));
    }

    public void EnablePetal(int index)
    {
        petals[index].gameObject.SetActive(true);
    }
}
