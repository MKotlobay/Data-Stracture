using Build_Base.MainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Build_Base.CustomClasses
{
    public class Game
    {
        private Node<int> head;
        private Node<int> current;
        private Node<int> playerPlace;
        public Game()
        {
            Random rnd = new Random();

            this.head = null;
            this.current = this.head;

            Node<int> node = new Node<int>(1);
            this.head = node;
            this.current = this.head;

            int num = rnd.Next(10, 30);
            for (int i = 2; i < num; i++)
            {
                node = new Node<int>(rnd.Next());
                this.current.SetNext(node);
                this.current = node;
            }
            this.current.SetNext(new Node<int>(rnd.Next(1,30)));
            this.current = this.current.GetNext();
            this.current.SetNext(this.head);

            this.playerPlace = this.head;
        }

        public void MovePlayer(int num)
        {
            int count = 0;

            while (count != num)
            {
                this.playerPlace = this.playerPlace.GetNext();
                count++;
            }
            Console.WriteLine("Player in place: ");
            ToPrintPlayerLocation(ConsoleColor.Yellow);
            Console.WriteLine("");
        }

        public void ToPrintPlayerLocation(ConsoleColor highlightColor)
        {
            ConsoleColor originalColor = Console.ForegroundColor;

            while (this.current.GetNext() != this.head && this.current.GetNext() != null)
            {
                Console.Write(this.current + " => ");
                this.current = this.current.GetNext();
            }
            Console.Write(this.current);
        }
    }
}
