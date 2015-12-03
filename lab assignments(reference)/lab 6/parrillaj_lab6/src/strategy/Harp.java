package strategy;

public class Harp extends Instrument
{

	public Harp()
	{
		//instrumentBehavior = new PluckedStringFamily();
        playBehavior = new PluckingString();
	}
	
	public void display()
	{
		System.out.println("I am a Harp.");
	}

}
