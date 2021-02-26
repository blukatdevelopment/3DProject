namespace Actor
{
  // Base class for stats that contains health.
  public class Stats
  {
    public Vital health;

    public Stats()
    {
      health = new Vital(VitalEnum.Health, 0);
    }
  }
}