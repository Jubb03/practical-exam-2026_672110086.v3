using chadsadaporn_babpa.Exam;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace chadsadaporn_babpa.Exam
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        [SerializeField] float timeLimit = 30f;
        [SerializeField] int targetScore = 10000;
        [SerializeField] TMP_Text timeText;
        [SerializeField] TMP_Text scoreText;

        float m_TimeLeft;
        int m_Score;
        bool m_Ended;

        void Awake() { Instance = this; }

        void Start()
        {
            GameResult.LastStage = SceneManager.GetActiveScene().name;
            m_TimeLeft = timeLimit;
            Refresh();
        }

        void Update()
        {
            if (m_Ended) return;
            m_TimeLeft -= Time.deltaTime;
            if (m_TimeLeft <= 0f)
            {
                m_TimeLeft = 0f;
                End(m_Score >= targetScore);
            }
            Refresh();
        }

        public void AddTime(float seconds) { m_TimeLeft += seconds; }
        public void AddScore(int points) { m_Score = Mathf.Max(0, m_Score + points); }
        public void Lose() { End(false); }

        void End(bool win)
        {
            if (m_Ended) return;
            m_Ended = true;
            GameResult.Score = m_Score;
            SceneManager.LoadScene(win ? "Win" : "GameOver");
        }

        void OnDestroy()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        void Refresh()
        {
            timeText.text = $"Time: {Mathf.CeilToInt(m_TimeLeft)}";
            scoreText.text = $"Score: {m_Score}";
        }
    }
}