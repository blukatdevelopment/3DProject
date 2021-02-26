namespace Input
{
  using Godot;
  using System.Collections.Generic;
  using Input;

  public class InputConstants
  {
    public const float LongPressDuration = 0.5f;

    public static List<KeyMapping> DefaultKeyMappings()
    {
      return new List<KeyMapping>
      {
        new KeyMapping((int)KeyList.W, InputModeEnum.PressStart, ActionEnum.MoveUpStart),
        new KeyMapping((int)KeyList.W, InputModeEnum.PressEnd, ActionEnum.MoveUpEnd),
        new KeyMapping((int)KeyList.S, InputModeEnum.PressStart, ActionEnum.MoveDownStart),
        new KeyMapping((int)KeyList.S, InputModeEnum.PressEnd, ActionEnum.MoveDownEnd),
        new KeyMapping((int)KeyList.D, InputModeEnum.PressStart, ActionEnum.MoveRightStart),
        new KeyMapping((int)KeyList.D, InputModeEnum.PressEnd, ActionEnum.MoveRightEnd),
        new KeyMapping((int)KeyList.A, InputModeEnum.PressStart, ActionEnum.MoveLeftStart),
        new KeyMapping((int)KeyList.A, InputModeEnum.PressEnd, ActionEnum.MoveLeftEnd),
        new KeyMapping((int)KeyList.Space, InputModeEnum.PressStart, ActionEnum.FireStart),
        new KeyMapping((int)KeyList.Space, InputModeEnum.PressEnd, ActionEnum.FireEnd),
      };
    }
  }
}