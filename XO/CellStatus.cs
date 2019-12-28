namespace XO
{
    public  enum CellStatus
    {
        /// <summary>
        /// Не нажата/Продолжение игры
        /// </summary>
        Unclick = 0,
        /// <summary>
        /// Ноль/Победа нуля
        /// </summary>
        Zero = 1,
        /// <summary>
        /// Крестик/ Победа кестика
        /// </summary>
        Cross = 2,
        /// <summary>
        /// Ничья
        /// </summary>
        Fall = 3
    }
}