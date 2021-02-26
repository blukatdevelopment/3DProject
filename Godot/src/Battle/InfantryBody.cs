namespace Battle
{
  using Actor;
  using Input;
  using Godot;
  using Global;

  public class InfantryBody : Body
  {
    [Export]
    public float movementSpeed;
    [Export]
    public Vector3 movement;
    [Export]
    public Vector3 aimMagnitude;

    public CollisionShape torso;

    public override void HandleAction(ActionEvent actionEvent)
    {
      aimMagnitude = new Vector3();
      HandlePause(actionEvent);
      
      if(!paused)
      {
        HandleStrafing(actionEvent);
        HandleAiming(actionEvent);
      }
    }

    public void AssignActor(Actor actor, bool addCamera, string headNodePath, string torsoPath)
    {
      this.actor = actor;
      head = FindNode(headNodePath) as KinematicBody;
      if(addCamera)
      {
        camera = new Camera();
        head.AddChild(camera);
      }
      torso = FindNode(torsoPath) as CollisionShape;
      Resume();
    }

    public override void PostEventsUpdate()
    {
      if(!paused)
      {
        Move(movement);
        Move(BattleConstants.Gravity());
        Aim(aimMagnitude);
        aimMagnitude = new Vector3();
      }
    }

    public void Aim(Vector3 aimMagnitude)
    {
      Vector3 bodyRotation = RotationDegrees;
      // X axis is reversed for whatever reason
      bodyRotation.y -= aimMagnitude.x;
      RotationDegrees = bodyRotation;

      Vector3 torsoRotation = torso.RotationDegrees;

      torsoRotation.x -= aimMagnitude.y;
      torsoRotation.x = Utility.Clamp(torsoRotation.x, -BattleConstants.MaxInfantryLookAngle, BattleConstants.MaxInfantryLookAngle);
      torso.RotationDegrees = torsoRotation;
    }

    public override void Move(Vector3 direction)
    {
      Transform current = Transform;
      Transform destination = current;
      destination.Translated(direction);

      Vector3 delta = destination.origin - current.origin;
      KinematicCollision collision = MoveAndCollide(delta);
    }

    public override void Pause()
    {
      paused = true;
      Input.SetMouseMode(Input.MouseMode.Visible);
    }

    public override void Resume()
    {
      paused = false;
      Input.SetMouseMode(Input.MouseMode.Captured);
    }

    protected void HandleStrafing(ActionEvent actionEvent)
    {
      switch(actionEvent.action)
      {
        case ActionEnum.MoveUpStart:
          movement = new Vector3(movement.x, movement.y, -movementSpeed);
        break;
        case ActionEnum.MoveUpEnd:
          movement = new Vector3(movement.x, movement.y, 0f);
        break;
        case ActionEnum.MoveDownStart:
          movement = new Vector3(movement.x, movement.y, movementSpeed);
        break;
        case ActionEnum.MoveDownEnd:
          movement = new Vector3(movement.x, movement.y, 0f);
        break;
        case ActionEnum.MoveRightStart:
          movement = new Vector3(movementSpeed, movement.y, movement.z);
        break;
        case ActionEnum.MoveRightEnd:
          movement = new Vector3(0f, movement.y, movement.z);
        break;
        case ActionEnum.MoveLeftStart:
          movement = new Vector3(-movementSpeed, movement.y, movement.z);
        break;
        case ActionEnum.MoveLeftEnd:
          movement = new Vector3(0f, movement.y, movement.z);
        break;
      }
    }

    protected void HandleAiming(ActionEvent actionEvent)
    {
      switch(actionEvent.action)
      {
        case ActionEnum.AimHorizontal:
          aimMagnitude.x = actionEvent.magnitude;
          break;
        case ActionEnum.AimVertical:
          aimMagnitude.y = actionEvent.magnitude;
          break;
      }
    }

    protected void HandlePause(ActionEvent actionEvent)
    {
      if(actionEvent.action == ActionEnum.TogglePlayerPause)
      {
        if(paused)
        {
          Resume();
        }
        else
        {
          Pause();
        }
      }

    }
  }
}
