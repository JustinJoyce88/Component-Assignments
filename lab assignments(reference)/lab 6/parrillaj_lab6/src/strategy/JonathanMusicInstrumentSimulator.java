//Jonathan Parrilla - Lab 6

package strategy;
import java.util.ArrayList;

public class JonathanMusicInstrumentSimulator {

	public static void main(String[] args) 
	{
	
		ArrayList<Instrument> ensemble = new ArrayList<Instrument>();
		
		ensemble.add( new Violin() );
		ensemble.add( new Tuba() );
		ensemble.add( new Clarinet() );
		ensemble.add( new Harp() );
		ensemble.add( new DoubleBass() );

		for( Instrument I : ensemble)
		{
			I.display();
			//I.performInstrument();
			I.performPlay();
			System.out.println();
		}				
	}	

}
