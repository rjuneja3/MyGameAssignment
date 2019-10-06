using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
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

        [Header("Scoreboard")]
        [SerializeField]
        private int _lives;

        [SerializeField]
        private int _score;

        [Header("Labels")]
        public Text livesLabel;
        public Text scoreLabel;
        //Sets the value of live on screen.
        public int Lives
        {
            get
            {
                return _lives;
            }

            set
            {
                _lives = value;
                if (_lives < 1)
                {

                    SceneManager.LoadScene("Main");
                }
                else
                {
                    livesLabel.text = "Lives: " + _lives.ToString();
                }

            }
        }
        //set the valus of score on screen
        public int Score
        {
            get
            {
                return _score;
            }

            set
            {
                _score = value;

                scoreLabel.text = "Score: " + _score.ToString();


            }
        }

        // first function that runs on startup
        void Start()
        {
            // values initialized
            Lives = 5;
            Score = 0;
        
            // Enemies spawn code 
            for (int thiefNum = 0; thiefNum < NumberOfThieves; thiefNum++)
            {
                thieves.Add(Instantiate(thief));
            }
        }
    }
}