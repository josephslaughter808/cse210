class CyclingActivity : Activity
{
    private double _speed;

    public CyclingActivity(string date, int lengthInMinutes, double speed)
        : base(date, lengthInMinutes)
    {
        _speed = speed;
    }

    public override double GetDistance()
    {
        return (_speed * GetLengthInMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    public override double GetPace()
    {
        return 60 / _speed;
    }

    public override string GetActivityName()
    {
        return "Cycling";
    }
}
