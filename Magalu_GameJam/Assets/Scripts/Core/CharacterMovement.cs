using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core
{
    public class CharacterMovement : MonoBehaviour
    {
        [SerializeField]
        private Transform[] routes;

        [SerializeField]
        private int routeToGo = 0;
        [SerializeField]
        private int previousRoute = 0;
        [SerializeField]
        private bool moveFoward = true;
        [SerializeField]
        private bool coroutineAllowed = false;

        private float speedModifier;
        private float tParam;
        private Vector2 characterPosition;

        public delegate void OnChangedRoom(HouseRooms _currentRoom);
        public static event OnChangedRoom onChangedRoom;

        private void Start()
        {
            routeToGo = 0;
            tParam = 0f;
            speedModifier = 0.5f;
            coroutineAllowed = true;
        }

        private void Update()
        {
            if (coroutineAllowed)
            {
                StartCoroutine(Move());
            }
        }

        private IEnumerator Move()
        {
            bool previousMV = moveFoward;
            routeToGo = Random.Range(0, routes.Length);

            if (routeToGo > previousRoute)
            {
                moveFoward = true;
            }
            else if (routeToGo == previousRoute)
            {
                moveFoward = !moveFoward;
            }
            else
            {
                moveFoward = false;
            }

            List<Transform> selectedRoutes = new List<Transform>();
            if (moveFoward)
            {
                for (int i = previousRoute; i <= routeToGo; i++)
                {
                    if (previousMV && i == previousRoute)
                    {
                        continue;
                    }
                    selectedRoutes.Add(routes[i]);
                }
            }
            else
            {
                for (int i = previousRoute; i >= routeToGo; i--)
                {
                    if (!previousMV && i == previousRoute)
                    {
                        continue;
                    }
                    selectedRoutes.Add(routes[i]);
                }
            }

            StartCoroutine(MoveThroughBezier(selectedRoutes, moveFoward));


            yield return new WaitForSecondsRealtime(10.0f);
            previousRoute = routeToGo;
            coroutineAllowed = true;
        }

        private IEnumerator MoveThroughBezier(List<Transform> routes, bool moveFoward)
        {
            coroutineAllowed = false;

            foreach (Transform r in routes)
            {
                Vector2 p0 = r.GetChild(3).position;
                Vector2 p1 = r.GetChild(2).position;
                Vector2 p2 = r.GetChild(1).position;
                Vector2 p3 = r.GetChild(0).position;

                if (moveFoward)
                {
                    p0 = r.GetChild(0).position;
                    p1 = r.GetChild(1).position;
                    p2 = r.GetChild(2).position;
                    p3 = r.GetChild(3).position;
                }

                while (tParam < 1)
                {
                    tParam += Time.deltaTime * speedModifier;

                    characterPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                    3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                    3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                    Mathf.Pow(tParam, 3) * p3;

                    transform.position = characterPosition;
                    yield return new WaitForEndOfFrame();
                }

                tParam = 0f;
            }

            SetRoom();

        }

        private void SetRoom()
        {
            var houseRoom = HouseRooms.Bedroom;

            if (routeToGo == 0 && !moveFoward)
            {
                houseRoom = HouseRooms.Bedroom;

            }
            else if (routeToGo == 0 && moveFoward)
            {
                houseRoom = HouseRooms.Kitchen;
            }
            else if (routeToGo == 1 && !moveFoward)
            {
                houseRoom = HouseRooms.Kitchen;
            }
            else if (routeToGo == 1 && moveFoward)
            {
                houseRoom = HouseRooms.LivingRoom;
            }
            else if (routeToGo == 2 && !moveFoward)
            {
                houseRoom = HouseRooms.LivingRoom;
            }
            else if (routeToGo == 2 && moveFoward)
            {
                houseRoom = HouseRooms.Garden;
            }

            onChangedRoom?.Invoke(houseRoom);
        }
    }
}
