using Bits.Contract;
using System.Linq;

namespace Bits
{
    public class Figure : IFigure
    {
        /// <summary>
        ///  Число возможных ходов из текущего положения фигуры
        /// </summary>
        /// <value></value>
        public int MoveCounter { get => this.moveCounter; }
        protected int moveCounter;

        /// <summary>
        /// Массив доски
        /// </summary>
        protected ulong[,] board;

        /// <summary>
        /// Координаты фигуры на доске
        /// </summary>
        protected byte figX, figY;

        /// <summary>
        /// Возможные направления движения
        /// </summary>
        protected byte[] directions;

        /// <summary>
        /// Делегат функции получения суммы всех полей одного направления
        /// </summary>
        /// <returns></returns>
        protected delegate ulong DirectionProcess();

        /// <summary>
        /// Вычисление суммы всех полей по одному направлению
        /// </summary>
        protected DirectionProcess[] directionProcesses;
        
        public Figure(ulong[,] board, byte n)
        {
            this.board = board;
            this.figX = (byte)(n % 8);
            this.figY = (byte)(n / 8);
        }

        /// <summary>
        /// Получение суммы всех полей движения фигуры из текущего положения на доске
        /// </summary>
        /// <returns>Сумма всех полей движения</returns>
        public ulong CalcHash()
        {
            ulong result = 0;
            for (byte i = 0; i < directionProcesses.Length; i++)
            {
                if (directions.Any(d => d == i))
                {
                    result += directionProcesses[i]();
                }
            }
            return result;
        }
    }
}