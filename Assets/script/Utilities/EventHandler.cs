using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventHandler 
{
    public static event Action<string, Vector3> TransitionEvent;//传送

    public static void CallTransitionEvent(string sceneName,Vector3 pos)
    {
        TransitionEvent?.Invoke(sceneName, pos);
    }

    public static event Action<Vector3> MoveToPosition;//确定传送坐标

    public static void CallMoveToPosition(Vector3 targetPosition)
    {
        MoveToPosition?.Invoke(targetPosition);
    }
}
