using AreaLib;

namespace AreaLibTest;

[TestClass]
public class GeometryTests
{
    private const double Epsilon = 1e-6;
    private IGeometry _geometry;

    [TestInitialize]
    public void Initialize()
    {
        _geometry = new Geometry();
    }

    [TestMethod]
    public void CalculateArea_Circle_ReturnsCorrectArea()
    {
        double radius = 5;
        double expectedArea = Math.PI * radius * radius;
            
        Assert.AreEqual(expectedArea, _geometry.CalculateArea(radius), Epsilon);
        Assert.AreEqual(expectedArea, _geometry.CalculateArea(ShapeType.Circle, radius), Epsilon);
    }

    [TestMethod]
    public void CalculateArea_Triangle_ReturnsCorrectArea()
    {
        double a = 3, b = 4, c = 5;
        double expectedArea = 6;
            
        Assert.AreEqual(expectedArea, _geometry.CalculateArea(a, b, c), Epsilon);
        Assert.AreEqual(expectedArea, _geometry.CalculateArea(ShapeType.Triangle, a, b, c), Epsilon);
    }
    
    [TestMethod]
    public void CalculateArea_Rectangle_ReturnsCorrectArea()
    {
        double a = 3, b = 5;
        double expectedArea = 15;
            
        Assert.AreEqual(expectedArea, _geometry.CalculateArea(a, b), Epsilon);
        Assert.AreEqual(expectedArea, _geometry.CalculateArea(ShapeType.Rectangle, a, b), Epsilon);
    }

    [TestMethod]
    public void IsRightTriangle_RightTriangle_ReturnsTrue()
    {
        Assert.IsTrue(_geometry.IsRightTriangle(3, 4, 5));
    }

    [TestMethod]
    public void IsRightTriangle_NotRightTriangle_ReturnsFalse()
    {
        Assert.IsFalse(_geometry.IsRightTriangle(2, 3, 4));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void CalculateArea_InvalidParameterCount_ThrowsArgumentException()
    {
        _geometry.CalculateArea(1, 2, 3, 4);
    }

    [TestMethod]
    public void RegisterShape_NewShape_CalculatesCorrectly()
    {
        _geometry.RegisterShape(2, p => p[0] * p[1]); // Rectangle
        Assert.AreEqual(20, _geometry.CalculateArea(4, 5), Epsilon);
    }
}