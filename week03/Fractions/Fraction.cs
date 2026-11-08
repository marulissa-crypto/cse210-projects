using System;

public class Fraction
{
    // Private attributes (top and bottom numbers)
    private int _top;
    private int _bottom;

    // --- Constructors ---

    // Constructor 1: No parameters (defaults to 1/1)
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor 2: One parameter for top (defaults bottom to 1)
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor 3: Two parameters for top and bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // --- Getters and Setters ---

    public int GetTop()
    {
        return _top;
    }

    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        _bottom = bottom;
    }

    // --- Representation Methods ---

    // Returns fraction as a string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Returns fractional value as a double (e.g., 0.75)
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}