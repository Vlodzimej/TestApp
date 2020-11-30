using System.Linq;

namespace Bits
{
    /// <summary>
    /// Фигура "Король"
    /// </summary>
    public class King : Figure
    {
        public King(ulong[,] board, byte n) : base(board, n)
        {
            /** Определение функций для вычисления суммы полей для каждого направления */
            directionProcesses = new DirectionProcess[8]{
                () => {
                    moveCounter++;
                    return board[figX, figY + 1];
                },
                () => {
                    moveCounter++;
                    return board[figX + 1, figY + 1];
                },
                () => {
                    moveCounter++;
                    return board[figX + 1, figY];
                },
                () => {
                    moveCounter++;
                    return board[figX + 1, figY - 1];
                },
                () => {
                    moveCounter++;
                    return board[figX, figY - 1];
                },
                () => {
                    moveCounter++;
                    return board[figX - 1, figY - 1];
                },
                () => {
                    moveCounter++;
                    return board[figX - 1, figY];
                },
                () => {
                    moveCounter++;
                    return board[figX - 1, figY + 1];
                },
            };

            directions = GetDirections();
        }

        /// <summary>
        /// Получение возможных направлений движеня для текущих координат Короля
        /// </summary>
        /// <returns>Массив направлений</returns>
        private byte[] GetDirections()
        {
            byte[] directs = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7 };

            if (figY == 0) directs = directs.Except(new byte[] { 3, 4, 5 }).ToArray();
            if (figY == 7) directs = directs.Except(new byte[] { 0, 1, 7 }).ToArray();
            if (figX == 0) directs = directs.Except(new byte[] { 5, 6, 7 }).ToArray();
            if (figX == 7) directs = directs.Except(new byte[] { 1, 2, 3 }).ToArray();

            return directs;
        }
    }
}