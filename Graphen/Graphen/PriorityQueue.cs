using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class PriorityQueue<T> where T : IComparable<T>
{
    public List<T> data;

    public PriorityQueue()
    {
        this.data = new List<T>();
    }

    public int GetLength()
    {
        return data.Count;
    }

    public void EnqueueList(List<T> item)
    {
        for (int i = 0; i < item.Count; i++)
        {
            Enqueue(item[i]);
        }
    }

    /// <summary>
    /// Füge ein neues Element der Queue hinzu und sortiere die Queue, so dass die Wurzel das kleinste Element enthält
    /// </summary>
    /// <param name="item"></param>
    public void Enqueue(T item)
    {
        data.Add(item);
        int childIndex = data.Count - 1; // child index
        while (childIndex > 0)
        {
            int parentIndex = (childIndex - 1) / 2; // parent index
            if (data[childIndex].CompareTo(data[parentIndex]) >= 0)
                break; // Kind ist größer oder gleich parent, somit fertig
            T tmp = data[childIndex];
            data[childIndex] = data[parentIndex];
            data[parentIndex] = tmp;
            childIndex = parentIndex;
        }
    }

    /// <summary>
    /// Entferne das 1. Element, die Wurzel, und sortiere die Queue 
    /// </summary>
    /// <returns>Gibt das 1. Element zurück</returns>
    public T Dequeue()
    {
        if (data.Count == 0)
        {
            throw new ArgumentNullException("data");
        }
        int lastIndex = data.Count - 1;
        T root = data[0];   // Wurzel sichern zum returnen
        data[0] = data[lastIndex];  // letztes Element wird zum ersten Element
        data.RemoveAt(lastIndex);   // entferne letztes Element

        lastIndex--;
        int parentIndex = 0; 
        while (true)
        {
            int leftChildIndex = parentIndex * 2 + 1;
            if (leftChildIndex > lastIndex)
                break;  // keine Kinder, somit fertig
            int rightChildIndex = leftChildIndex + 1;
            if (rightChildIndex <= lastIndex && data[rightChildIndex].CompareTo(data[leftChildIndex]) < 0) // Falls es ein rechtes Kind gibt, dass kleiner als das linke Kind ist, benutze das rechte Kind
                leftChildIndex = rightChildIndex;
            if (data[parentIndex].CompareTo(data[leftChildIndex]) <= 0)
                break; // parent kleiner oder gleich kleinstem Kind somit fertig
            T tmp = data[parentIndex];
            data[parentIndex] = data[leftChildIndex];
            data[leftChildIndex] = tmp; // vertausche parent und Kind
            parentIndex = leftChildIndex;
        } 
        return root;
    }

    public T Root()
    {
        T root = data[0];
        return root;
    }
}