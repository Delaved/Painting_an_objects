using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintPicture
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List available pictures:");
            Console.WriteLine("1) square");
            Console.WriteLine("2) spruce");
            Console.WriteLine("3) tent");

            switch (Console.ReadLine())
            {
                case "1":
                case "square":
                    PaintSquare();          
                    break;
                case "2":
                case "spruce":
                    PainteSpruce();
                    break;
                case "3":
                case "tent":
                    PainteTent();
                    break;

            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Wait action...");
            Console.Read();
        }

        static void PaintSquare ()
        {
            Console.WriteLine("Input size the square");
            int _size_of_square = Int32.Parse(Console.ReadLine());
            //for (int i = 0; i < _size_of_square; i++)
            //{
            //    Console.Write('x');
            //}
            int it = 0;
            while (it <= Convert.ToInt32((_size_of_square)/2))                      // initialize the length of the left/right sides
            {
                Console.WriteLine();
                if (it == 0 || it == Convert.ToInt32((_size_of_square) / 2))
                {
                    for (int i = 0; i < _size_of_square; i++)                        // draws on the top and bottom square's sides 
                    {
                        Console.Write('x');
                    }
                }
                else
                {
                    for (int i = 0; i < _size_of_square; i++)                        
                    {
                        if (i == 0 || i == _size_of_square - 1)                     // draws the left and right square's sides 
                        {
                            Console.Write('x');
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                }
                it++;
            }
        }
        static void PainteSpruce ()
        {
            Console.WriteLine("Input size the spruce");
            bool _user_input_number = Int32.TryParse(Console.ReadLine(), out int _size_spruce);
            if (!_user_input_number) 
            {
                return;
            }
            int _centre = Convert.ToInt32(_size_spruce / 2);
            int _length_triangle = _size_spruce;
            for (int j = 0; j < 3; j++)                                                   //draw 3 triangle of the tree
            {
                for (int _length_spruce = 0; _length_spruce < _centre; _length_spruce++)   // go to the bottom of a certain triangle
                {
                    if (_length_spruce < j)                                                 // narrowest point of a trianle be wider than the first triangle
                    {
                        continue;
                    }
                    switch (j)
                    {
                        case 0:                                                           // first triangle is the smallest
                            _length_triangle = Convert.ToInt32(_size_spruce * 0.2); 
                            break;
                        case 1:                                                           // second triangle is the middle
                            _length_triangle = Convert.ToInt32(_size_spruce * 0.3);
                            break;
                        case 2:                                                           // third triangle  is the biggest
                            _length_triangle = _size_spruce;
                            break;
                    }
                    for (int _width = 0; _width < _size_spruce; _width++)               //run from left to right and paint the correct coordinates
                    {
                        if (_width >= _centre - _length_spruce && _width <= _centre + _length_spruce)
                        {
                            Console.Write('x');
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                    Console.WriteLine();
                    if (_length_spruce == _length_triangle)
                    {
                        break;
                    }   
                }
            }

            int _length_trunk = Convert.ToInt32(_size_spruce * 0.2);
            int _width_trunk = Convert.ToInt32(_size_spruce * 0.1);
            for (int i = 0; i < _length_trunk; i++)                   //run to the bottom of the tree trunk
            {
                for (int j = 0; j < _size_spruce; j++)
                {
                    if (j >= _centre - _width_trunk && j <= _centre + _width_trunk)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(' ');
                    }     
                }
                Console.WriteLine();
            }


        }

        static void PainteTent ()
        {
            Console.WriteLine("Input the radius of the circle");
            bool _input_number = Int32.TryParse(Console.ReadLine(), out int _horizontal_radius);
            if (!_input_number)
            {
                return;
            }
            int _vertical_radius = Convert.ToInt32(_horizontal_radius/2);
            int _diameter = _horizontal_radius * 2;
            int _half__vertical_radius = Convert.ToInt32(_vertical_radius / 2);

            FirstHalf(_horizontal_radius, _vertical_radius, _half__vertical_radius, _diameter);
        }

        static void FirstHalf(int _horizontal_radius, int _vertical_radius, int _half__vertical_radius, int _diameter)
        {
            int _previous_delta = 999999;
            
            for (int i = 0; i < _vertical_radius; i++)                                           // run to the bottom of the first hemisphere
            {
                bool _paint_x = false;
                for (int j = 0; j <= _diameter; j++)                                    // run the width of the circle
                {  
                    if ((j == _horizontal_radius - (i * 2) || j == _horizontal_radius + (i * 2)) && i < _half__vertical_radius)
                    {
                        Console.Write('x');
                        _previous_delta = i * 2;
                    }
                    
                    else if ((j == _horizontal_radius - (_previous_delta + 1) || j == _horizontal_radius + _previous_delta + 1) && i > _half__vertical_radius && (i + 1) % 2 == 0)
                    {
                        Console.Write('x');
                        _paint_x = true;
                    }   
                    else
                    {
                        Console.Write(' ');
                    }
                }
                if (_paint_x)
                {
                    _previous_delta++;
                }

                Console.WriteLine();
            }
        }
    }
}
