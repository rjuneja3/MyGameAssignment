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

        [Header("Audio Sources")]
        public SoundClip activeSoundClip;
        public AudioSource[] audioSources;

        // Start is called before the first frame update
        void Start()
        {
             for (int thiefNum = 0; thiefNum < NumberOfThieves; thiefNum++)
            {
                Debug.Log("Loaded");
                thieves.Add(Instantiate(thief));
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}