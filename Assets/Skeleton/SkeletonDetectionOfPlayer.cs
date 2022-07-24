using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CustomEditor (typeof (Skeleton))]
public class SkeletonDetectionOfPlayer : Editor
{
	void OnSceneGUI(){
		Skeleton fow = (Skeleton)target;
		Handles.color = Color.white;
		Handles.DrawWireArc(fow.transform.position, Vector3.up, Vector3.forward, 360, fow.viewRadius);
	}
}
