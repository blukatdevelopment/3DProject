namespace Global
{
  using Godot;
  using System;
  using System.Collections.Generic;
  using Actor;

  public class Session : Spatial
  {
    public static Session session;
    public Dictionary<GameTypeEnum, Game> games;
    public GameState state;
    public GameTypeEnum activeGame;

    public override void _Ready()
    {
      games = new Dictionary<GameTypeEnum, Game>();
      state = new GameState();
      StartNewGame(GameTypeEnum.Battle);
    }

    public void StartNewGame(GameTypeEnum gameType)
    {
      if(games.ContainsKey(gameType))
      {
        games[gameType].End();
        games[gameType].QueueFree();
        games.Remove(gameType);
      }

      games[gameType] = GameConstants.NewGameByType(gameType, state);
      AddChild(games[gameType]);
      games[gameType].Start();
      activeGame = gameType;
    }
  }
}
