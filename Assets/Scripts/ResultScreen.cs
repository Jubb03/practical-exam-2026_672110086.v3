using chadsadaporn_babpa.Exam;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace chadsadaporn_babpa.Exam
{
    public class ResultScreen : MonoBehaviour
    {
        [SerializeField] TMP_Text scoreText;

        void Start()
        {
            scoreText.text = $"Score: {GameResult.Score:00000}";
        }

        public void TryAgain()
        {
            Debug.Log("TryAgain -> " + GameResult.LastStage);
            SceneManager.LoadScene(GameResult.LastStage);
        }
    }
}