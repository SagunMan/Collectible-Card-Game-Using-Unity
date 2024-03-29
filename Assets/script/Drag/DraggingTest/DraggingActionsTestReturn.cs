﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DraggingActionsTestReturn : DraggingActionsTest
{
    private Vector3 savedPos;

    public override void OnStartDrag()
    {
        savedPos = transform.position;
    }

    public override void OnEndDrag()
    {
        transform.DOMove(savedPos, 1f).SetEase(Ease.OutQuint, 0.5f, 0.1f);//0.5f,0.1f
    }

    public override void OnDraggingInUpdate(){}

    protected override bool DragSuccessful()
    {
        return true;
    }
}
