package strategy;

public class DoubleBass extends Instrument
{

	public DoubleBass()
	{
		//instrumentBehavior = new StringFamily();
        playBehavior = new DrawBowAcrossString();
	}
	
	public void display()
	{
		System.out.println("I am a Double Bass.");
	}
}
