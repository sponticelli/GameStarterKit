using System.Collections;
using LiteNinja.SOA.Events;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace LiteNinja.GSK.Systems
{
  /// <summary>
  /// Loads a scene in Unity that contains Systems used in every scenes and raises an event after a specified delay.
  /// </summary>
  [DefaultExecutionOrder(-1000)]
  public class LoadSystems : MonoBehaviour
  {
    /// <summary>
    /// The name of the scene to be loaded.
    /// </summary>
    [SerializeField] private string sceneName = "Systems";

    /// <summary>
    /// The event that is raised after the specified delay.
    /// </summary>
    [SerializeField] private GameEvent onSystemsLoaded;

    /// <summary>
    /// The delay in seconds to wait before raising the event.
    /// </summary>
    [SerializeField] private float delay = 0.1f;

    private void Awake()
    {
      var alreadyLoaded = true;
      var activeSceneName = SceneManager.GetActiveScene().name;

      // if the scene is not loaded, load it
      if (!SceneManager.GetSceneByName(sceneName).isLoaded)
      {
        alreadyLoaded = false;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
      }

      if (activeSceneName == sceneName)
      {
        //Set as active scene one different from the loaded scenes that has a name different from sceneName
        var sceneCount = SceneManager.sceneCount;
        for (var i = 0; i < sceneCount; i++)
        {
          var scene = SceneManager.GetSceneAt(i);
          if (scene.name == sceneName) continue;
          StartCoroutine(SetActiveScene(scene));
          break;
        }
      }
      else
      {
        // If the delay is zero or negative, raise the event immediately
        if (delay <= 0 || alreadyLoaded)
        {
          Raise();
        }
        else
        {
          StartCoroutine(DelayedRaiseEvent());
        }
      }
    }

    private IEnumerator SetActiveScene(Scene scene)
    {
      yield return new WaitForEndOfFrame();
      SceneManager.SetActiveScene(scene);
      Raise();
    }

    /// <summary>
    /// A coroutine that waits for the specified delay and then raises the event.
    /// </summary>
    /// <returns>A wait for seconds operation that yields control back to the calling thread until the specified time elapses.</returns>
    private IEnumerator DelayedRaiseEvent()
    {
      yield return new WaitForSeconds(delay);
      Raise();
    }

    private void Raise()
    {
      onSystemsLoaded?.Raise();
      Destroy(gameObject);
    }
  }
}