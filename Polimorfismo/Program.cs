using System;
using System.Collections.Generic;

namespace Polimorfismoo
{
    internal class Program
    {
        //Criada a variavel produtos
        protected int Products;

        public static void Main(string[] args)
        {
            //Pede para o usuario digitar quantos produtos serão cadastrados
            Console.WriteLine("Entre com número de produtos: ");
            //Lê o numero digitado e cria uma variavel com o valor
            var value = int.Parse(Console.ReadLine());
            //Cria a lista de produtos
            var products = new List<Product>();
            //Variavel i com valor 0, e altera a variavel value com +1
            for (var i = 0; i < value; i++)
            {
                //Adquirindo informações sobre os produtos
                Console.WriteLine("PRODUTO #" + (i + 1));

                Console.WriteLine("Comum, Usado ou Importado (C/U/I)");
                var stock = Console.ReadLine().ToUpper();
                //Criando variaveis com nome, preço, taxas e data
                string name;
                double price;
                double gas;
                DateTime dateTime;

                switch (stock)
                {
                    //"Caso" o produto seja de tal tipo, ele cria a lista alterando as variaveis
                    case "C":
                        Console.WriteLine("Nome:");
                        name = Console.ReadLine().ToUpper();
                        Console.WriteLine("Preço:");
                        price = double.Parse(Console.ReadLine());

                        products.Add(new Product(name, price));
                        break;
                    case "U":
                        Console.WriteLine("Nome:");
                        name = Console.ReadLine().ToUpper();
                        Console.WriteLine("Preço:");
                        price = double.Parse(Console.ReadLine());
                        Console.WriteLine("Fabricado:");
                        dateTime = DateTime.Parse(Console.ReadLine());

                        products.Add(new UsageProduct(name, price, dateTime));
                        break;
                    case "I":
                        Console.WriteLine("Nome:");
                        name = Console.ReadLine().ToUpper();
                        Console.WriteLine("Preço:");
                        price = double.Parse(Console.ReadLine());
                        Console.WriteLine("Taxa:");
                        gas = double.Parse(Console.ReadLine());

                        products.Add(new ImportedProduct(name, price, gas));
                        break;
                }
            }
            //Alterando os números dos produtos
            for (var i = 0; i < products.Count; i++)
            {
                Console.WriteLine(products[i].PriceTag());
            }
        }
    }
    //Criada a classe Produto
    public class Product
    {
        //Criando as variaveis nome e preço com encapsulamento
        protected string name;
        protected double price;

        
        public Product(string name, double price)
        {
            this.name = name;
            this.price = price;
        }
        //Método
        public virtual string PriceTag()
        {
            return name + " - " + price;
        }
    }
    //Criada a classe Podutos importados com herança
    public class ImportedProduct : Product
    {
        protected double gas;
        //Instanciando produto com encapsulamento
        public ImportedProduct(string name, double price, double gas) : base(name, price)
        {
            this.gas = gas;
        }
        //Método com as taxas
        public override string PriceTag()
        {
            return name + " - " + price + " (taxa: " + gas + ")";
        }
    }
    //Criada a classe Produtos usados
    public class UsageProduct : Product
    {
        private DateTime fabrication;
        //Instanciando produto com encapsulamento
        public UsageProduct(string name, double price, DateTime fabrication) : base(name, price)
        {
            this.fabrication = fabrication;
        }
        //Método usando ToString
        public override string PriceTag()
        {
            return name + " - " + price + " (fabricado: " + fabrication.ToString("dd/MM/yyyy") + ")";
        }
    }
}
