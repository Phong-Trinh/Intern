using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Bill
{
    class DetailBill : IOutFile
    {
        private string _productID;
        private string _productName;
        private string _whereMadeProduct;
        private string _productType;
        private string _detailType;
        private Fan _fanInfor;
        private AirConditioner _airConditionerInfor;
        private int _productNumber = 0;
        private int _productPrice;

        public void PrintDetailPrice(ref int line)
        {
            line++;
            Console.SetCursorPosition(31, 5 + line++);
            Console.Write("-"+_productType + ": " + _productID + " "+_detailType+" " + _productName + " " + _whereMadeProduct);
            Console.SetCursorPosition(39, 5 + line++);
            if(_fanInfor != null)
            Console.Write(" " + TotalPrice() + " " + _fanInfor._capacity + " " + _productNumber);
            else if(_airConditionerInfor != null) Console.Write(" " + TotalPrice() + " " + _airConditionerInfor.GetAntiBacterial() + " "+ _airConditionerInfor.GetDeodorant()+" " + _productNumber);
        }
        public void GetInfor()
        {
            int line = 15;
            InputErrors catchInput = new InputErrors();
            Console.SetCursorPosition(30, 5 + line+1);
            Console.Write("                     (1-Fan, 2-Air Conditoner) ");
            Console.SetCursorPosition(30, 5 + line++);
            Console.Write("Please enter type of product: ");
            int checkType;
            catchInput.CatchInput(out checkType, 60, 5 + line - 1, 2);
            Console.SetCursorPosition(30, 5 + line);
            Console.Write("                                                ");
            switch (checkType)
            {
                case 1:
                    {
                        Console.SetCursorPosition(60, 5 + line - 1);
                        Console.Write("1-Fan");
                        Console.SetCursorPosition(30, 5 + line + 1);
                        Console.Write("                 (1-Stading, 2-Steam, 3-Electric) ");
                        Console.SetCursorPosition(30, 5 + line++);
                        Console.Write("Plese choose fan's type: ");
                        int fanType;
                        catchInput.CatchInput(out fanType, 55, 5 + line - 1, 3);
                        Console.SetCursorPosition(30, 5 + line);
                        Console.Write("                                                   ");
                        switch (fanType)
                        {
                            case 1:
                                {
                                    Console.SetCursorPosition(55, 5 + line -1);
                                    Console.Write("1-Stading");
                                    _fanInfor = new StandingFan();
                                    break;
                                }
                            case 2:
                                {
                                    Console.SetCursorPosition(55, 5 + line - 1);
                                    Console.Write("2-Steam");
                                    _fanInfor = new SteamFan();
                                    break;
                                }
                            case 3:
                                {
                                    Console.SetCursorPosition(55, 5 + line - 1);
                                    Console.Write("3-Electric");
                                    _fanInfor = new ElectricFan();
                                    break;
                                }
                        }
                        _productPrice =_fanInfor.GetPrice();
                        _detailType = _fanInfor.GetFanType();
                        _productType = _fanInfor.GetProductType();
                        break;
                    }
                case 2:
                    {                    
                        Console.SetCursorPosition(60, 5 + line - 1);
                        Console.Write("2-Air Conditioner");
                        Console.SetCursorPosition(30, 5 + line + 1);
                        Console.Write("               (1-One Way, 2-Two Way) ");
                        Console.SetCursorPosition(30, 5 + line++);
                        Console.Write("Please choose air conditioner's type: ");
                        int airconditionerType;
                        catchInput.CatchInput(out airconditionerType, 67, 5 + line - 1, 2);
                        Console.SetCursorPosition(30, 5 + line);
                        Console.Write("                                                   ");
                        switch (airconditionerType)
                        {
                            case 1:
                                {
                                    Console.SetCursorPosition(67, 5 + line - 1);
                                    Console.Write("1-One Way");
                                    _airConditionerInfor = new OneWayAirConditioner();
                                    break;
                                }
                            case 2:
                                {
                                    Console.SetCursorPosition(67, 5 + line - 1);
                                    Console.Write("2-Two Way");
                                    _airConditionerInfor = new TwoWayAirConditioner();
                                    break;
                                }
                        }
                        _productPrice = _airConditionerInfor.GetPrice();
                        _productType = _airConditionerInfor.GetProductType();
                        break;
                    }
                    break;
            }
            line += 3;
            Console.SetCursorPosition(30, 5 + line++);
            Console.Write("Please enter a product ID: ");
            _productID = Console.ReadLine();
            Console.SetCursorPosition(30, 5 + line++);
            Console.Write("Please enter a product name: ");
            _productName = Console.ReadLine();
            Console.SetCursorPosition(30, 5 + line++);
            Console.Write("Please enter where product made in: ");
            _whereMadeProduct = Console.ReadLine();
            line = 23;
            Console.SetCursorPosition(30, 5 + line++);
            Console.Write("Please enter product quanity: ");
            catchInput.CatchInput(out _productNumber, 63, 5+ line - 1);
            Console.SetCursorPosition(30, 5 + line+1);
            Console.Write("            Product's price:  " + _productPrice * _productNumber);
        }
        public int TotalPrice()
        {
            return _productPrice * _productNumber;
        }

        public void ToStringFile(string[] k, int line)
        {
            k[line++]=("-" + _productType + ": id " + _productID + ", type: " + _detailType + ", name: " + _productName + ", made in: " + _whereMadeProduct);
            if (_fanInfor != null)
                k[line++]=("price: " + TotalPrice() + ", capacity: " + _fanInfor._capacity + " quanity: " + _productNumber);
            else k[line++]=("price: " + TotalPrice() + ", " + _airConditionerInfor.GetAntiBacterial() + ", " + _airConditionerInfor.GetDeodorant() + ", quanity: " + _productNumber);
        }
    }
}
