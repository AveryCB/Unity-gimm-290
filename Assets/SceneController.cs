 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 public class SceneController : MonoBehaviour {
  [SerializeField] GameObject enemyPrefab;     
  private GameObject enemy;                
  private Vector3 scaleChange, positionChange;
  void Awake()
  {
      scaleChange = new Vector3(-0.01f, -0.01f, -0.01f);
        positionChange = new Vector3(0.0f, -0.005f, 0.0f);
  }
  void Update() 
  {
    if (enemy == null) 
    {             
      enemy = Instantiate(enemyPrefab) as GameObject; 
      enemy.transform.position = new Vector3(0, 1, 0);
      float angle = Random.Range(0, 360);
      enemy.transform.Rotate(0, angle, 0);
    }
    enemy.transform.localScale += scaleChange;
        enemy.transform.position += positionChange;
        if (enemy.transform.localScale.y < 0.1f || enemy.transform.localScale.y > 1.0f)
        {
            scaleChange = -scaleChange;
            positionChange = -positionChange;
  }
  }
 }