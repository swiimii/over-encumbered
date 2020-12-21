using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LocalPlayerInput
{
    public static float GetHorizontalMovement(string inputDevice = "MouseAndKeyboard")
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public static bool IsPressingJump(string inputDevice = "MouseAndKeyboard")
    {
        var IsJumpingDeadZone = .5f;
        return Input.GetAxisRaw("Vertical") > IsJumpingDeadZone;
    }
}
