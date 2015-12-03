package strategy;

public class Tuba extends Instrument
{

	public Tuba()
	{
		//instrumentBehavior = new BrassFamily();
        playBehavior = new BlowingAndBuzzing();
	}
	
	public void display()
	{
		System.out.println("I am a Tuba.");
	}

}
