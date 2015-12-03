package decorator;

public class Recruiter extends ResponsibilityDecorator
{
	Employee employee;
	
	Recruiter(Employee e) 
	{
		this.employee = e;
		addJobTitle(employee.EmployeeDuties);
		
	}

	void addJobTitle(EmploymentDuties duties) 
	{
		 employee.EmployeeDuties.addJobTitle("Recruiter, ");
	}
	


}
