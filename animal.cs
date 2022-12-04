class Animal  // base class
{


  // Using properties here to ensure encapsulation
  private bool sleep = false;

  public bool Sleep {
    get { return sleep; }
    set { sleep = value; }
  }

  private bool hungry = false;

  public bool Hungry {
    get { return hungry; }
    set { hungry = value; }
  }

  private int energy;

  public int Energy {
    get { return energy; }
    set { energy = value; }
  }

  private int hunger;

  public int Hunger {
    get { return hunger; }
    set { hunger = value; }
  }

  private int hungerlimit;

  public int Hungerlimit {
    get { return hungerlimit; }
    set { hungerlimit = value; }
  }

  public virtual string snore() // Virtual methods so they can be overriden by the lion and tiger           
    {
      return "Zzz";
    }

    public virtual string growl()             
    {
      return "Grrrrrrr";
    }
}




  class Lion : Animal  // Derived class 
  {

    public override string snore() // Polymorphism for the inherited method            
    {
      return "ZZZZzzzzzzzgggrrrrrr";
    }

    public override string growl()             
    {
      return "RRROAAAAARR!!";
    }

  }

  class Tiger : Animal  // Derived class
  {

    public override string snore()             
    {
      return "Yaaawwwwnnnnnnmmmmmzzzzzz";
    }

    public override string growl()             
    {
      return "MMMmmmmmRRRRRRRRR";
    }
  }