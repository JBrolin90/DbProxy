namespace MyNameSpace;
public class Schedules
{
  public Int32 ID { get; set; }
  public Int32 CustomerID { get; set; }
  public DateTime DateActual { get; set; }
  public DateTime StartTime { get; set; }
  public DateTime EndTime { get; set; }
  public Double DurationPlanned { get; set; }
  public Double DurationActual { get; set; }
  public Int32 EmployeeIDPlanned { get; set; }
  public Int32 EmployeeIDActual { get; set; }
  public DateTime StartTimePlanned { get; set; }
  public Int32 Job { get; set; }
  public Boolean RUT { get; set; }
  public Boolean ROT { get; set; }
  public Int32 PayDay { get; set; }
  public Int32 PayMonth { get; set; }
  public Int32 PayYear { get; set; }
  public Decimal PricePerHour { get; set; }
  public Int32 OBIndex { get; set; }
  public Decimal PayPerHour { get; set; }
}
