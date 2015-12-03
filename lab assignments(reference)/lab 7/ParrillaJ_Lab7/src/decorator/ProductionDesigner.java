package decorator;

public class ProductionDesigner extends ResponsibilityDecorator
{
Employee employee;
	
	ProductionDesigner(Employee e) 
	{
		this.employee = e;
		addJobTitle(employee.EmployeeDuties);
		
	}

	void addJobTitle(EmploymentDuties duties) 
	{
		 employee.EmployeeDuties.addJobTitle("Production Designer, ");
	}

}
