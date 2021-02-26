namespace Input
{
  using Godot;
  using System.Collections.Generic;
  using Global;

  public class InputState : Node2D
  {
    private List<IActionSubscriber> subscribers;
    private List<KeyMapping> keyMappings;
    private List<AxisMapping> axisMappings;
    private bool paused;
    private Vector2 mousePosition;
    private Vector2 mouseMovement;

    public InputState()
    {
      this.keyMappings = new List<KeyMapping>();
      mousePosition = new Vector2();
      mouseMovement = new Vector2();
    }

    public InputState(List<KeyMapping> keyMappings, List<AxisMapping> axisMappings)
    {
      this.paused = false;
      this.keyMappings = keyMappings;
      this.axisMappings = axisMappings;
      subscribers = new List<IActionSubscriber>();
      mousePosition = new Vector2();
      mouseMovement = new Vector2();
    }

    public override void _Input(Godot.InputEvent evt)
    {
      InputEventMouseMotion motion = evt as InputEventMouseMotion;
      if(motion != null)
      {
        mousePosition = motion.GlobalPosition;
        mouseMovement = motion.Relative;
      }
    }

    public override void _Process(float delta)
    {
      if(paused)
      {
        return;
      }

      List<ActionEvent> actionEvents = new List<ActionEvent>();
      foreach(KeyMapping keyMapping in keyMappings)
      {
        actionEvents.AddRange(keyMapping.GetEvents(delta));
      }

      foreach(AxisMapping axisMapping in axisMappings)
      {
        actionEvents.AddRange(GetAxisEvents(axisMapping));
      }
      mouseMovement = new Vector2();

      foreach(IActionSubscriber subscriber in subscribers)
      {
        subscriber.QueueActions(actionEvents);
      }
    }

    public List<ActionEvent> GetAxisEvents(AxisMapping mapping)
    {
      List<ActionEvent> events = new List<ActionEvent>();
      switch(mapping.axis)
      {
        case AxisEnum.MouseY:
          if(Utility.Abs(mouseMovement.y) > mapping.minimumInput)
          {
            events.Add(new ActionEvent(mapping.action, mapping.sensitivity * mouseMovement.y));
          }
          break;
        case AxisEnum.MouseX:
          if(Utility.Abs(mouseMovement.x) > mapping.minimumInput)
          {
            events.Add(new ActionEvent(mapping.action, mapping.sensitivity * mouseMovement.x));
          }
          break;
      }

      return events;
    }

    public void Pause()
    {
      paused = true;
      Godot.Input.SetMouseMode(Godot.Input.MouseMode.Visible);
    }

    public void Resume()
    {
      paused = false;
    }

    public void Subscribe(IActionSubscriber subscriber)
    {
      subscribers.Add(subscriber);
    }

    public void Unsubscribe(IActionSubscriber subscriber)
    {
      subscribers.Remove(subscriber);
    }
  }
}
