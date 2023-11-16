using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class MinimapCotroller : MonoBehaviour
 {
 public Transform player;

 private void LateUpdate()
 {
     Vector3 newposition = player.position;
     newposition.y = transform.position.y;
     transform.position = newposition;
 }
}
