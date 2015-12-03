package decorator;

public class CommunityLiaison extends ResponsibilityDecorator
{
	
Employee employee;
	
	CommunityLiaison(Employee e) 
	{
		this.employee = e;
		addJobTitle(employee.EmployeeDuties);
		
	}

	void addJobTitle(EmploymentDuties duties) 
	{
		 employee.EmployeeDuties.addJobTitle("Community Liaison, ");
	}

}
