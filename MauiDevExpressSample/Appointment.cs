namespace MauiDevExpressSample;

public class Appointment
{
    public int Id { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string Subject { get; set; }
    public int LabelId { get; set; }
    public string Location { get; set; }
}
