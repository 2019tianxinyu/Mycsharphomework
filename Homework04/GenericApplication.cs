using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApplication {

  // 链表节点
  public class Node<T> {
    public Node<T> Next { get; set; }
    public T Data { get; set; }

    public Node(T t) {
      Next = null;
      Data = t;
    }
  }

  //泛型链表类
  public class GenericList<T> {
    private Node<T> head;
    private Node<T> tail;

    public GenericList() {
      tail = head = null;
    }

    public Node<T> Head {
      get => head;
    }

    public void Add(T t) {
      Node<T> n = new Node<T>(t);
      if (tail == null) {
        head = tail = n;
      }else {
        tail.Next = n;
        tail = n;
      }
    }
        public void foreach01(Action<T> action1)
        {
            Node<T> a;
            a = this.head;
            while (a!= tail)
            {
                action1(a.Data);
                a = a.Next;
            }
        }

  class Program {
    static void Main(string[] args) {
                int sum = 0;
                int max = 0;
                int min = int.MaxValue;
                GenericList<int> intList = new GenericList<int>();
                for (int x = 0; x < 10; x++)
                {
                    intList.Add(x);
                }
                intList.foreach01(s => Console.WriteLine(s));
                int max = int.MinValue;
                intList.foreach01(n => { max = max < n ? n : max; });
                Console.WriteLine($"最大值：{max}");
                int min = int.MaxValue;
                intList.foreach01(n => { min = min > n ? n : min; });
                Console.WriteLine($"最小值：{min}");
                intList.foreach01(n => { sum += n; });
                Console.WriteLine($"和：{sum}");
            }
     

    }

  }
}