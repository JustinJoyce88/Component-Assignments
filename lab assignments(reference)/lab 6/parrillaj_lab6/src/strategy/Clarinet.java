package strategy;

public class Clarinet extends Instrument
{

	public Clarinet()
	{
		//instrumentBehavior = new WoodwindFamily();
        playBehavior = new BuzzingReed();
	}
	
	public void display()
	{
		System.out.println("I am a Clarinet.");
	}

}
