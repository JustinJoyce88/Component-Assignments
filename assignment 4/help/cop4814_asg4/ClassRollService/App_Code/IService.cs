using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;


[ServiceContract]
public interface IService
{
	[OperationContract]
	Student[] StudentList();

	[OperationContract]
	double GetClassAverage();
}


[DataContract]
public class Student
{
    [DataMember]
    public string ID { get; set; }

    [DataMember]
    public string FirstName { get; set; }

    [DataMember]
    public string LastName { get; set; }

    [DataMember]
    public List<double> Scores = new List<double>();

    [DataMember]
    public double Average 
    {
        get
        {
            return Scores.Sum() / Scores.Count;
        }
        set { }
    }

    // Constructor
    public Student(string id, string firstName, string lastName)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
    }
}
