namespace Battle
{
  using Input;
  using System.Collections.Generic;
  using Godot;
  using Actor;

  public class BattleConstants
  {
    public const string InfantryScene = "res://Assets/Battle/Scenes/InfantryActor.tscn";
    public const string InfantryTorso = "TorsoCShape";
    public const float BaseInfantrySpeed = 1f;
    public const float MaxInfantryLookAngle = 120f;
    
    public static Vector3 Gravity()
    {
      // Should be meters squared per second, but whatevs
      return new Vector3(0f, -0.5f, 0f);
    }

    public static List<KeyMapping> BattleKeyMappings()
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
        new KeyMapping((int)KeyList.Escape, InputModeEnum.PressEnd, ActionEnum.TogglePlayerPause)
      };
    }

    public static List<AxisMapping> BattleAxisMappings()
    {
      return new List<AxisMapping>
      {
        new AxisMapping(AxisEnum.MouseX, 1f, ActionEnum.AimHorizontal, 0.1f),
        new AxisMapping(AxisEnum.MouseY, 1f, ActionEnum.AimVertical, 0.1f)
      };
    }

    public static Actor Infantry(bool addCamera, Vector3 position)
    {
      Actor actor = new Actor();
      actor.stats = new Stats();
      PackedScene packedBodyScene = (PackedScene)ResourceLoader.Load(InfantryScene);
      InfantryBody body = packedBodyScene.Instance() as InfantryBody;
      body.AssignActor(actor, addCamera, ActorConstants.DebugActorHeadKBody, InfantryTorso);
      body.movementSpeed = BaseInfantrySpeed;
      body.Translation = position;
      actor.body = body;


      return actor;
    }
  }
}