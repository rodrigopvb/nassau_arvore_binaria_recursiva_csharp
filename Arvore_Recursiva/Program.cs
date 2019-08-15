using System;

namespace Arvore_Recursiva
{
    class Program
    {
        public class Arvore
        {
            public int num;
            public Arvore dir, esq;
        }

        static void Main(string[] args)
        {
            Arvore raiz = null;
            Arvore aux = null;

            int op, numero, achou;
            do
            {
                Console.WriteLine("1 - Consultar um nó da árvore");
                Console.WriteLine("2 - Consultar um nó da árvore");
                Console.WriteLine("3 - Consultar toda a árvore em ordem");
                Console.WriteLine("4 - Consultar toda a árvore em pré-ordem");
                Console.WriteLine("5 - Consultar toda a árvore em pós-ordem");
                Console.WriteLine("6 - Excluir um nó da árvore");
                Console.WriteLine("7 - Esvaziar árvore");
                Console.WriteLine("8 - Sair do programa");
                op = int.Parse(Console.ReadLine());

                switch (op)
                {
                    case 1:
                        Console.WriteLine("Digite o número a ser inserido:");
                        numero = int.Parse(Console.ReadLine());
                        raiz = Inserir(raiz, numero);
                        Console.WriteLine("Número inserido na árvore");
                        break;
                    case 2:
                        if(raiz == null)
                        {
                            Console.WriteLine("Árvore vazia");
                        }
                        else
                        {
                            Console.WriteLine("Digite o número a ser consultado:");
                            numero = int.Parse(Console.ReadLine());
                            achou = 0;
                            achou = Consultar(raiz, numero, achou);
                            if (achou == 0)
                                Console.WriteLine("Número não encontrado na árvore!");
                            else
                                Console.WriteLine("Número encontrado na árvore!");                            
                        }
                        break;
                    case 3:
                        if(raiz == null)
                        {
                            Console.WriteLine("Árvore vazia");
                        }
                        else
                        {
                            Console.WriteLine("Listando todos os elementos da árvore em ordem");
                            Mostraremordem(raiz);
                        }
                        break;
                    case 4:
                        if (raiz == null)
                        {
                            Console.WriteLine("Árvore vazia");
                        }
                        else
                        {
                            Console.WriteLine("Listando todos os elementos da árvore em pré-ordem");
                            Mostrarempreordem(raiz);
                        }
                        break;
                    case 5:
                        if (raiz == null)
                        {
                            Console.WriteLine("Árvore vazia");
                        }
                        else
                        {
                            Console.WriteLine("Listando todos os elementos da árvore em pós-ordem");
                            Mostraremposordem(raiz);
                        }
                        break;
                    case 6:
                        if (raiz == null)
                        {
                            Console.WriteLine("Árvore vazia");
                        }
                        else
                        {
                            Console.WriteLine("Digite o número a ser removido:");
                            numero = int.Parse(Console.ReadLine());
                            achou = 0;
                            achou = Consultar(raiz, numero, achou);
                            if (achou == 0)
                                Console.WriteLine("Número não encontrado na árvore!");
                            else
                                raiz = Remover(raiz, numero);
                                Console.WriteLine("Número encontrado na árvore!");
                        }
                        break;
                    case 7:
                        if (raiz == null)
                        {
                            Console.WriteLine("Árvore vazia");
                        }
                        else
                        {
                            raiz = null;
                            Console.WriteLine("Árvore esvaziada");
                        }
                        break;
                    case 8:
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }

            } while (op != 8);                        
        }

        public static Arvore Inserir(Arvore aux, int num)
        {
            if(aux == null)
            {
                aux = new Arvore();
                aux.num = num;
                aux.esq = null;
                aux.dir = null;
            }else if(num < aux.num)
            {
                aux.esq = Inserir(aux.esq, num);
            }
            else
            {
                aux.dir = Inserir(aux.dir, num);
            }
            return aux;
        }

        public static int Consultar(Arvore aux, int num, int achou)
        {
            if(aux != null && achou == 0)
            {
                if (aux.num == num)
                {
                    achou = 1;
                }else if(num < aux.num)
                {
                    achou = Consultar(aux.esq, num, achou);
                }
                else
                {
                    achou = Consultar(aux.dir, num, achou);
                }
            }

            return achou;
        }

        public static void Mostraremordem(Arvore aux)
        {
            if(aux != null)
            {
                Mostraremordem(aux.esq);
                Console.Write(aux.num + " ");
                Mostraremordem(aux.dir);
            }
        }

        public static void Mostrarempreordem(Arvore aux)
        {
            if (aux != null)
            {
                Console.Write(aux.num + " ");
                Mostraremordem(aux.esq);
                Mostraremordem(aux.dir);
            }
        }

        public static void Mostraremposordem(Arvore aux)
        {
            if (aux != null)
            {
                Mostraremordem(aux.esq);
                Mostraremordem(aux.dir);
                Console.Write(aux.num + " ");
            }
        }

        public static Arvore Remover(Arvore aux, int num)
        {
            Arvore p, p2;
            if(aux.num == num)
            {
                if(aux.esq == aux.dir)
                {
                    //o elemento a ser removido não tem filhos
                    return null;
                }else if(aux.esq == null)
                {
                    //o elemento a ser removido não tem filho para à esquerda
                    return aux.dir;
                }else if (aux.dir ==null)
                {
                    // o elemento a ser removido não tem filho a esquerda
                    return aux.esq;
                }
                else
                {
                    // o elemento a ser removido tem filho para ambos os lados
                    p2 = aux.dir;
                    p = aux.dir;
                    while(p.esq != null)
                    {
                        p = p.esq;
                    }
                    p.esq = aux.esq;
                    return p2;
                }
            }
            else if(aux.num < num)
            {
                aux.dir = Remover(aux.dir, num);
            }
            else
            {
                aux.esq = Remover(aux.esq, num);
            }
            return aux;
        }
    }
}
