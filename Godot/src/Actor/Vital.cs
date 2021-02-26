namespace Actor
{

  public class Vital
  {
    public VitalEnum vitalType;
    public int Current
    {
      get { return current  + Temporary; }
      set
      {
        if(value < 0)
        {
          current = 0;
        }
        else if(value > Max)
        {
          current = Max;
        }
        else
        {
          current = value;
        }
      } 
    }
    public int Max { get; set; }
    public int Temporary { get; set; }
    private int current;

    public Vital()
    {
      Max = current = Temporary = 0;
      vitalType = VitalEnum.None;
    }

    public Vital(VitalEnum vitalType, int max)
    {
      this.vitalType = vitalType;
      Max = max;
      current = Max;
      Temporary = 0;
    }

    public Vital(VitalEnum vitalType, int max, int current, int temporary)
    {
      this.vitalType = vitalType;
      Max = max;
      this.current = current;
      Temporary = temporary;
    }
  }
}