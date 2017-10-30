using System;

namespace Zadrga
{
	class Program
	{
		public static void Main(string[] args)
		{
		
			int[] tab1 = {1,2,3};
			int[] tab2 = {6,42,9,7,9,0,8,65};
			izpisi(Zadrga(tab1, tab2));
			

		}
		public static int[] Zadrga(int[] tab1, int[] tab2)
		{
			int kje1 = 0;
			int kje2 = 0;
			int i = -1;
			int[] tabela = new int[(tab1.Length+tab2.Length)];
			while (kje1 < tab1.Length && kje2 < tab2.Length)
			{
				i++;
				tabela[i] = tab1[kje1];
				tabela[i+1] = tab2[kje2];
				kje1++;
				kje2++;
				i++;
			}
			
			while (kje1 < tab1.Length)
			{
				tabela[i+1] = tab1[kje1];
				kje1++;
				i++;
			}
			
			while (kje2 < tab2.Length)
			{
				tabela[i+1] = tab2[kje2];
				kje2++;
				i++;
			}
			
			return tabela;
			
		}
		public static void izpisi(int[] tab)
		{
			for (int i = 0; i<tab.Length-1;i++)
			{
				Console.Write(tab[i]+",");
			}
			Console.Write(tab[tab.Length-1]);
		}
	}
}
