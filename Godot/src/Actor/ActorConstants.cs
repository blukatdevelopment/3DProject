namespace Actor
{
  using Godot;

  public class ActorConstants
  {
    public const float ActionHandlingDelay = 0.03f;
    public const string DebugActorScene = "res://Assets/Global/Scenes/DebugActor.tscn";
    public const string DebugActorHeadKBody = "HeadKBody";

    public static Actor HumanoidActor(bool addCamera)
    {
      Actor actor = new Actor();
      actor.stats = new Stats();
      PackedScene packedBodyScene = (PackedScene)ResourceLoader.Load(DebugActorScene);
      actor.body = packedBodyScene.Instance() as Body;
      actor.body.AssignActor(actor, addCamera, DebugActorHeadKBody);

      return actor;
    }
  }
}