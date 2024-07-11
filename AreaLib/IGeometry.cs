namespace AreaLib;

/// <summary>
/// Интерфейс для геометрических вычислений.
/// </summary>
public interface IGeometry
{
    /// <summary>
    /// Регистрирует новую фигуру с соответствующим методом вычисления площади.
    /// </summary>
    /// <param name="parameterCount">Количество параметров, необходимых для вычисления площади.</param>
    /// <param name="areaCalculator">Функция для вычисления площади фигуры.</param>
    void RegisterShape(int parameterCount, Func<double[], double> areaCalculator);

    /// <summary>
    /// Регистрирует новую фигуру с соответствующим методом вычисления площади и указанным типом.
    /// </summary>
    /// <param name="shapeType">Тип фигуры.</param>
    /// <param name="parameterCount">Количество параметров, необходимых для вычисления площади.</param>
    /// <param name="areaCalculator">Функция для вычисления площади фигуры.</param>
    void RegisterShape(ShapeType shapeType, int parameterCount, Func<double[], double> areaCalculator);

    /// <summary>
    /// Вычисляет площадь фигуры на основе предоставленных параметров без указания типа фигуры.
    /// </summary>
    /// <param name="parameters">Массив параметров, необходимых для вычисления площади.</param>
    /// <returns>Площадь фигуры.</returns>
    double CalculateArea(params double[] parameters);

    /// <summary>
    /// Вычисляет площадь заданной фигуры на основе её типа и параметров.
    /// </summary>
    /// <param name="shapeType">Тип фигуры.</param>
    /// <param name="parameters">Массив параметров, необходимых для вычисления площади.</param>
    /// <returns>Площадь фигуры.</returns>
    double CalculateArea(ShapeType shapeType, params double[] parameters);

    /// <summary>
    /// Проверяет, является ли треугольник с заданными сторонами прямоугольным.
    /// </summary>
    /// <param name="a">Длина первой стороны треугольника.</param>
    /// <param name="b">Длина второй стороны треугольника.</param>
    /// <param name="c">Длина третьей стороны треугольника.</param>
    /// <returns>True, если треугольник прямоугольный; в противном случае - false.</returns>
    bool IsRightTriangle(double a, double b, double c);
}