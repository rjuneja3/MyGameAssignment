using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Util
{
    [System.Serializable]
    public class GameController : MonoBehaviour
    {
        [Header("Scene Game Objects")]
        public GameObject thief;


        [Header("Thief Control")]
        public int NumberOfThieves;
        public List<GameObject> thieves;

        // Start is called before the first frame update
        void Start()
        {
             for (int cloudNum = 0; cloudNum < NumberOfThieves; cloudNum++)
            {
                thieves.Add(Instantiate(thief));
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}