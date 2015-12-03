//Group Members: Alberto Fortuny, Justin Joyce

public class Registrar 
{
	boolean canRegister (AcademicStatus aStatus, YearLevel yLevel, double gpa, int credits)
	{
		if (aStatus.equals(AcademicStatus.PROBATION))
		{
			if(yLevel.equals(YearLevel.LOWERDIVISION) && credits<=6)
				return true;
			else if (yLevel.equals(YearLevel.UPPERDIVISION) && credits<=3)
				return true;
			else if (yLevel.equals(YearLevel.GRADUATE) && gpa<3.0 && credits<=6)
				return true;
			else if (yLevel.equals(YearLevel.GRADUATE) && gpa>=3.0 && credits<=12)
				return true;
			else
				return false;
		}
		else if(aStatus.equals(AcademicStatus.WARNING))
		{
			if(yLevel.equals(YearLevel.LOWERDIVISION) && gpa>2.2 && credits<=12)
				return true;
			else if (yLevel.equals(YearLevel.LOWERDIVISION) && gpa<=2.2 && credits<=6)
				return true;
			else if (yLevel.equals(YearLevel.UPPERDIVISION) && gpa>2.4 && credits<=10)
				return true;
			else if (yLevel.equals(YearLevel.UPPERDIVISION) && gpa<=2.4 && credits<=8)
				return true;
			else if (yLevel.equals(YearLevel.GRADUATE) && gpa<3.0 && credits<=6)
				return true;
			else if (yLevel.equals(YearLevel.GRADUATE) && gpa>=3.0 && credits<=12)
				return true;
			else
				return false;
		}
		else if(aStatus.equals(AcademicStatus.NORMAL))
		{
			if(yLevel.equals(YearLevel.LOWERDIVISION) && gpa>2.5 && credits<=16)
				return true;
			else if (yLevel.equals(YearLevel.LOWERDIVISION) && gpa<=2.5 && credits<=12)
				return true;
			else if (yLevel.equals(YearLevel.UPPERDIVISION) && credits<=18)
				return true;
			else if (yLevel.equals(YearLevel.GRADUATE) && gpa<3.0 && credits<=6)
				return true;
			else if (yLevel.equals(YearLevel.GRADUATE) && gpa>=3.0 && credits<=12)
				return true;
			else
				return false;
		}
		else if(aStatus.equals(AcademicStatus.HONORS))
		{
			if(gpa>=3.0 && credits<=22)
				return true;
			else if (gpa<3.0 && credits<=16)
				return true;
			else
				return false;
		}
		else
			return false;
	}

}
