using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class StudentXmlReader
{
	public bool Read(List<Student> students, string path)
	{
			System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(path);
			reader.Read();
			while (reader.Read())
			{
				if (reader.NodeType == System.Xml.XmlNodeType.Element)
				{
					if (reader.Name == "student")
					{
						Student S = readStudent(reader);
						students.Add(S);
					}
				}
			}
			return true;
	}

	string nextValue(System.Xml.XmlTextReader reader)
	{
		while (reader.Read())
		{
			if (reader.NodeType == System.Xml.XmlNodeType.Text)
				return reader.Value;
		}
		return null;
	}

	string nextNode(System.Xml.XmlTextReader reader)
	{
		while (reader.Read())
		{
			if (reader.NodeType == System.Xml.XmlNodeType.Element)
				return reader.Name;
		}
		return null;
	}


	Student readStudent(System.Xml.XmlTextReader reader)
	{
		string id = nextValue(reader);
		string lastName = nextValue(reader);
		string firstName = nextValue(reader);
		Student S = new Student(id, firstName, lastName);

		// read the test scores
		if (nextNode(reader) == "testscores")
		{
			reader.MoveToNextAttribute();
			if (reader.Name == "count")
			{
				int count = Convert.ToInt32(reader.Value);
				for (int i = 0; i < count; i++)
				{
					S.Scores.Add(Convert.ToInt32(nextValue(reader)));
				}
			}
		}
		return S;
	}

}