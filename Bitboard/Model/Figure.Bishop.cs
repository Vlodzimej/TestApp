using System.Linq;

namespace Bits
{
    /// <summary>
    /// Фигура "Слон"
    /// </summary>
    public class Bishop : Figure
    {
        public Bishop(ulong[,] board, byte n) : base(board, n)
        {
            /** Определение функций для вычисления суммы полей для каждого направления */
            directionProcesses = new DirectionProcess[8]{
                null,
                () => {
                    ulong result = 0;
                    for(int i = 1; figX + i < 8 && figY + i < 8; i++) {
                        result += board[figX+i, figY+i];
                        moveCounter++;
                    }
                    return result;
                },
                null,
                () => {
                    ulong result = 0;
                    for(int i = 1; figX + i < 8 && figY - i >= 0; i++) {
                        result += board[figX+i, figY-i];
                        moveCounter++;
                    }
                    return result;
                },
                null,
                () => {
                    ulong result = 0;
                    for(int i = 1; figX - i >= 0 && figY - i >= 0; i++) {
                        result += board[figX-i, figY-i];
                        moveCounter++;
                    }
                    return result;
                },
                null,
                () => {
                    ulong result = 0;
                    for(int i = 1; figX - i >= 0 && figY + i < 8; i++) {
                        result += board[figX-i, figY+i];
                        moveCounter++;
                    }
                    return result;
                },
            };

            directions = GetDirections();
        }

        /// <summary>
        /// Получение возможных направлений движеня для текущих координат Слона 
        /// </summary>
        /// <returns>Массив направлений</returns>
        private byte[] GetDirections()
        {
            byte[] directs = new byte[] { 1, 3, 5, 7 };

            if (figY == 0) directs = directs.Except(new byte[] { 3, 5 }).ToArray();
            if (figY == 7) directs = directs.Except(new byte[] { 1, 7 }).ToArray();
            if (figX == 0) directs = directs.Except(new byte[] { 5, 7 }).ToArray();
            if (figX == 7) directs = directs.Except(new byte[] { 1, 3 }).ToArray();

            return directs;
        }
    }
}