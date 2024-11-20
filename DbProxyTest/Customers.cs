namespace MyNameSpace;
public class Customers
{
  public Int32 ID { get; set; }
  public Int32 CustomerID { get; set; }
  public String FirstName { get; set; } = string.Empty;
  public String LastName { get; set; } = string.Empty;
  public String PopularName { get; set; } = string.Empty;
  public String Street { get; set; } = string.Empty;
  public String StreetNumber { get; set; } = string.Empty;
  public String AptNr { get; set; } = string.Empty;
  public String City { get; set; } = string.Empty;
  public String Zip { get; set; } = string.Empty;
  public String PersonalNumber { get; set; } = string.Empty;
  public String email { get; set; } = string.Empty;
  public String phone { get; set; } = string.Empty;
  public Decimal PriceLow { get; set; }
  public Decimal PriceHigh { get; set; }
  public Int32 CreditDays { get; set; }
  public Int32 EmployeeID { get; set; }
  public Boolean RUT { get; set; }
  public Int32 DayOfWeek { get; set; }
  public Int32 Plan { get; set; }
  public Int32 ProduktId { get; set; }
  public String InvoiceFolder { get; set; } = string.Empty;
}
