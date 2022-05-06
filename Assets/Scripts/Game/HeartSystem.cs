using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
public GameObject[] hearts;
public int life;

private void Update()
{
  if (life < 1)
  {
     Destroy(hearts[1].gameObject);
  }
  else if (life < 2)
  {
     Destroy(hearts[2].gameObject);
  }
  else if (life< 3)
  {
   Destroy(hearts[3].gameObject);  
      
}

}

public void TakeDamage(int d)
{
   life -= d;
}
}