using System;
using System.Diagnostics;
using System.Timers;

namespace Minesweeper2.Models
{
    public class BoardModel
    {
        public int Size { get; set; }
        public int Difficulty { get; set; }
        public int liveBombs { get; set; }
        public Stopwatch timer { get; set; }
        public double score { get; set; }
        public bool loss { get; set; }
        public string Mines { get; set; }

        //2d Array of cells
        public CellModel[,] theGrid { get; set; }


        public BoardModel(int s)
        {
            loss = false;
            score = 0;
            Size = s;
            timer = new Stopwatch();
            //create 2d array
            theGrid = new CellModel[Size, Size];
            int z = 0;

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    //occupy the array
                    theGrid[i, j] = new CellModel(i, j, z);
                    z++;
                }//end nested for loop
            }//end for loop
            Mines = "0";
        }//end constructor

        public void setupLiveNeighbors()
        {
            //set up random object
            Random rnd = new Random();
            //randomly occupy board with bombs based on difficulty
            switch (Difficulty)
            {
                case 1:
                    for (int i = 0; i < 15; i++)
                    {
                        int j, k;
                        j = rnd.Next(0, Size);
                        k = rnd.Next(0, Size);
                        if (theGrid[j, k].IsLive == true)
                        {
                            i--;
                        }//end if
                        else
                        {
                            theGrid[j, k].IsLive = true;
                            liveBombs++;
                        }//end else
                    }//end for loop
                    break;
                case 2:
                    for (int i = 0; i < 30; i++)
                    {
                        int j, k;
                        j = rnd.Next(0, Size);
                        k = rnd.Next(0, Size);
                        if (theGrid[j, k].IsLive == true)
                        {
                            i--;
                        }//end if
                        else
                        {
                            theGrid[j, k].IsLive = true;
                            liveBombs++;
                        }//end else
                    }//end for loop
                    break;

                case 3:
                    for (int i = 0; i < 45; i++)
                    {
                        int j, k;
                        j = rnd.Next(0, Size);
                        k = rnd.Next(0, Size);
                        if (theGrid[j, k].IsLive == true)
                        {
                            i--;
                        }//end if
                        else
                        {
                            theGrid[j, k].IsLive = true;
                            liveBombs++;
                        }//end else
                    }//end for loop
                    break;

            }//end switch
        }//end setupLiveNeighbors

        public void calculateLiveNeighbors()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (theGrid[i, j].IsLive == true)
                        theGrid[i, j].liveNeighbors = 9;
                    else
                    {
                        try
                        {
                            if (theGrid[i + 1, j].IsLive == true)
                                theGrid[i, j].liveNeighbors++;
                        }
                        catch { }//end try catch
                        try
                        {
                            if (theGrid[i - 1, j].IsLive == true)
                                theGrid[i, j].liveNeighbors++;
                        }
                        catch { }//end try catch
                        try
                        {
                            if (theGrid[i + 1, j + 1].IsLive == true)
                                theGrid[i, j].liveNeighbors++;
                        }
                        catch { }//end try catch
                        try
                        {
                            if (theGrid[i + 1, j - 1].IsLive == true)
                                theGrid[i, j].liveNeighbors++;
                        }
                        catch { }//end try catch
                        try
                        {
                            if (theGrid[i - 1, j + 1].IsLive == true)
                                theGrid[i, j].liveNeighbors++;
                        }
                        catch { }//end try catch
                        try
                        {
                            if (theGrid[i - 1, j - 1].IsLive == true)
                                theGrid[i, j].liveNeighbors++;
                        }
                        catch { }//end try catch
                        try
                        {
                            if (theGrid[i, j + 1].IsLive == true)
                                theGrid[i, j].liveNeighbors++;
                        }
                        catch { }//end try catch
                        try
                        {
                            if (theGrid[i, j - 1].IsLive == true)
                                theGrid[i, j].liveNeighbors++;
                        }
                        catch { }//end try catch
                    }//end else
                }//end for nested for loop
            }//end for loop
        }//end calculateLiveNeighbors

        public void floodFill(int r, int c)
        {
            theGrid[r, c].IsVisible = true;

            int[] x = { -1, 1, 0, 0, -1, -1, 1, 1 };
            int[] y = { 0, 0, 1, -1, -1, 1, 1, -1 };
            for (int i = 0; i < 8; i++)
            {
                if (isValid(r + x[i], c + y[i]))
                {
                    if (theGrid[r + x[i], c + y[i]].IsVisible == false && theGrid[r + x[i], c + y[i]].liveNeighbors == 0)
                    {
                        theGrid[r + x[i], c + y[i]].IsVisible = true;
                        floodFill(r + x[i], c + y[i]);
                    }//end if
                    else
                    {
                        theGrid[r + x[i], c + y[i]].IsVisible = true;
                    }//end else
                }//end for loop
            }//end for loop

        }//end floodfill

        private bool isValid(int r, int c)
        {
            if (r >= 0 && c >= 0 && r < Size && c < Size)
                return true;

            return false;
        }//end isValid

        public bool winCondition()
        {
            int covered = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (!theGrid[i, j].IsVisible) { covered++; }//end if
                }//end nested for loop
            }//end for loop 

            if (covered == liveBombs) { return true; }//end if

            return false;
        }//end win condition

        public void resetLiveNeighbors()
        {
            this.liveBombs = 0;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    theGrid[i, j].IsLive = false;
                    theGrid[i, j].IsVisible = false;
                    theGrid[i, j].liveNeighbors = 0;
                }//end nested for loop
            }//end for loop
        }//end resetLiveNeighbors

        public void minesRemaining()
        {
            int mines = 0;
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    if (theGrid[i, j].IsLive && theGrid[i,j].IsVisible == false)
                    {
                        mines++;
                    }//end if
                }//end nested for loop
            }//end for loop
            Mines = mines.ToString();
        }//end minesRemaining
    }//end board model
}//end namespace