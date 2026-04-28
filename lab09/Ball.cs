using System.Windows.Shapes; 
using System.Windows.Controls; 
using System.Windows.Media; 
namespace lab09;

public class Ball
{
    public double x { get; set; }
    public double y { get; set; }
    public double dx { get; set; }
    public double dy { get; set; }

    public double Radius { get; private set; }
    public Rectangle Ref { get; private set; }

    public static int hitCounter { get; set; }

    public static Ball CreateBall(double x, double y, double radius, double dx, double dy)
    {
        var shape = new Rectangle()
        {
            Width = 2 * radius,
            Height = 2 * radius,
            RadiusX = radius,
            RadiusY = radius,
            Fill = Brushes.Red
        };

        return new Ball()
        {
            x = x,
            y = y,
            dx = dx,
            dy = dy,
            Radius = radius,
            Ref = shape
        };
    }

    public void Move()
    {
        x += dx;
        y += dy;

        Canvas.SetLeft(Ref, x);
        Canvas.SetTop(Ref, y);
    }

    public void Bounce(double width, double height)
    {
        if (x - Radius <= 0 || x + Radius >= width)
        {
            dx = -dx;
            hitCounter++;
        }

        if (y - Radius <= 0 || y + Radius >= height)
        {
            dy = -dy;
            hitCounter++;
        }
    }
}