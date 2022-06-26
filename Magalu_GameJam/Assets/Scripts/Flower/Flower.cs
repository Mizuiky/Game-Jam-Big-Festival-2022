using System.Collections.Generic;
using UnityEngine;

public class Flower : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> petals;

    private void Start()
    {
        HideFlowerPetals();
    }

    private void HideFlowerPetals()
    {
        petals.ForEach(petals => petals.gameObject.SetActive(false));
    }

    public void EnablePetal(int index)
    {
        if(!petals[index].gameObject.activeInHierarchy)
            petals[index].gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        HideFlowerPetals();
    }
}
