namespace Bits.Contract
{
    public interface IFigure
    {
        /// <summary>
        /// Количетсво ходов из текущего положения фигуры
        /// </summary>
        /// <value></value>
        int MoveCounter { get; }
        
        /// <summary>
        /// Получение суммы всех полей движения фигуры из текущего положения на доске
        /// </summary>
        /// <returns>Сумма всех полей движения</returns>
        ulong CalcHash();
    }
}