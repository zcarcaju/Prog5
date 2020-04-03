using System;
using System.Collections.Generic;

namespace Isaque_FP
{
    class Program
    {
        List<int> MainList = new List<int>() {8,6,2,9,5,10,1,4,7,3};
        List<int> tempMainList = IntList(MainList);
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            for(int i = 0; i < tempMainList.Count; ++i)
            {
                Console.WriteLine(tempMainList[i]);
            }
        }
    }

    public static List <int> IntList(List <int>List)
    {
        List<int> tempList = new List<int>();
        
        for (int i = 0; i < List.Count; ++i)
        {
            tempList.Add(List[i]);
        }

        return initQuickSort(tempList);
        
    }

    public static List <int> initQuickSort(List<int> L_list)
    {
        int inicio = 0;
        int fim = L_list.Length - 1;

        quickSort(L_list, inicio, fim);

        return L_list;
    }

    private static void quickSort(List<int> vetor, int inicio, int fim)
    {
        if (inicio < fim)
        {
            int p = vetor[inicio];
            int i = inicio + 1;
            int f = fim;

            while (i <= f)
            {
                if (vetor[i] <= p)
                {
                    i++;
                }
                else if (p < vetor[f])
                {
                    f--;
                }
                else
                {
                    int troca = vetor[i];
                    vetor[i] = vetor[f];
                    vetor[f] = troca;
                    i++;
                    f--;
                }
            }

            vetor[inicio] = vetor[f];
            vetor[f] = p;

            quickSort(vetor, inicio, f - 1);
            quickSort(vetor, f + 1, fim);
        }
    }

}

