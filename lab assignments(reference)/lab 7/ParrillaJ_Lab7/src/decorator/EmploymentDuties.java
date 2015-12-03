package decorator;

public class EmploymentDuties 
{
	String JobTitles = "";
	
	EmploymentDuties()
	{
		
	}
	
	void addJobTitle(String jobTitle)
	{
		JobTitles = JobTitles + jobTitle;
	}
	
	String printDuties()
	{
		return JobTitles;
	}
}
