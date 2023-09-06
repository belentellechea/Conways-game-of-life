using System;
using System.IO;   //hace posible la manipulación de archivos y directorios

namespace PII_Game_Of_Life
{
    public class Importer   //clase que importará el archivo de texto 
    {
        public bool[,] ImportTxt(string url)   //método devuelve una matriz bidimensional de tipo booleano 
        {
            string content = File.ReadAllText(url);   //lee y guarda todo en la cadena
            string[] contentLines = content.Split('\n');   //separa content en distintas lineas
            bool[,] board = new bool[contentLines.Length, contentLines[0].Length];   //se crea el tablero
            for (int  y=0; y<contentLines.Length;y++)   //bucle que recorre las lineas de contentLines
            {
                for (int x=0; x<contentLines[y].Length; x++)   //bucle que recorre cada caracter de la linea
                {
                    if(contentLines[y][x]=='1')
                    {
                        board[x,y]=true;   //se establecen las celulas vivas
                    }
                    // si es cero, será falso y por lo tanto la célula estará muerta
                }
            }
            return board;   //se devuelve la matriz del tablero
        }     
    }
}
