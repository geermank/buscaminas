namespace Buscaminas
{
    internal class CellViewConfig
    {
        private static readonly int CELL_SIZE_IN_PX = 40;
        private static readonly int TOP_BUTTON_SIZE_IN_PX = 60;

        public static int CellSize
        {
            get { return CELL_SIZE_IN_PX; }
        }

        public static int HeaderHeight
        {
            get { return TOP_BUTTON_SIZE_IN_PX; }
        }

        public static int FaceButtonSize
        {
            get { return TOP_BUTTON_SIZE_IN_PX; }
        }
        
        public static int CalculatePanelSize(int numberOfCells)
        {
            return CellSize * numberOfCells;
        }

        public static int CalculateFaceButtonXPosition(int numberOfCells)
        {
            return (CalculatePanelSize(numberOfCells) / 2) - (FaceButtonSize / 2);
        }
    }



}
