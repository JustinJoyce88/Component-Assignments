using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

[ServiceContract]
public interface IClassListService
{

  [OperationContract]
  List<Student> GetData();

}

[DataContract]
public class Student
{
  public Student(string id, string name)
  {
    ID = id;
    Name = name;
  }
  [DataMember]
  public string FullInfo
  {
    get {
      return ID + ", " + Name;
    }
    set
    {

    }
  }

  [DataMember]
  public string ID { get; set; }

  [DataMember]
  public string Name { get; set; }
}
