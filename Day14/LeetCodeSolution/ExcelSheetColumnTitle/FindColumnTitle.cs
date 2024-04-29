namespace ExcelSheetColumnTitle
{
    public class FindColumnTitle
    {
        public int colNumber = 0;
        public FindColumnTitle(int columnNumber) {
            colNumber = columnNumber;
        }
        public string FindColumnTitleUsingNumber()
        {
            string result = "";
            while (colNumber > 0)
            {
                colNumber--;
                char c = (char)('A' + colNumber % 26);
                result = c + result;
                colNumber /= 26;
            }
            return result;
        }
    }
}
