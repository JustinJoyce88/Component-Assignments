using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

public class ClassListService : IClassListService
{
  List<Student> students = new List<Student>();

  public ClassListService()
  {
    students.Add( new Student("1123122", "Jose") );
    students.Add( new Student("1123100", "Maria"));
    students.Add( new Student("1123133", "Juan"));

  }

	public List<Student> GetData()
	{
    return students;
	}

}
