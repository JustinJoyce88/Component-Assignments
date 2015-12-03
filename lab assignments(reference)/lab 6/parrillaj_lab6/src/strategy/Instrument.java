package strategy;

public abstract class Instrument 
{
	//InstrumentBehavior instrumentBehavior;
	PlayBehavior playBehavior;
 
	public Instrument() { }
 
	/*public void setInstrumentBehavior (InstrumentBehavior ib) 
	{
		instrumentBehavior = ib;
	}*/
 
	public void setPlayBehavior(PlayBehavior pb) 
	{
		playBehavior = pb;
	}
 
	abstract void display();
 
	/*public void performInstrument() 
	{
		instrumentBehavior.instrument();
	}*/
 
	public void performPlay() 
	{
		playBehavior.play();
	}
 
}
