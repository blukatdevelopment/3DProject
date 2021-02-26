namespace Actor
{
  using Godot;
  using System.Collections.Generic;
  using Input;

  // Base class for body that can be expanded by specific body types
  public class Body : KinematicBody, IActionSubscriber
  {
    protected bool paused;
    protected Actor actor;
    protected Camera camera;
    protected KinematicBody head;
    protected float delay;
    protected List<ActionEvent> actionEventsQueue;

    public Body()
    {
      actionEventsQueue = new List<ActionEvent>();
    }

    public void QueueActions(List<ActionEvent> actionEvents)
    {
      actionEventsQueue.AddRange(actionEvents);
    }

    public virtual void AssignActor(Actor actor, bool addCamera, string headNodePath)
    {
      this.actor = actor;
      head = FindNode(headNodePath) as KinematicBody;
      if(addCamera)
      {
        camera = new Camera();
        head.AddChild(camera);
      }
    }

    public virtual void Move(Vector3 direction)
    {
      GD.Print("Moving");
    }

    public virtual void HandleAction(ActionEvent actionEvent)
    {
      GD.Print("Handling " + actionEvent.action);
    }

    public virtual void Pause()
    {
      paused = true;
    }

    public virtual void Resume()
    {
      paused = false;
    }

    public virtual void PostEventsUpdate()
    {
    }

    public override void _Process(float delta)
    {
      delay += delta;
      if(delay >= ActorConstants.ActionHandlingDelay)
      {
        delay = 0f;
        foreach(ActionEvent actionEvent in actionEventsQueue)
        {
          HandleAction(actionEvent);
        }
        actionEventsQueue = new List<ActionEvent>();
        PostEventsUpdate();
      }
    }

  }
}
