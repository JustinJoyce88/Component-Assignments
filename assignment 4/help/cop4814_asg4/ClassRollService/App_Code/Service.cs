using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


public class Service : IService
{
    private List<Student> students = new List<Student>();
    private StudentXmlReader xmlReader = new StudentXmlReader();
    private string xml = "http://cis.fiu.edu/~irvinek/cop4814/data/classroll.xml";


    public Service()
    {
        xmlReader.Read(students, xml);
    }


	public Student[] StudentList()
	{  
        return students.ToArray();
	}


	public double GetClassAverage()
	{
        double total = 0;
        int count = 0;

        foreach (Student S in students)
        {
            total += S.Average;
            count++;
        }

        return total / count;
	}
}
