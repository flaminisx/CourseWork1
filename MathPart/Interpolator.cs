using System.Collections.Generic;
using System.Drawing;


namespace MathPart
{
    public interface Interpolator 
    {
        void init(List<PointF> data); // Ініціалізація методу
        double getPoint(double x); // Пошук Y по даному X
        string getType(); // Назва методу інтерполяції
        string getLastPolynomString(); // Отримання поліному
        int getLastOperationCount(); // Кількість операцій
        int getLastIterationCount(); //Кількість ітерацій
    }
}
