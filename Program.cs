using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3_AlgoExc
{
    class Program
    {
        private static int[] rifz = new int[35]; // Deklarasi Array int dengan ukuran 35
        private static int n; // Deklarasi Variabel int untuk menyimpan data array

        public void isiData() // Method menerima masukkan data
        {
            
            while (true) // Perulangan untuk menerima angka yang diisi
            {
                Console.WriteLine("================================");
                Console.Write("Masukkan Banyaknya Elemen Array : ");
                n = Int32.Parse(Console.ReadLine()); // Menerima masukkan user ke bentuk string dan mengkonversi ke Int pada variabel n
                
                if (n <= 35) // Cek kondisi jika n <= 35
                    break;
                else
                    Console.WriteLine("\nArray dapat mempunyai max 35 elemen !");
            }

            Console.WriteLine("");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("\tMasukkan elemen array : ");
            Console.WriteLine("-----------------------------------------");

            for (int i = 0; i < n; i++) // Perulangan input angka
            {
                Console.Write("[" + (i + 1) + "]. ");
                decimal a = decimal.Parse(Console.ReadLine());// Mengisi elemen array
            }
        }

        public void hasilSort() // Method memunculkan hasil sort
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("\tHasil Sort Data");
            Console.WriteLine("-------------------------------");

            for (int ms = 0; ms < n; ms++)
            {

                Console.WriteLine("[" + (ms + 1) + "]. " + rifz[ms]); // Keluaran hasil sort data
            }

            Console.WriteLine("");
        }

        public void metodeSort1() // Method menggunakan insertion sort 
        {
            int temp, midx; // Set temp dan midx
            for (int i = 0; i < n - 1; i++)
            {
                midx = i; // Set midx = i 
                for (int ms = i + 1; ms < n; ms++)
                {
                    if (rifz[midx] > rifz[ms]) // Cek kondisi elemen array
                    {
                        midx = ms;
                    }
                }
                // Swap data
                temp = rifz[midx];
                rifz[midx] = rifz[i];
                rifz[i] = temp;
            }
        }

        public void metodeSort2(int[] rifz, int low, int high) // Method menggunakan merge sort
        {
            if (low < high) // Cek kondisi data
            {
                int mid = (low + high) / 2; // Set mid

                // Recursion
                metodeSort2(rifz, low, mid);
                metodeSort2(rifz, mid + 1, high);

                mergeArr(rifz, low, mid, high); // Proses menuju ke method yang dituju
            }
        }

        public void mergeArr(int[] rifz, int low, int mid, int high) // Method Lanjutan merge sort
        {
            // Set variabel dan array
            int x = mid - low + 1;
            int y = high - mid;
            int[] L = new int[x];
            int[] R = new int[y];
            int i, ms;

            for (int a = 0; a < x; a++) // Perulangan 
            {
                L[a] = rifz[low + a]; // Store data ke array L
            }

            for (int b = 0; b < y; b++)
            {
                R[b] = rifz[mid + 1 + b]; // Store data ke array R
            }
            // Set variabel
            int k;
            i = 0;
            ms = 0;
            k = low;

            while (i < x && ms < y) // Perulangan
            {
                if (L[i] <= R[ms]) // Cek kondisi elemen array
                {
                    rifz[k] = L[i]; // Store data ke array original
                    i++; // Increment variabel
                }
                else
                {
                    rifz[k] = R[ms]; // Store data
                    ms++; // Increment variabel
                }

                k++; // Increment variabel
            }

            while (i < x) // Perulangan
            {
                rifz[k] = L[i]; // Store data ke array original
                // Increment variabel
                i++;
                k++;
            }

            while (ms < y)
            {
                rifz[k] = R[ms]; // Store data ke array original
                // Increment variabel
                ms++;
                k++;
            }
        }

        static void Main(string[] args)
        {
            Console.Clear();
            Program rz = new Program(); // Set instance class

            bool loop = true; // Set loop
            decimal pilihan; // Set pilihan
            Console.WriteLine("SELAMAT DATANG DI APLIKASI SORT DATA");
            while (loop)
            {
                try
                {
                    Console.WriteLine("=============================");
                    Console.WriteLine("\tMENU UTAMA");
                    Console.WriteLine("=============================");
                    Console.WriteLine("[1]. Metode Sort 1 (Insertion Sort)");
                    Console.WriteLine("[2]. Metode Sort 2 (Merge Sort)");
                    Console.WriteLine("[3]. Keluar ");
                    Console.WriteLine("-----------------------------");
                    Console.Write("Pilihan Anda : ");
                    pilihan = decimal.Parse(Console.ReadLine());
                    // Pilihan dengan metode switch
                    switch (pilihan)
                    {
                        case 1: // Menuju opsi 1
                            Console.Clear();
                            Console.WriteLine("\tINSERTION SORT");
                            rz.isiData();
                            rz.metodeSort1();
                            rz.hasilSort();
                            break;
                        case 2: // Menuju opsi 2
                            Console.Clear();
                            Console.WriteLine("\tMERGE SORT");
                            rz.isiData();
                            rz.metodeSort2(rifz, 0, n - 1);
                            rz.hasilSort();
                            break;
                        case 3: // Menuju opsi 3
                            loop = false;
                            break;
                        default: // Jika input tidak sesuai dengan case
                            Console.WriteLine("Pilihan Tak Tersedia / INVALID !");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Kesalahan : "+ex.Message); // Keluaran error
                }
            }
        }
    }
}