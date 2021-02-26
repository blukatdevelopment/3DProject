namespace Battle
{
  using Global;
  using Godot;
  using Actor;
  using Input;
  using System.Collections.Generic;
  using System;

  /*
    FPS fight
  */
  public class BattleGame : Game
  {

    public BattleGame()
    {

    }

    public BattleGame(GameState state) : base()
    {
      this.gameState = state;
      players = new List<Actor>();
      this.inputState = new InputState(BattleConstants.BattleKeyMappings(), BattleConstants.BattleAxisMappings());
      AddChild(this.inputState);
    }

    public override void Start()
    {
      GD.Print("Battle game started");
      AddPlayer(BattleConstants.Infantry(true, new Vector3(0f, 5f, 0f)));
    }

    public override void Pause()
    {
      inputState.Pause();
    }

    public override void Resume()
    {
      inputState.Resume();
    }


    public override void _Process(float delta)
    {
    }

    private void GameOver()
    {
      GD.Print("Game Over");
    }

    public override void End()
    {
      GD.Print("Game Ended");
    }
  }
}
