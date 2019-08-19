using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformerFinishLine : MonoBehaviour {

    public ScoreboardManager scoreboard;

    bool didIWin;

    void Start()
    {
        if(!scoreboard)
            scoreboard = FindObjectOfType<ScoreboardManager>();
    }

	void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<GameController2D>())
        {
            StartCoroutine(PlatformerFinished());
        }
    }

    IEnumerator PlatformerFinished()
    {
        
        didIWin = true ? (scoreboard.currentScore > scoreboard.scoreToWin) : false;

        JumpingGameEventSystem.OnEndLevel(didIWin);

            yield return new WaitForSeconds(3f);

            if (didIWin == true)
            {
                Scene platformScene = SceneManager.GetActiveScene();
                CastleEventSystem.OnPlatformFinished();

                try { SceneManager.SetActiveScene(SceneManager.GetSceneByName("01_5_Castle_Interior")); }
                catch (System.ArgumentException)
                {
                    Debug.Log("Setting 01_5_Castle_Interior to active (but it is not loaded)");
                    yield break;
                }
                SceneManager.UnloadSceneAsync(platformScene);
            }
            else
            {
                JumpingGameEventSystem.OnLevelReset();
            }
        
        }

        
}
