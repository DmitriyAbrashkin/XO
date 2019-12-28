using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XO
{/*
    Игровое поле
        -[]клетки

    Метод проверки конца игры

    Клетка
        - Не нажата
        - Крестик
        - Нолик

    TODO:
   + Добавить в свойства ячейки координаты 
   + Поменять методы, чтобы они работали с параметрами из свойств ячеек
   + При каждом ходе менять крестик на нолик и наоборт
   + EndGame возвращает победителя или ничью 
   + Сообщение 
   + Статистику
   + проверки на недоступность кнопки
     */
    public class Feld
    {
        /// <summary>
        /// Массив ячеек
        /// </summary>
        public Cell[,] Cells { get; set; }

        public Feld()
        {
            Cells = new Cell[3, 3];
            FillFeld();
        }
        /// <summary>
        /// Заполнения игрового поля 
        /// </summary>
        public void FillFeld()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    CellStatus cellStatus = CellStatus.Unclick;
                    Cell cell = new Cell(i, j, cellStatus);
                    Cells[i, j] = cell;
                }
            }

        }

        /// <summary>
        /// Проверка конца игры
        /// </summary>
        /// <param name="cells">
        /// Входной параметр: Матрица ячеек
        /// </param>
        /// <returns>
        /// Возвращат результат игры
        /// </returns>
        public CellStatus EndGame(Cell[,] cells)
        {
            int EndGameX;
            int EndGameY;
            int EndGame = 0;

            #region Проверка по столбцам
            for (int k = 0; k < 3; k++)
            {
                EndGameX = 0;
                EndGameY = 0;
                for (int i = 0; i < 3; i++)
                {
                    if (cells[i, k].Status == CellStatus.Cross)
                    {
                        EndGameX++;
                        if (EndGameX == 3)
                        {
                            return CellStatus.Cross;
                        }
                    }
                    else if (cells[i, k].Status == CellStatus.Zero)
                    {
                        EndGameY++;
                        if (EndGameY == 3)
                        {
                            return CellStatus.Zero;
                        }
                    }
                }
            }
            #endregion

            #region Проверка по строкам
            for (int k = 0; k < 3; k++)
            {
                EndGameX = 0;
                EndGameY = 0;
                for (int j = 0; j < 3; j++)
                {
                    if (cells[k, j].Status == CellStatus.Cross)
                    {
                        EndGameX++;
                        if (EndGameX == 3)
                        {
                            return CellStatus.Cross;
                        }
                    }
                    else if (cells[k, j].Status == CellStatus.Zero)
                    {
                        EndGameY++;
                        if (EndGameY == 3)
                        {
                            return CellStatus.Zero;
                        }
                    }
                }
            }
            #endregion

            #region Проверка главной диагонали
            EndGameX = 0;
            EndGameY = 0;
            int m = -1;
            for (int i = 0; i < 3; i++)
            {
                m++;
                if (cells[i, m].Status == CellStatus.Cross)
                {
                    EndGameX++;
                    if (EndGameX == 3)
                    {
                        return CellStatus.Cross;
                    }
                }
                else if (cells[i, m].Status == CellStatus.Zero)
                {
                    EndGameY++;
                    if (EndGameY == 3)
                    {
                        return CellStatus.Zero;
                    }
                }
            }
            #endregion

            #region Проверка побочной диагонали
            EndGameX = 0;
            EndGameY = 0;
            m = 3;
            for (int i = 0; i < 3; i++)
            {
                m--;
                if (cells[i, m].Status == CellStatus.Cross)
                {
                    EndGameX++;
                    if (EndGameX == 3)
                    {
                        return CellStatus.Cross;
                    }
                }
                else if (cells[i, m].Status == CellStatus.Zero)
                {
                    EndGameY++;
                    if (EndGameY == 3)
                    {
                        return CellStatus.Zero;
                    }
                }
            }
            #endregion

            #region Проверка ничьи
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if(cells[i, j].Status != CellStatus.Unclick)
                    {
                        EndGame++;
                        if(EndGame == 9)
                        {
                            return CellStatus.Fall;
                        }
                    }
                }
            }
            #endregion

            return CellStatus.Unclick;
        }
    }

}
