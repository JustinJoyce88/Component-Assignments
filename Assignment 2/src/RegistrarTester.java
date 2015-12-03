//Group Members: Alberto Fortuny, Justin Joyce

import static org.junit.Assert.assertEquals;

import org.junit.Test;


public class RegistrarTester {

	@Test
	public void testCanRegister_1() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.PROBATION, YearLevel.LOWERDIVISION, 3.0, 5);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_2() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.PROBATION, YearLevel.LOWERDIVISION, 1.0, 7);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_3() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.PROBATION, YearLevel.UPPERDIVISION, 3.0, 2);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_4() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.PROBATION, YearLevel.UPPERDIVISION, 1.0, 4);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_5() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.LOWERDIVISION, 3.0, 11);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_6() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.LOWERDIVISION, 3.0, 13);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_7() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.LOWERDIVISION, 2.2, 5);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_8() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.LOWERDIVISION, 2.1, 7);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_9() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.UPPERDIVISION, 2.5, 9);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_10() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.UPPERDIVISION, 2.5, 11);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_11() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.UPPERDIVISION, 2.4, 7);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_12() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.UPPERDIVISION, 2.4, 9);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_13() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.NORMAL, YearLevel.LOWERDIVISION, 2.6, 15);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_14() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.NORMAL, YearLevel.LOWERDIVISION, 2.6, 17);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_15() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.NORMAL, YearLevel.LOWERDIVISION, 2.5, 11);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_16() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.NORMAL, YearLevel.LOWERDIVISION, 2.5, 13);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_17() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.NORMAL, YearLevel.UPPERDIVISION, 2.5, 17);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_18() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.NORMAL, YearLevel.UPPERDIVISION, 2.5, 19);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_19() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.HONORS, YearLevel.UPPERDIVISION, 3.0, 21);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_20() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.HONORS, YearLevel.UPPERDIVISION, 3.0, 23);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_21() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.HONORS, YearLevel.UPPERDIVISION, 2.9, 15);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_22() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.HONORS, YearLevel.UPPERDIVISION, 2.9, 17);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_23() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.NORMAL, YearLevel.GRADUATE, 2.9, 5);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_24() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.NORMAL, YearLevel.GRADUATE, 2.9, 7);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_25() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.NORMAL, YearLevel.GRADUATE, 3.0, 11);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_26() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.NORMAL, YearLevel.GRADUATE, 3.0, 13);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	//----------------------------------------EXTRA TESTS----------------------------------------
	
	@Test
	public void testCanRegister_27() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.PROBATION, YearLevel.GRADUATE, 2.9, 5);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_28() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.PROBATION, YearLevel.GRADUATE, 2.9, 7);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_29() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.PROBATION, YearLevel.GRADUATE, 3.0, 11);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_30() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.PROBATION, YearLevel.GRADUATE, 3.0, 13);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_31() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.GRADUATE, 2.9, 5);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_32() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.GRADUATE, 2.9, 7);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_33() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.GRADUATE, 3.0, 11);
		boolean expected = true;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_34() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.GRADUATE, 3.0, 13);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_35() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.WARNING, YearLevel.GRADUATE, 3.0, 99);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
	@Test
	public void testCanRegister_36() {
		
		Registrar r = new Registrar();
		boolean actual = r.canRegister(AcademicStatus.NULL, YearLevel.GRADUATE, 3.0, 99);
		boolean expected = false;
		assertEquals(expected, actual);
	}
	
}
