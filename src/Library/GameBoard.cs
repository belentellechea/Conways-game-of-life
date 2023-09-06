using System;

namespace PII_Game_Of_Life
{
    public class GameBoard
    {
        private bool[,] gameBoard;
        private int width;   //variable que representa el ancho del tablero
        private int height;   //variable que representa el alto del tablero

        public GameBoard(int width, int height, bool[,] initialBoard)
        // constructor de la clase que recibe ancho, alto y el estado incial del tablero
        {
            this.width = width;  
            this.height = height;
            gameBoard = new bool[width, height];   //se inicia la matriz
            Array.Copy(initialBoard, gameBoard, initialBoard.Length);
            // se copia el estado incial al tablero
        }
        public bool[,] GetBoard
        {
            get { return gameBoard; }
        }

        public void BoardGeneration()   //método que genera el siguiente tablero
        {
            bool[,] cloneboard = new bool[width, height]; //copia el tablero
            for (int x = 0; x < width; x++)   //se recorre cada celula
            {
                for (int y = 0; y < height; y++)
                {
                    int aliveNeighbors = CountAliveNeighbors(x,y);
                    if(gameBoard[x,y])
                    {
                        aliveNeighbors--; 
                    }
                    if (gameBoard[x,y] && aliveNeighbors < 2)
                    {
                        //Celula muere por baja población
                        cloneboard[x,y] = false;
                    }
                    else if (gameBoard[x,y] && aliveNeighbors > 3)
                    {
                        //Celula muere por sobrepoblación
                        cloneboard[x,y] = false;
                    }
                    else if (!gameBoard[x,y] && aliveNeighbors == 3)
                    {
                        //Celula nace por reproducción
                        cloneboard[x,y] = true;
                    }
                    else
                    {
                        //Celula mantiene el estado que tenía
                        cloneboard[x,y] = gameBoard[x,y];
                    }
                }
            }
            gameBoard = cloneboard; //actualización del tablero
        }

        private int CountAliveNeighbors(int x, int y)   //método que calcula los vecinos vivos 
        {
            int aliveNeighbors = 0;
            for (int i = x-1; i<=x+1;i++)
            {
                for (int j = y-1;j<=y+1;j++) 
                {
                    if(i>=0 && i<width && j>=0 && j < height && gameBoard[i,j])
                    {
                        aliveNeighbors++;
                    }
                }
            }
            return aliveNeighbors;
        }
    }
}