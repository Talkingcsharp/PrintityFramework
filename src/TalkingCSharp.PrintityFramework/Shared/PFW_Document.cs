using System.Drawing;

namespace PrintityFramework.Shared;

public class PFW_Document
{
    public Size Size { get; set; } //Papersize to be set later
    public List<PFW_Table> Tables { get; set; } = new List<PFW_Table>();
    public List<PFW_PlaceLabel> Labels { get; set; } = new List<PFW_PlaceLabel>();
    public List<PFW_PlaceHeaderValue> PlaceHeaderValues { get; set; } = new List<PFW_PlaceHeaderValue>();

    public PFW_Document AddTable(PFW_Table table)
    {
        Tables.Add(table);
        return this;
    }

    public PFW_Document AddHeaderValue(PFW_PlaceHeaderValue headerValue)
    {
        this.PlaceHeaderValues.Add(headerValue);
        return this;
    }

    public PFW_Document AddLabel(PFW_PlaceLabel label)
    {
        this.Labels.Add(label);
        return this;
    }
}

