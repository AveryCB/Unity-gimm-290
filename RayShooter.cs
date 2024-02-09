using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RayShooter : MonoBehaviour 
{
 private Camera cam;
 void Start() 
 {
 cam = GetComponent<Camera>();
 Cursor.lockState = CursorLockMode.Locked; 
 Cursor.visible = false;
 }
 void OnGUI()
 {
    int size = 12;
    float posx = cam.pixelWidth/3 - size/20;
    float posy = cam.pixelHeight/2 - size/20;
    GUI.Label(new Rect(posx, posy, size, size),"*");
 }
 void Update() 
 { 
 if (Input.GetMouseButtonDown(0))
  {
 Vector3 point = new Vector3(cam.pixelWidth/2, cam.pixelHeight/2, 0);
 Ray ray = cam.ScreenPointToRay(point);
 RaycastHit hit;
 if (Physics.Raycast(ray, out hit)) 
 {
 GameObject hitObject = hit.transform.gameObject; 
 ReactiveTarget target = hitObject.GetComponent<ReactiveTarget>();
 if (target != null)
  { 
if (target != null) 
{
 target.ReactToHit(); 
} else {
 StartCoroutine(SphereIndicator(hit.point));
}
}
 }
 
 IEnumerator SphereIndicator(Vector3 pos) { 
 GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
 sphere.transform.position = pos;
 yield return new WaitForSeconds(1); 
 Destroy(sphere); 
 }
 }
 }
}
 
