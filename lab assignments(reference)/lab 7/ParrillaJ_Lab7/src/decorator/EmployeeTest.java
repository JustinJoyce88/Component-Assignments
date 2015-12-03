package decorator;
//Jonathan Parrilla and Cesar Dominici - Lab 7
// EmployeeTest.java
// Revised 6/14/2013

import java.util.*;

public class EmployeeTest {
	
	public static void main(String[] args) {
		Employee e = new Employee();
		e.setId("100012");
		e.setLastName("Smith");
		ResponsibilityDecorator d;
		d = new Recruiter(e);
		d = new CommunityLiaison(e);
		d = new ProductionDesigner(e);	
		System.out.println(e.toString());
	}
}
