namespace JSTester.Tasks.VM
{
    interface IVM
    {
        string CalculateNod(int a, int b);
        /*!
            \brief Вычисление факториала чис n 
            \param n - число, чей факториал необходимо вычислить
           
        */
        string CalculateFactorial(int a);
    }
}
