public class EnumConverter
{
    //Converts the enum name given into a string
    public static string ConvertToString(CellType state)
    {
        switch (state)
        {
            case CellType.CROSS:
                return "X";
            case CellType.NOUGHT:
                return "O";
            default:
                return "None";
        }
    }
}
