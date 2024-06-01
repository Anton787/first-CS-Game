using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : Button
{
    [SerializeField] GameObject _normal;
    [SerializeField] GameObject _select;

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
        base.DoStateTransition(state, instant);

        _normal.SetActive(state!=SelectionState.Pressed);
        _select.SetActive(state==SelectionState.Pressed);
    }
    //Позволяет создать два состояния текста для конопок в меню, не теряя при этом функционал простой кнопки.
    //Для работы требует CustomButtonEditor
}
