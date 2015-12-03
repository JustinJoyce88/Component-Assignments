package decorator;

public class Employee
{
	String ID;
	String LastName;
	EmploymentDuties EmployeeDuties = new EmploymentDuties();
	
	Employee()
	{
			
	}
	
	void setId(String id)
	{
		this.ID = id;
	}
	
	void setLastName(String lastName)
	{
		this.LastName = lastName;
	}
	
	
	public String toString()
	{
		return "Duties for this employee: [" +EmployeeDuties.printDuties() +"]";
	}
	
}
