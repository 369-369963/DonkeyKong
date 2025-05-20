using System;
using System.Numerics;
using DxLibDLL;

static class Player
{
    public static void Update(InputState input)
    {
        if (input.Jump)
        {
            Console.WriteLine("Jump");
        }
        if (input.Right)
        {
            Console.WriteLine("Move Right");
        }
        if (input.Left)
        {
            Console.WriteLine("Move Left");
        }
    }
}
