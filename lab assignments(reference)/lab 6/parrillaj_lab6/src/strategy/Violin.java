package strategy;

public class Violin extends Instrument
{
	public Violin()
	{
		//instrumentBehavior = new StringFamily();
        playBehavior = new DrawBowAcrossString();
	}
	
	public void display()
	{
		System.out.println("I am a Violin.");
	}

}
