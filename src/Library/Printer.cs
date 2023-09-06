using System;
using System.Text;   //permite utilizar StringBUilder
using System.Threading;

namespace PII_Game_Of_Life
{
    public class Printer   //imprime el tablero en la consola
    {

        private bool[,] board;   //variable que representa el tablero
        private int width;   //variabe que representa el ancho del tablero
        private int height;   //variabe que representa altura del tablero
        
        public Printer(bool[,] board, int width, int height)
        //constructor de la clase
        {
            this.board = board;
            this.width = width;
            this.height = height;
        }

        public void Print()
        {
            while (true)   //bulce infinito, se regenerará el tablero de forma indefinida
            {
                Console.Clear();   //borra el anterior tablero para mostrar el nuevo
                StringBuilder s = new StringBuilder();
                for (int y = 0; y<height;y++)
                {
                    for (int x = 0; x<width; x++)
                    {
                        if(board[x,y])
                        {
                            s.Append("|X|");
                        }
                        else
                        {
                            s.Append("___");
                        }
                    }
                    s.Append("\n");
                }
                Console.WriteLine(s.ToString());  
                
                GameBoard next = new GameBoard(width,height, board);   //se crea un nuevo tablero
                next.BoardGeneration();   //se genera el siguiente tablero 
                board=next.GetBoard;   //se reemplaza el tablero actual
                Thread.Sleep(300);   //se esperan 300 ms para mostrar el siguiente tablero
            }
        
        }
    }
}
