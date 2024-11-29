abstract class GeographicalObject
{
    private double _x;
    private double _y;
    private string _name;
    private string _description;

    public virtual void ShowInfo()
    {

    }
}

class River : GeographicalObject
{
    private double _flowRate;
    private double _length;
}

class Mountain : GeographicalObject
{
    private string _highestPoint;
}