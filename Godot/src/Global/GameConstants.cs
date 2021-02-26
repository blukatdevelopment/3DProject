namespace Global
{
  using Global;
  using Godot;
  using Input;
  using Battle;

  public class GameConstants
  {
    public static GameState DefaultGameState()
    {
      GameState state = new GameState();
      return state;
    }

    public static Game NewGameByType(GameTypeEnum gameType, GameState state)
    {
      switch(gameType)
      {
        case GameTypeEnum.Battle:
          return new BattleGame(state);
        default:
          GD.Print("NewGameByType: invalid gameType: " + gameType);
          return null;
      }
    }

    public static Vector2 GameResolution()
    {
      return new Vector2(1920f, 1080f);
    }
  }
}