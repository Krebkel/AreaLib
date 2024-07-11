namespace AreaLib;

/// <summary>
/// Класс, реализующий геометрические вычисления.
/// </summary>
public class Geometry : IGeometry
{
    private readonly Dictionary<int, Func<double[], double>> _areaCalculators = new();
    private readonly Dictionary<(ShapeType, int), Func<double[], double>> _typedAreaCalculators = new();

    /// <summary>
    /// Инициализирует новый экземпляр класса Geometry.
    /// </summary>
    public Geometry()
    {
        RegisterShape(1, p => Math.PI * p[0] * p[0]); // Circle
        RegisterShape(3, p => // Triangle
        {
            double s = (p[0] + p[1] + p[2]) / 2;
            return Math.Sqrt(s * (s - p[0]) * (s - p[1]) * (s - p[2]));
        });
        RegisterShape(2,p => p[0] * p[1]); // Rectangle

        RegisterShape(ShapeType.Circle, 1, p => Math.PI * p[0] * p[0]);
        RegisterShape(ShapeType.Triangle, 3, p =>
        {
            double s = (p[0] + p[1] + p[2]) / 2;
            return Math.Sqrt(s * (s - p[0]) * (s - p[1]) * (s - p[2]));
        });
        RegisterShape(ShapeType.Rectangle, 2, p => p[0] * p[1]);
    }

    /// <inheritdoc/>
    public void RegisterShape(int parameterCount, Func<double[], double> areaCalculator)
    {
        _areaCalculators[parameterCount] = areaCalculator;
    }

    /// <inheritdoc/>
    public void RegisterShape(ShapeType shapeType, int parameterCount, Func<double[], double> areaCalculator)
    {
        _typedAreaCalculators[(shapeType, parameterCount)] = areaCalculator;
    }

    /// <inheritdoc/>
    public double CalculateArea(params double[] parameters)
    {
        if (!_areaCalculators.TryGetValue(parameters.Length, out var calculator))
            throw new ArgumentException($"No shape found with {parameters.Length} parameters");

        return calculator(parameters);
    }

    /// <inheritdoc/>
    public double CalculateArea(ShapeType shapeType, params double[] parameters)
    {
        if (!_typedAreaCalculators.TryGetValue((shapeType, parameters.Length), out var calculator))
            throw new ArgumentException($"No shape found for {shapeType} with {parameters.Length} parameters");

        return calculator(parameters);
    }

    /// <inheritdoc/>
    public bool IsRightTriangle(double a, double b, double c)
    {
        var sides = new[] { a, b, c };
        Array.Sort(sides);
        return Math.Abs(Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) - Math.Pow(sides[2], 2)) < 1e-6;
    }
}