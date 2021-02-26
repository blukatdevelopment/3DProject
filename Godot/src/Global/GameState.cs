namespace Global {

  /*
    Yup, it's a model that holds shared data used by the Game class.
    Only this object should need to be persisted for a particular
    session to be persisted.
    If a particular game needs a ton more granular data, an object
    containing that data can be added inside here to contain it.
  */
  public class GameState
  {

    public GameState()
    {
    }
  }
}