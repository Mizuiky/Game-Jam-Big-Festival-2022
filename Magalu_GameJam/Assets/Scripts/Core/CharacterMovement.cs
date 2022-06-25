using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private Points[] points = new Points[4];
        private Points point;
        private int count;
        private string state;

        private void Start()
        {
            state = points[0].identifier;
            count = points.Length-1;
            StartCoroutine(Move());

        }

        private void Update() {
            if(state == "moving")
            {
                transform.position = Vector3.Lerp(transform.position, point.transform.position, Time.deltaTime * 2f);

                if(Vector3.Distance(transform.position, point.transform.position)  <= 0.1f)
                {
                    state = point.identifier;
                }
            }
        }

        IEnumerator Move() {
            while(true) { 
                if(count < points.Length)
                {
                    Shuffle();
                    count = 0;
                }

                Debug.Log(points[count].identifier);
                point = points[count];
                state = "moving";
                count++;
                yield return new WaitForSeconds(5.0f);
            }
        }

        private void Shuffle()
        {
            Points tempGO;

            for (int i = 0; i < points.Length; i++)
            {
                int rnd = Random.Range(0, points.Length);
                tempGO = points[rnd];
                points[rnd] = points[i];
                points[i] = tempGO;
            }
        }
    }
}

