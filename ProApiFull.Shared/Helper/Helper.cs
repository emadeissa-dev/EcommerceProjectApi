namespace ProApiFull.Shared.Helper;

public class Helper
{

    public string[] ExAddZeroForNumbers(params int[] numbers)
    {
        string[] array = new string[numbers.Length];
        for (int i = 0; i < numbers.Length; i++)
        {
            array[i] = string.Format("{0:0000}", numbers[i]);
        }
        return array;
    }


}
