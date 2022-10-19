using BuscaminasDomain.GameBoard.Iterator;
using System;
using System.Collections.Generic;

namespace BuscaminasDomain.GameBoard
{
    internal class BoardGenerator
    {
        private static BoardGenerator sInstance;

        public static BoardGenerator GetInstance()
        {
            if (sInstance == null)
            {
                sInstance = new BoardGenerator();
            }
            return sInstance;
        }

        private BoardGenerator()
        {
            // empty private constructor
        }

        public Board CreateBoard(GameDifficulty gameDifficulty)
        {
            BoardCell[,] boardCells = new BoardCell[gameDifficulty.Width, gameDifficulty.Height];
            BoardSize size = new BoardSize(gameDifficulty.Width, gameDifficulty.Height);
            InitializeBoard(boardCells, size);
            
            List<BoardPosition> minesPositions = PopulateBoardWithMines(boardCells, gameDifficulty);
            PopulateBoardWithNumbers(boardCells, size, minesPositions);

            return new Board(boardCells, size, gameDifficulty.Mines);
        }

        private void InitializeBoard(BoardCell[,] boardCells, BoardSize size)
        {
            for(int x = 0; x < size.Width; x++)
            {
                for(int y = 0; y < size.Height; y++)
                {
                    boardCells[x, y] = new EmptyCell(new BoardPosition(x, y));
                }
            }
        }

        private List<BoardPosition> PopulateBoardWithMines(BoardCell[,] boardCells, GameDifficulty gameDifficulty)
        {
            List<BoardPosition> minesPositions = CalculateMinesPosition(gameDifficulty);
            foreach (BoardPosition position in minesPositions)
            {
                boardCells[position.X, position.Y] = new MineCell(position);
            }
            return minesPositions;
        }

        private List<BoardPosition> CalculateMinesPosition(GameDifficulty gameDifficulty)
        {
            Random random = new Random();

            List<BoardPosition> boardPositions = new List<BoardPosition>();
            for(int index = 0; index < gameDifficulty.Mines; index++)
            {
                BoardPosition position;
                do
                {
                    int nextX = random.Next(0, gameDifficulty.Width);
                    int nextY = random.Next(0, gameDifficulty.Height);
                    position = new BoardPosition(nextX, nextY);
                } while (boardPositions.Contains(position));

                boardPositions.Add(position);
            }
            
            return boardPositions;
        }

        private void PopulateBoardWithNumbers(BoardCell[,] boardCells, 
                                              BoardSize boardSize,
                                              List<BoardPosition> minesPositions)
        {
            foreach(BoardPosition position in minesPositions)
            {
                BoardCell mine = boardCells[position.X, position.Y];

                IBoardIterator mineNeighboursIterator = new CellNeighboursIterator(boardCells, mine, boardSize);
                while(mineNeighboursIterator.HasNext())
                {
                    int numberOfSurroundingMines = 0;

                    BoardCell neighbour = mineNeighboursIterator.Next();
                    if (neighbour == null || neighbour is MineCell)
                    {
                        continue;
                    }
                    
                    IBoardIterator numberIterator = new CellNeighboursIterator(boardCells, neighbour, boardSize);
                    while(numberIterator.HasNext())
                    {
                        if (numberIterator.Next() is MineCell)
                        {
                            numberOfSurroundingMines++;
                        }
                    }
                    if (numberOfSurroundingMines > 0)
                    {
                        BoardPosition numberPosition = neighbour.Position;
                        boardCells[numberPosition.X, numberPosition.Y] = new NumberCell(numberOfSurroundingMines, numberPosition);
                    }
                }
            }
        }
    }
}