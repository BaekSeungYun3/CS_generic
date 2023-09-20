//List와 배열에 10개의 랜덤숫자를 저장하고 정렬

int[] a = new int[10];
double[] d = new double[10];
List<int> b = new List<int>();

Random r = new Random();

for(int i = 0; i< 10; i++)
{
    a[i] = r.Next(100);
    b.Add(a[i]);
    d[i] = r.NextDouble();   //0~1 사이의 숫자 만들어줌
}

PrintArr(a);
PrintArr(d);
printList(b);

//정렬
Array.Sort(a);
b.Sort();

Console.WriteLine("\n 정렬한 후");
PrintArr(a);
PrintArr(d);
printList(b);


void PrintArr<T>(T[] a)
{
    //for(int i = 0; i < a.Length; i++)
        //Console.WriteLine(a[i]);
    
    Console.WriteLine("--배열--");

    foreach(var i in a)
        Console.WriteLine(i);
}

void printList(List<int> a)
{
    Console.WriteLine("--리스트--");

    foreach (int i in a)
        Console.WriteLine(i);
}
