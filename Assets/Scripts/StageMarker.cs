using chadsadaporn_babpa.Exam;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageMarker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameResult.LastStage = SceneManager.GetActiveScene().name;
        Debug.Log("StageMarker: LastStage = " + GameResult.LastStage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
